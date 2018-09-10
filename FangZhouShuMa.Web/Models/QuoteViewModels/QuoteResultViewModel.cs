using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.QuoteViewModels
{
    public class QuoteResultViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal QuoteTotal{ get; set; }
        public DateTime QuoteDate { get; set; }
        public List<QuoteProductCustomFieldGroupViewModel> ProductCustomFieldGroups { get; set; }
    }
}
