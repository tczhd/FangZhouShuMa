﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.Api.Models.Orders
{
    [DataContract(Name = "order_product")]
    public class OrderItemViewModel
    {
        [DataMember(Name = "product_id")]
        public int ProductId { get; set; }
        [DataMember(Name = "product_name")]
        public string ProductName { get; set; }
        [DataMember(Name = "price")]
        public decimal UnitPrice { get; set; }
        [DataMember(Name = "discount")]
        public decimal Discount { get; set; }
        [DataMember(Name = "units")]
        public int Units { get; set; }
        [DataMember(Name = "picture_url")]
        public string PictureUrl { get; set; }
        [DataMember(Name = "order_item_details")]
        public List<OrderItemDetailViewModel> OrderItemDetails { get; set; }
    }
}
