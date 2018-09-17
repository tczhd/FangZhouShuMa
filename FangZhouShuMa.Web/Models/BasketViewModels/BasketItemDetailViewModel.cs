using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.BasketViewModels
{
    public class BasketItemDetailViewModel
    {
        public int Id { get; set; }
        public int ProductCustomFieldGroupId { get; set; }
        public string ProductCustomFieldGroupName { get; set; }

        public int ProductCustomFieldId { get; set; }
 
        public string ProductCustomFieldName { get; set; }
        public int ProductCustomFieldTypeId { get; set; }
        public int? ProductCustomFieldOptionId { get; set; }

        public string ProductCustomFieldData { get; set; }

        public string ProductCustomFieldDataDescription { get; set; }
        public decimal Price { get; set; }
    }
}
