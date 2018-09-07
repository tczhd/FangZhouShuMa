
using System.Linq;
using FangZhouShuMa.ApplicationCore.Utilities;
using FangZhouShuMa.Infrastructure.Data.Reports.Product.Filters;
using FangZhouShuMa.Infrastructure.Interfaces.Product;

namespace FangZhouShuMa.Infrastructure.Data.Reports.Product
{
    public class ProductReport : IReport<ProductReport, ProductFilter>
    {
        public int SalesChannelId { get; set; }
        public string Name { get; set; }

        public IQueryable<ProductReport> GenerateQuery(FangZhouShuMaContext context, ProductFilter filter, Sort<ProductReport> sortBy = null)
        {
            var query = context.Products.AsQueryable();

            var result = query.Select(m => new ProductReport
            {
                SalesChannelId = m.Id,

                Name = m.Name
            });

            return result;
        }
    }
}
