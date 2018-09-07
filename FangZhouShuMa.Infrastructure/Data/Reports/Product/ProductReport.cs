
using System;
using System.Collections.Generic;
using System.Linq;
using FangZhouShuMa.ApplicationCore.Models.ProductReport;
using FangZhouShuMa.ApplicationCore.Utilities;
using FangZhouShuMa.Infrastructure.Data.Reports.Product.Filters;
using FangZhouShuMa.Infrastructure.Interfaces.Product;

namespace FangZhouShuMa.Infrastructure.Data.Reports.Product
{
    public class ProductReport :  IReport<ProductReport, ProductFilter>
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
            var query = context.Products.AsQueryable();

            var result = query.Select(m => new ProductReport
            {
                ProductId = m.Id,


            });

            return result;
        }
    }
}
