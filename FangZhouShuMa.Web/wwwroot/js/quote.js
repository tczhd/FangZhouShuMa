function PopulateAddModal() {
    // alert("Under construction....")
    var dataType = 'application/json; charset=utf-8';
    var jsonData = JSON.stringify({
        FirstName: 'Andrew',
        LastName: 'Lock',
        Age: 31
    });

    $.ajax({
        type: "POST",
        url: "/api/Quote",
        contentType: dataType ,
        dataType: "json",
        data: jsonData ,
        success: function (data) {
            alert(JSON.stringify(data));
            //$("#DIV").html('');
            //var DIV = '';
            //$.each(data, function (i, item) {
            //    var rows = "<tr>" +
            //        "<td id='RegdNo'>" + item.regNo + "</td>" +
            //        "<td id='Name'>" + item.name + "</td>" +
            //        "<td id='Address'>" + item.address + "</td>" +
            //        "<td id='PhoneNo'>" + item.phoneNo + "</td>" +
            //        "<td id='AdmissionDate'>" + Date(item.admissionDate,
            //            "dd-MM-yyyy") + "</td>" +
            //        "</tr>";
            //    $('#Table').append(rows);
            //}); //End of foreach Loop   
            console.log(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });
}