using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace FangZhouShuMa.Web.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IProductService _productService;

        public QuoteController(IProductService productService) => _productService = productService;
        public IActionResult Index(int? id)
        {
            var products = _productService.GetAllProducts();
            var product = products.SingleOrDefault(p => p.Id == id);
            return View();
        }
    }
}