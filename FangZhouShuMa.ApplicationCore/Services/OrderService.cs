using Ardalis.GuardClauses;
using FangZhouShuMa.ApplicationCore.Entities.BasketAggregate;
using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte;
using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Entities.UserAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Specifications;
using FArdalis.GuardClauses;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace FangZhouShuMa.ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAsyncRepository<Order> _orderRepository;
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<Product> _itemRepository;
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly IAsyncRepository<SiteUser> _siteUserRepository;

        public OrderService(IAsyncRepository<Basket> basketRepository,
            IAsyncRepository<Product> itemRepository,
            IAsyncRepository<Order> orderRepository,
            IAsyncRepository<Customer> customerRepository,
            IAsyncRepository<SiteUser> siteUserRepository
            )
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _itemRepository = itemRepository;
            _customerRepository = customerRepository;
            _siteUserRepository = siteUserRepository;
        }

        public async Task<Order> CreateOrderAsync(int basketId, string userId)
        {
            
            var basket = await _basketRepository.GetByIdAsync(basketId);
            Guard.Against.NullBasket(basketId, basket);
            var items = new List<OrderProduct>();
            foreach (var item in basket.Items)
            {
                // var product = await _itemRepository.GetByIdAsync(item.ProductId);
                var itemDetails = item.ItemDetails;

                var orderItem = new OrderProduct() {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.UnitPrice,
                    SubTotal = item.Quantity * item.UnitPrice,
                    Total = item.Quantity * item.UnitPrice,
                    OrderProductCustomFieldData = itemDetails.Select(q => new OrderProductCustomFieldData {
                       ProductCustomFieldId = q.ProductCustomFieldId,
                       ProductCustomFieldName = q.ProductCustomFieldName,
                       FieldData = q.ProductCustomFieldData,
                       FieldDataDescription = q.ProductCustomFieldDataDescription,
                       Price = 0
                    }).ToList()
                };
                items.Add(orderItem);
            }

            var orderDate = DateTime.UtcNow;
            var siteUserSpecification = new SiteUserSpecification(userId);
            var customerSpecification = new CustomerSpecification(userId);
            customerSpecification.IncludeStrings.Add("Account");
            var siteUsers = await _siteUserRepository.ListAsync(siteUserSpecification);
            var customers = await _customerRepository.ListAsync(customerSpecification);
            if (siteUsers.Any() && customers.Any())
            {
                var siteUser = siteUsers.First();
                var customer = customers.First();
                var account = customer.Account;
                var subTotal = items.Sum(p => p.Quantity * p.Price);

                var order = new Order
                {
                    CustomerId = customer.Id,
                    OrderDate = orderDate,
                    LastUpdateDateUTC = orderDate,
                    AmountPaid = 0,
                    BillingInfo = new BillingInfo() {
                        Address = customer.Address,
                        City = customer.City,
                        CompanyName = account.Name,
                        CountryId = customer.CountryId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.PhoneNumber,
                        Zip = customer.Zip 
                    },
                    CreatedById = siteUser.Id,
                    OrderProducts = items,
                    ShippingInfos = new List<ShippingInfo>() {
                        new ShippingInfo(){
                        Address = customer.Address,
                        City = customer.City,
                        CountryId = customer.CountryId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber,
                        Zip = customer.Zip
                        }
                    },
                    SubTotal = subTotal,
                    Deleted = false,
                    OrderStatus = 1,
                    Total = subTotal
                };


                return await _orderRepository.AddAsync(order);
            }
            else {
                return null;
            }
        }
    }
}
