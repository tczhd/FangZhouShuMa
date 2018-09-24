using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
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
        public string ProductCustomFieldName { get; set; }
        public string FieldData { get; set; }
        public string FieldDataDescription { get; set; }
        public decimal Price { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
        public virtual ProductCustomField ProductCustomField { get; set; }
        public virtual ICollection<OrderProductCustomFieldOptionData>  OrderProductCustomFieldOptionData { get; set; }
    }
}
