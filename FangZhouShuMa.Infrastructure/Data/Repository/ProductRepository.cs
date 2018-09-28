using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces.Repository;
using FangZhouShuMa.ApplicationCore.Models.ProductReport;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Infrastructure.Data.Repository
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(FangZhouShuMaContext dbContext) : base(dbContext)
        {
        }

        public Product GetByIdWithItems(int id)
        {
            return _dbContext.Products
                .Include(o => o.ProductCustomFieldData)
                .Where(m => m.Id == id).FirstOrDefault();
        }

        public Task<Product> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Products
               .Include(o => o.ProductCustomFieldData)
               .Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<ProductReportModel>> GetProductDetailReportById(int? id)
        {
            var productQuery = _dbContext.Products.AsQueryable();
            if (id != null)
            {
                productQuery = productQuery.Where(m => m.Id == id);
            }

            var query = from product in productQuery
                        join productCustomFieldData in _dbContext.ProductCustomFieldDatas on product.Id equals
                            productCustomFieldData.ProductId
                        join productCustomField in _dbContext.ProductCustomFields on productCustomFieldData.ProductCustomFieldId
                            equals productCustomField.Id
                        join productCustomFieldGroup in _dbContext.ProductCustomFieldGroups on productCustomField
                            .ProductCustomFieldGroupId equals productCustomFieldGroup.Id
                        join productCustomFieldOption in _dbContext.ProductCustomFieldOptions on productCustomField.Id equals
                            productCustomFieldOption.ProductCustomFieldId into productCustomFieldOptionTemp
                            from productCustomFieldOption in productCustomFieldOptionTemp.DefaultIfEmpty()
                        select new { product, productCustomField, productCustomFieldGroup, productCustomFieldOption };

            var result = query.Select(m => new ProductReportModel
            {
                ProductId = m.product.Id,
                ProductCustomFieldId = m.productCustomField.Id,
                GroupId = m.productCustomFieldGroup.Id,
                GroupName = m.productCustomFieldGroup.Name,
                OptionId = (m.productCustomFieldOption != null) ?m.productCustomFieldOption.Id:0,
                OptionName = (m.productCustomFieldOption != null) ? m.productCustomFieldOption.Name:string.Empty,
                OptionPrice = (m.productCustomFieldOption != null) ? m.productCustomFieldOption.Price:0,
                OptionSequence = (m.productCustomFieldOption != null) ? m.productCustomFieldOption.Sequence:0,
                ProductCreateDateUTC = m.product.CreateDateUTC,
                ProductCustomFieldFieldTypeId = m.productCustomField.FieldTypeId,
                ProductCustomFieldName = m.productCustomField.Name,
                ProductCustomFieldPrice = m.productCustomField.Price,
                ProductLastUpdateDateUTC = m.product.LastUpdateDateUTC,
                ProductName = m.product.Name,
                ProductPrice = m.product.Price

            });


            return result.ToListAsync();
        }
    }
}
