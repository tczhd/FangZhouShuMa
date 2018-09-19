using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.OrderViewModels
{
    public class OrderItemDetailViewModel
    {
        public string FieldData { get; set; }

        public int ProductCustomFieldId { get; set; }

        public decimal Price { get; set; }
    }
}
