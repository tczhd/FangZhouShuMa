using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiModels.Product
{
    [DataContract(Name = "product_custom_field_option")]
    public class ProductCustomFieldOption
    {

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
        [DataMember(Name = "sequence")]
        public int Sequence { get; set; }
    }
}
