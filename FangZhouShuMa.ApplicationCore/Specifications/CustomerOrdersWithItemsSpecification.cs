using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class CustomerOrdersWithItemsSpecification : BaseSpecification<Order>
    {
        public CustomerOrdersWithItemsSpecification(int customerId)
            : base(o => o.CustomerId == customerId)
        {
            AddInclude(o => o.OrderProducts);
            AddInclude(o => o.ShippingInfos);
            AddInclude($"{nameof(Order.OrderProducts)}.{nameof(OrderProduct.OrderProductCustomFieldData)}");
            AddInclude($"{nameof(Order.OrderProducts)}.{nameof(OrderProduct.Product)}");
        }
    }
}
