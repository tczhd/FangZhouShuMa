
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace FangZhouShuMa.Api.Models.Orders
{
    [DataContract(Name = "order")]
    public class OrderViewModel
    {
        [DataMember(Name = "order_number")]
        public int OrderNumber { get; set; }
        [DataMember(Name = "order_date")]

        public DateTimeOffset OrderDate { get; set; }
        [DataMember(Name = "order_total")]

        public decimal Total { get; set; }
        [DataMember(Name = "order_status")]

        public string Status { get; set; }
        [DataMember(Name = "shipping_infos")]

        public List<ShippingInfoViewModel> ShippingInfos { get; set; }
        [DataMember(Name = "order_items")]

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}
