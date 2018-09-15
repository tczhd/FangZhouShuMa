using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class OrderProductCustomFieldData : BaseEntity
    {
        public OrderProductCustomFieldData()
        {
            OrderProductCustomFieldOptionData = new HashSet<OrderProductCustomFieldOptionData>();
        }
        public int OrderProductId { get; set; }
        public int ProductCustomFieldId { get; set; }
        public string FieldData { get; set; }
        public decimal Price { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
        public virtual ICollection<OrderProductCustomFieldOptionData>  OrderProductCustomFieldOptionData { get; set; }
    }
}
