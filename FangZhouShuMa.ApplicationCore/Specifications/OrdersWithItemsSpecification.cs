using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class OrdersWithItemsSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsSpecification(): base(o => o.Deleted == false)
        {
            AddInclude(o => o.OrderProducts);
            AddInclude(o => o.ShippingInfos);
            AddInclude($"{nameof(Order.OrderProducts)}.{nameof(OrderProduct.OrderProductCustomFieldData)}");
        }
    }
}
