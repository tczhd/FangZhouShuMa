using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>, IAsyncRepository<Product>
    {
        Product GetByIdWithItems(int id);
        Task<Product> GetByIdWithItemsAsync(int id);
    }
}
