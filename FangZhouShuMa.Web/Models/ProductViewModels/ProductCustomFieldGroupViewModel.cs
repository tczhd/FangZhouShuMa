﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ProductViewModels
{
    [DataContract(Name = "product_custom_field_group")]
    public class ProductCustomFieldGroupViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "product_custom_fields")]
        public List<ProductCustomFieldViewModel> ProductCustomFieldViewModels { get; set; }
    }
}