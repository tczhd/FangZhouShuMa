using System.Collections.Generic;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task<decimal> GetBasketItemCountAsync(string userName);
        Task TransferBasketAsync(string anonymousId, string userName);
        Task AddItemToBasket(int basketId, int productId, decimal price, decimal quantity);
        Task SetQuantities(int basketId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int basketId);
    }
}
