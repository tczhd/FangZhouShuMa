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
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository) => _productRepository = productRepository;
        // GET: api/GetAllProducts
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var data = _productRepository.GetProductDetailReportById(null).Result;
            var products = data.GroupBy(m => m.ProductId).Select(m => new ProductViewModel() {
                CreateDateUTC = m.First().ProductCreateDateUTC,
                Id = m.Key,
                LastUpdateDateUTC = m.First().ProductLastUpdateDateUTC,
                Name = m.First().ProductName,
                Price = m.First().ProductPrice,
                ProductCustomFieldGroupViewModels = m.GroupBy(q => q.GroupId).Select(q => new ProductCustomFieldGroupViewModel() {
                        Id =q.Key,
                        Name = q.First().GroupName,
                        ProductCustomFieldViewModels = q.GroupBy(w => w.ProductCustomFieldId).Select(w => new ProductCustomFieldViewModel() {
                            FieldTypeId = w.First().ProductCustomFieldFieldTypeId,
                            Id = w.Key,
                            Name = w.First().ProductCustomFieldName,
                            Price = w.First().ProductCustomFieldPrice,
                            ProductCustomFieldOptionViewModels = w.Select(e => new ProductCustomFieldOptionViewModel() {
                                Name = e.OptionName,
                                Price = e.OptionPrice,
                                Sequence = e.OptionSequence
                            }).ToList()
                        } ).ToList()

                }).ToList()
            }).ToList();

            return products; 
        }
    }
}