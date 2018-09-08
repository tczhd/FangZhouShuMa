
using System;
using System.Collections.Generic;
using System.Linq;
using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using FangZhouShuMa.ApplicationCore.Models.ProductReport;
using FangZhouShuMa.ApplicationCore.Utilities;
using FangZhouShuMa.Infrastructure.Data.Reports.Product.Filters;
using FangZhouShuMa.Infrastructure.Interfaces.Product;

namespace FangZhouShuMa.Infrastructure.Data.Reports.Product
{
    public class ProductReport : IReport<ProductReport, ProductFilter>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime ProductCreateDateUTC { get; set; }
        public DateTime ProductLastUpdateDateUTC { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProductCustomFieldId { get; set; }
        public string ProductCustomFieldName { get; set; }

        public decimal ProductCustomFieldPrice { get; set; }

        public int ProductCustomFieldFieldTypeId { get; set; }
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public decimal OptionPrice { get; set; }
        public int OptionSequence { get; set; }
        public IQueryable<ProductReport> GenerateQuery(FangZhouShuMaContext context, ProductFilter filter, Sort<ProductReport> sortBy = null)
        {
            var query = from product in context.Products
                        join productCustomFieldData in context.ProductCustomFieldDatas on product.Id equals
                            productCustomFieldData.ProductId
                        join productCustomField in context.ProductCustomFields on productCustomFieldData.ProductCustomFieldId
                            equals productCustomField.Id
                        join productCustomFieldGroup in context.ProductCustomFieldGroups on productCustomField
                            .ProductCustomFieldGroupId equals productCustomFieldGroup.Id
                        join productCustomFieldOption in context.ProductCustomFieldOptions on productCustomField.Id equals
                            productCustomFieldOption.ProductCustomFieldId
                        select new { product, productCustomField, productCustomFieldGroup, productCustomFieldOption };

            var result = query.Select(m => new ProductReport
            {
                ProductId = m.product.Id,
                ProductCustomFieldId = m.productCustomField.Id,
                GroupId = m.productCustomFieldGroup.Id,
                GroupName = m.productCustomFieldGroup.Name,
                OptionId = m.productCustomFieldOption.Id,
                OptionName = m.productCustomFieldOption.Name,
                OptionPrice = m.productCustomFieldOption.Price,
                OptionSequence = m.productCustomFieldOption.Sequence,
                ProductCreateDateUTC = m.product.CreateDateUTC,
                ProductCustomFieldFieldTypeId = m.productCustomField.FieldTypeId,
                ProductCustomFieldName = m.productCustomField.Name,
                ProductCustomFieldPrice = m.productCustomField.Price,
                ProductLastUpdateDateUTC = m.product.LastUpdateDateUTC,
                ProductName = m.product.Name,
                ProductPrice = m.product.Price

            });

            return result;
        }
    }
}
