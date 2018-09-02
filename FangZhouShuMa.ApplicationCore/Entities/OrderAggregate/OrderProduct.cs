using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class OrderProduct : BaseEntity
    {

        public OrderProduct()
        {
            OrderProductCustomFieldData = new HashSet<OrderProductCustomFieldData>();
        }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TaxRate { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal Total { get; set; }

        public decimal DiscountTotal { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<OrderProductCustomFieldData> OrderProductCustomFieldData { get; set; }
    }
}
