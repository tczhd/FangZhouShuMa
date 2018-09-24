using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.OrderViewModels
{
    public class OrderItemDetailViewModel
    {
        [DataMember(Name = "product_custom_field_data")]
        public string FieldData { get; set; }
        [DataMember(Name = "product_custom_field_data_description")]
        public string FieldDataDescription { get; set; }
        [DataMember(Name = "product_custom_field_id")]
        public int ProductCustomFieldId { get; set; }
        [DataMember(Name = "product_custom_field_name")]
        public string ProductCustomFieldName { get; set; }
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
    }
}
