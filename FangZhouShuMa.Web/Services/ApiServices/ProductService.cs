using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Specifications;
using FangZhouShuMa.Infrastructure.Data.Reports.Product;
using FangZhouShuMa.Infrastructure.Data.Repository;
using FangZhouShuMa.Infrastructure.Interfaces.Product;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Models.HomeViewModels;
using FangZhouShuMa.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Services.ApiServices
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly ProductRepository _productRepository;

        public ProductService(
            ILoggerFactory loggerFactory,
            ProductRepository productRepository
            )
        {
            _logger = loggerFactory.CreateLogger<ProductService>();
            _productRepository = productRepository;
        }

        public ProductViewModel GetProductDetail(int productId)
        {
            _logger.LogInformation("GetProductDetail called.");

            return  GetAllProducts().SingleOrDefault(o => o.Id == productId);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            _logger.LogInformation("Get all product called.");

            var data = _productRepository.GetProductDetailReportById(null).Result;
            var products = data.GroupBy(m => m.ProductId).Select(m => new ProductViewModel()
            {
                CreateDateUTC = m.First().ProductCreateDateUTC,
                Id = m.Key,
                LastUpdateDateUTC = m.First().ProductLastUpdateDateUTC,
                Name = m.First().ProductName,
                Price = m.First().ProductPrice,
                ProductCustomFieldGroupViewModels = m.GroupBy(q => q.GroupId).Select(q => new ProductCustomFieldGroupViewModel()
                {
                    Id = q.Key,
                    Name = q.First().GroupName,
                    ProductCustomFieldViewModels = q.GroupBy(w => w.ProductCustomFieldId).Select(w => new ProductCustomFieldViewModel()
                    {
                        FieldTypeId = w.First().ProductCustomFieldFieldTypeId,
                        Id = w.Key,
                        Name = w.First().ProductCustomFieldName,
                        Price = w.First().ProductCustomFieldPrice,
                        ProductCustomFieldOptionViewModels = w.Select(e => new ProductCustomFieldOptionViewModel()
                        {
                            ProductCustomFieldOptionId = e.OptionId,
                            Name = e.OptionName,
                            Price = e.OptionPrice,
                            Sequence = e.OptionSequence
                        }).ToList()
                    }).ToList()

                }).ToList()
            });

            return products.ToList();
        }
    }
}
