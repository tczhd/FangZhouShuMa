using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Infrastructure.Data.Repository;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models.ApiParameters.Products;
using FangZhouShuMa.Web.Models.QuoteViewModels;
using Microsoft.Extensions.Logging;

namespace FangZhouShuMa.Web.Services.ApiServices
{
    public class QuoteService :IQuoteService
    {
        private readonly ILogger<QuoteService> _logger;
        private readonly ProductRepository _productRepository;
        private readonly IProductService _productService;

        public QuoteService(
            ILoggerFactory loggerFactory,
            ProductRepository productRepository,
            IProductService productService)
        {
            _logger = loggerFactory.CreateLogger<QuoteService>();
            _productRepository = productRepository;
            _productService = productService;
        }

        public QuoteResultViewModel Quote(QuoteRequestProductData quoteRequestProductData)
        {
            var productDetail = _productService.GetProductDetail(quoteRequestProductData.ProductId);
            var productInfo = _productRepository.GetProductDetailReportById(quoteRequestProductData.ProductId);

            foreach (var productCustomFieldData in quoteRequestProductData.QuoteRequestProductCustomFieldData)
            {
                //productCustomFieldData.
            }

            return  new QuoteResultViewModel();
        }
    }
}
