using FangZhouShuMa.Web.Models.HomeViewModels;
using FangZhouShuMa.Web.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Interfaces.ApiInterfaces
{
    public interface IProductService
    {
        ProductViewModel GetProductDetail(int productId);
        List<ProductViewModel> GetAllProducts();
    }
}
