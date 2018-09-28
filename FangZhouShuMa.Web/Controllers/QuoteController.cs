using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models.QuoteViewModels;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Http.Internal;

namespace FangZhouShuMa.Web.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IProductService _productService;

        public QuoteController(IProductService productService) => _productService = productService;
        public IActionResult Index(int? id)
        {
            var products = _productService.GetProductsOnly();
            var productDetails = _productService.GetAllProducts(id);
            var product = productDetails.FirstOrDefault();

            if (product != null)
            {
                var quoteViewModel = new QuoteViewModel()
                {
                    Items = products,
                    Product = product
                };

                return View(quoteViewModel);
            }

            return RedirectToAction("Error", "Home");
        }
    }
}