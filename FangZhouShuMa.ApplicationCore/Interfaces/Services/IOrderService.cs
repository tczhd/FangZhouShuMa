using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int basketId, BillingInfo billingInfo,  List<ShippingInfo> shippingInfos);
    }
}
