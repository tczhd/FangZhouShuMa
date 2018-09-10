function PopulateAddModal() {
    // alert("Under construction....")
    var dataType = 'application/json; charset=utf-8';
    //var jsonData = JSON.stringify({
    //    FirstName: 'Andrew',
    //    LastName: 'Lock',
    //    Age: 31
    //});
    var modalBody = $('div.modal-body');
    var productId = $("input[name*='productId']").val();
    var productQuantity = $("input[name*='productQuantity']").val();
    if (productQuantity.length === 0) {
        modalBody.html("<span>Please input quantity</span>");
        return;
    }

    var productInfo = $("div.product-info");
    var basicParameters = productInfo.find("div.basic-parameter");
    var quoteRequestProductCustomFieldData = [];
    $.each(basicParameters, function (index, customFieldGroup) {
        var productCustomFieldRows = $(customFieldGroup).find('div.product-custom-field-row');

        $.each(productCustomFieldRows, function (index, customFieldRow) {
            var productCustomFieldColumns = $(customFieldRow).find("div.product-custom-field-col");
            $.each(productCustomFieldColumns, function (index, customFieldCol) {
               
                var productCustomFieldId = $(customFieldCol).find("input[name='productCustomFieldId']").val();
                var productCustomFieldRequestData = { ProductCustomFieldId: productCustomFieldId };

                var fieldTypeId = $(customFieldCol).find("input[name='fieldTypeId']").val();
                if (parseInt(fieldTypeId) === 1) {
                    var productCustomFieldOptionId = $(customFieldCol).find("select").val();
                    productCustomFieldRequestData.ProductCustomFieldData = productCustomFieldOptionId;
                }

                quoteRequestProductCustomFieldData.push(productCustomFieldRequestData);
            });
        });
    });


    var jsonData = JSON.stringify({
        ProductId: productId ,
        Quantity: productQuantity,
        QuoteRequestProductCustomFieldData: quoteRequestProductCustomFieldData 
    });

    $.ajax({
        type: "POST",
        url: "/api/Quote",
        contentType: dataType ,
        dataType: "json",
        data: jsonData ,
        success: function (data) {
            //alert(JSON.stringify(data));
            modalBody.html(GetQuoteDetail(data));

            var printQuote = modalBody.find("button[name='PrintQuote']");
            $(printQuote).click(function () {
                alert("建设中...");
            });

            var addToCart = modalBody.find("button[name='AddToCart']");
            $(addToCart).click(function () {
                alert("建设中...");
            });


            var checkOut = modalBody.find("button[name='CheckOut']");
            $(checkOut).click(function () {
                alert("建设中...");
            });

            console.log(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
};

function GetQuoteDetail(data) {

    var jsonData = JSON.stringify(data);

    var divHeader = "<div>Test</div>";
    var table = "<div class='table-responsive'><table class='table table-bordered'>" +
        "<thead><tr>" +
        "<th scope='col'>印品类型：</th>" +
        "<th scope ='col' >" + data.productName + 
        "</th>" +
        "<th scope='col'>报价日期：</th>" +
        "<th scope='col'>" + data.quoteDate +
        "</th>" +
        "</tr></thead><tbody>" +
        "<tr>" +
        "<th scope='row' colspan='4'>印刷要求+后加工</th>" +
        "</tr><tr>" +
        "<td scope='row' colspan='2'>成品尺寸：0.6*1.6</td>" +
        "<td scope='row' colspan='2'>后道工艺：毛品交货</td>" +
        "</tr><tr>" +
        "<td colspan='4'>总金额：￥ 1152.00</td></tr>" +
        "</tbody></table></div>";

    var divButtons = "<div style='width:100%;margin:20px 10px;text-align:center'><button type='button' name='PrintQuote' class='btn btn-success'>打印报价单</button>" +
        "<span style='padding-left:5px;'><button type='button' name='AddToCart' class='btn btn-success'>加入购物车</button></span>" +
        "<span style='padding-left:5px;'><button type='button' name='CheckOut' class='btn btn-success'>立即购买</button></span></div>";

    var divInfo = "<div class='infoy'>"+
        "<b style = 'float:left;' > 温馨提示：</b >"+
        "<ul style='clear:both'>"+
        "<li>1、此报价请提供可直接印刷的转曲pdf文件或jpg文件，如需调整/修改文件，请与前台联系。</li>" +
        "<li>2、此报价不含税，开票需另加税点（税票分2种：6%和17%），增票/普票税点相同。</li>" +
        "<li>3、此报价不含运费，可替客户代发快递和物流（收取6元/件打包费）默认顺丰和德邦到付。</li>" +
        "<li>4、自带纸/艺术纸大额报价（2千元以上）请致电业务经理争取更多优惠。</li>" +
        "<li>5、充值会员可获取更多优惠。</li>" +
        "<li>6、自提地址：南京市栖霞区马群街33号紫金工坊产业园12栋。</li>" +
    "</ul></div >";

    table = table + divButtons + divInfo;

    return table;
}