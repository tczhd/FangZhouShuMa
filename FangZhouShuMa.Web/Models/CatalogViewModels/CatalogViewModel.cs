using FangZhouShuMa.Web.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.CatalogViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductViewModel> Items { get; set; }

    }
}
