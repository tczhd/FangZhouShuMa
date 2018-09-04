using FangZhouShuMa.Web.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.QuoteViewModels
{
    public class QuoteViewModel
    {
        public IEnumerable<ProductViewModel> Items { get; set; }
    }
}
