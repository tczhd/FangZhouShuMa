using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FangZhouShuMa.Framework.Enums;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.ApplicationCore.Interfaces.Repository;
using FangZhouShuMa.Infrastructure.Data.Repository;

namespace FangZhouShuMa.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productService.GetAllProducts(null);
            return products; 
        }
    }
}