using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{

    public interface IOrderRepository : IRepository<Order>, IAsyncRepository<Order>
    {
        Order GetByIdWithItems(int id);
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
