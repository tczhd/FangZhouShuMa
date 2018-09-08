using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Models.ProductReport
{
    public class ProductReportModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime ProductCreateDateUTC { get; set; }
        public DateTime ProductLastUpdateDateUTC { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProductCustomFieldId { get; set; }
        public string ProductCustomFieldName { get; set; }

        public decimal ProductCustomFieldPrice { get; set; }

        public int ProductCustomFieldFieldTypeId { get; set; }
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public decimal OptionPrice { get; set; }
        public int OptionSequence { get; set; }
    }
}
