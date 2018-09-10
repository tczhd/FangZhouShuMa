using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Infrastructure.Data.Repository;
using FangZhouShuMa.Web.Models.ApiParameters.Products;
using FangZhouShuMa.Web.Models.QuoteViewModels;
using Microsoft.Extensions.Logging;

namespace FangZhouShuMa.Web.Services.ApiServices
{
    public class QuoteService
    {
        private readonly ILogger<QuoteService> _logger;
        private readonly ProductRepository _productRepository;

        public QuoteService(
            ILoggerFactory loggerFactory,
            ProductRepository productRepository)
        {
            _logger = loggerFactory.CreateLogger<QuoteService>();
            _productRepository = productRepository;
        }

        public QuoteResultViewModel Quote(QuoteRequestProductData quoteRequestProductData)
        {
            var productInfo = _productRepository.GetProductDetailReportById(quoteRequestProductData.ProductId);

            return  new QuoteResultViewModel();
        }
    }
}
