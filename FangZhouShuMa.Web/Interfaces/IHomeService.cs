using FangZhouShuMa.Web.Models.HomeViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Interfaces
{
    public interface IHomeService
    {
        Task<HomeIndexViewModel> GetHomeItems(int pageIndex, int itemsPage, int? brandId, int? groupId);
        Task<IEnumerable<SelectListItem>> GetCategories();
    }
}
