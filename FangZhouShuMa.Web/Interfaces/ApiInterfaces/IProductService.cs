using FangZhouShuMa.Web.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Interfaces.ApiInterfaces
{
    public interface IProductService
    {
        Task<ProductViewModel> GetProductDetail();
    }
}
