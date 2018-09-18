using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.OrderViewModels
{
    public class OrderViewModel
    {
        public int OrderNumber { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }

        public List<ShippingInfo> ShippingAddresses { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}
