using FangZhouShuMa.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Api.Interfaces
{
    public interface IProductService
    {
        ProductViewModel GetProductDetail(int productId);
        List<ProductViewModel> GetAllProducts(int? productId);

        List<ProductViewModel> GetProductsOnly();
    }
}
