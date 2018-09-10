using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.QuoteViewModels
{
    public class QuoteProductCustomFieldGroupViewModel
    {
        public int ProductCustomFieldGroupId { get; set; }
        public int ProductCustomFieldGroupName { get; set; }
        public List<QuoteProductCustomFieldViewModel> ProductCustomFields { get; set; }
    }
}
