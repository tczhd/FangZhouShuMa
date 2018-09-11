using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, ShippingInfo shippingInfo);
    }
}
