﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ProductViewModels
{
    public class ProductViewModel
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "picture_uri")]
        public string PictureUri { get; set; }
        [DataMember(Name = "price")]
        public decimal Price { get; set; }
        [DataMember(Name = "create_date_utc")]
        public DateTime CreateDateUTC { get; set; }
        [DataMember(Name = "last_update_utc")]
        public DateTime LastUpdateDateUTC { get; set; }
        [DataMember(Name = "product_custom_field_groups")]
        public List<ProductCustomFieldGroupViewModel> ProductCustomFieldGroupViewModels { get; set; }
    }
}
