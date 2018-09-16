using Ardalis.GuardClauses;
using FangZhouShuMa.ApplicationCore.Entities.BasketAggregate;
using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FArdalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Product> _itemRepository;

        public OrderService(IAsyncRepository<Basket> basketRepository,
            IAsyncRepository<Product> itemRepository,
            IAsyncRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Order> CreateOrderAsync(int basketId, BillingInfo billingInfo, List<ShippingInfo> shippingAddress)
        {
            var basket = await _basketRepository.GetByIdAsync(basketId);
            Guard.Against.NullBasket(basketId, basket);
            var items = new List<OrderProduct>();
            foreach (var item in basket.Items)
            {
                var product = await _itemRepository.GetByIdAsync(item.ProductId);

                var orderItem = new OrderProduct();
                items.Add(orderItem);
            }
            var order = new Order(1, shippingAddress, items);

            return  await _orderRepository.AddAsync(order);
        }
    }
}
