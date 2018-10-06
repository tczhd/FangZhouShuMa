using FangZhouShuMa.Api.Interfaces;
using FangZhouShuMa.Api.Models.Products;
using FangZhouShuMa.Infrastructure.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Api.Services
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

        public List<ProductViewModel> GetProductsOnly()
        {
            _logger.LogInformation("Get all products only called.");

            var data = _productRepository.ListAll();
            var products = data.Select(m => new ProductViewModel()
            {
                CreateDateUTC = m.CreateDateUTC,
                Id = m.Id,
                Name = m.Name,
                Price = m.Price
            });

            return products.ToList();
        }

        public ProductViewModel GetProductDetail(int productId)
        {
            _logger.LogInformation("GetProductDetail called.");

            return GetAllProducts(productId).SingleOrDefault();
        }

        public List<ProductViewModel> GetAllProducts(int? productId)
        {
            _logger.LogInformation("Get all product called.");

            var data = _productRepository.GetProductDetailReportById(productId).Result;
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
                        ProductCustomFieldOptionViewModels = w.Where(e => e.OptionId > 0).Select(e => new ProductCustomFieldOptionViewModel()
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
