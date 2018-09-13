using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Models
{
    public class BasketItemDetailModel
    {
        public int ProductCustomFieldGroupId { get; set; }
        public string ProductCustomFieldGroupName { get; set; }

        public int ProductCustomFieldId { get; set; }
        public string ProductCustomFieldName { get; set; }
        public int ProductCustomFieldTypeId { get; set; }
        public int? ProductCustomFieldOptionId { get; set; }
        public string ProductCustomFieldData { get; set; }
        public string ProductCustomFieldDataDescription { get; set; }
    }
}
