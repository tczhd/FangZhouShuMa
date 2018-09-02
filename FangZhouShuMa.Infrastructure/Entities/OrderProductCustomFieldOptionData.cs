using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class OrderProductCustomFieldOptionData
    {
        public int OrderProductCustomFieldOptionDataId { get; set; }
        public int OrderProductCustomFieldId { get; set; }
        public int ProductCustomFieldOptionsId { get; set; }
        public decimal Price { get; set; }
        public virtual OrderProductCustomFieldData OrderProductCustomFieldData { get; set; }
    }
}
