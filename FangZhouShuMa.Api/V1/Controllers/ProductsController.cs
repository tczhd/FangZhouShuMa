using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Api.Interfaces;
using FangZhouShuMa.Api.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FangZhouShuMa.Api.V1.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) => _productService = productService;

        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productService.GetAllProducts(null);
            return products;
        }
    }
}
