using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class OrderProductCustomFieldData
    {
        public OrderProductCustomFieldData()
        {
            OrderProductCustomFieldOptionData = new HashSet<OrderProductCustomFieldOptionData>();
        }
        public int OrderProductCustomFieldDataId { get; set; }
        public int OrderProductId { get; set; }
        public int OrderProductCustomFieldId { get; set; }
        public string FieldData { get; set; }
        public decimal Price { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
        public virtual ICollection<OrderProductCustomFieldOptionData>  OrderProductCustomFieldOptionData { get; set; }
    }
}
