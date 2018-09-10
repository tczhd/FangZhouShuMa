using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.QuoteViewModels
{
    public class QuoteProductCustomFieldViewModel
    {
        public int ProductCustomFieldId { get; set; }
        public string ProductCustomFieldName { get; set; }
        public int ProductCustomFieldTypeId { get; set; }
        public int? ProductCustomFieldOptionId { get; set; }
        public string ProductCustomFieldData { get; set; }
        public string ProductCustomFieldDataDescription { get; set; }
    }
}
