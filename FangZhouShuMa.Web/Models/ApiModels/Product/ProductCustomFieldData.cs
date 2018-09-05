using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiModels.Product
{
    [DataContract(Name = "product_custom_field")]
    public class ProductCustomField
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
        [DataMember(Name = "field_type_id")]
        public int FieldTypeId { get; set; }
        [DataMember(Name = "product_custom_fields")]
        public List<ProductCustomField> ProductCustomFields { get; set; }
        [DataMember(Name = "product_custom_field_options")]
        public List<ProductCustomFieldOption> ProductCustomFieldOptions { get; set; }

    }
}
