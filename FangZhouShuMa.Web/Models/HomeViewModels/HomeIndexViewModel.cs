using FangZhouShuMa.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductViewModel> Items { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
