using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>, IAsyncRepository<Product>
    {
    }
}
