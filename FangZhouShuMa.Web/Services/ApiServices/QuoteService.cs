using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Framework.Enums;
using FangZhouShuMa.Infrastructure.Data.Repository;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models.ApiParameters.Products;
using FangZhouShuMa.Web.Models.QuoteViewModels;
using Microsoft.AspNetCore.ResponseCaching.Internal;
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

            var quotePrice = productDetail.Price;
            var result = new QuoteResultViewModel()
            {
                ProductId = productDetail.Id,
                ProductName = productDetail.Name,
                QuoteDate = DateTime.UtcNow,
                ProductCustomFieldGroups = new List<QuoteProductCustomFieldGroupViewModel>()
            };

            foreach (var productCustomFieldGroup in productDetail.ProductCustomFieldGroupViewModels)
            {
                var group = new QuoteProductCustomFieldGroupViewModel()
                {
                    ProductCustomFieldGroupId = productCustomFieldGroup.Id,
                    ProductCustomFieldGroupName = productCustomFieldGroup.Name,
                    ProductCustomFields = new List<QuoteProductCustomFieldViewModel>()
                };

                result.ProductCustomFieldGroups.Add(group);

                foreach (var productCustomField in productCustomFieldGroup.ProductCustomFieldViewModels)
                {
                    var productCustomFieldRequest =
                        quoteRequestProductData.QuoteRequestProductCustomFieldData.SingleOrDefault(p =>p.ProductCustomFieldId == productCustomField.Id);

                    if (productCustomFieldRequest != null)
                    {
                        quotePrice += productCustomField.Price;

                        var quoteProductCustomFieldViewModel = new QuoteProductCustomFieldViewModel()
                        {
                            ProductCustomFieldId = productCustomField.Id,
                            ProductCustomFieldName = productCustomField.Name,
                            
                        };

                        switch (productCustomField.FieldTypeId)
                        {
                            case (int)ProductCustomFieldType.DropDown:
                                var optionId = int.Parse(productCustomFieldRequest.ProductCustomFieldData);

                                var option =
                                    productCustomField.ProductCustomFieldOptionViewModels.SingleOrDefault(p =>
                                        p.ProductCustomFieldOptionId == optionId);
                                if (option != null)
                                {
                                    quotePrice += option.Price;

                                    quoteProductCustomFieldViewModel.ProductCustomFieldData =
                                        productCustomFieldRequest.ProductCustomFieldData;
                                    quoteProductCustomFieldViewModel.ProductCustomFieldDataDescription = option.Name;
                                    quoteProductCustomFieldViewModel.ProductCustomFieldTypeId =
                                        productCustomField.FieldTypeId;

                                    group.ProductCustomFields.Add(quoteProductCustomFieldViewModel);
                                }

                                break;
                        }
                    }
                }
            }

            result.QuoteTotal = quotePrice * quoteRequestProductData.Quantity;

            return result;
        }
    }
}
