using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(FangZhouShuMaContext dbContext) : base(dbContext)
        {
        }

        public Order GetByIdWithItems(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderProducts)
                .Include($"{nameof(Order.OrderProducts)}")
                .FirstOrDefault();
        }

        public Task<Order> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderProducts)
                .Include($"{nameof(Order.OrderProducts)}")
                .FirstOrDefaultAsync();
        }
    }
}
