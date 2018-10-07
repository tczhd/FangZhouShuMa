using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.Api.Models.Orders;
using FangZhouShuMa.ApplicationCore.Specifications;

namespace FangZhouShuMa.Api.V1.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository) => _orderRepository = orderRepository;

        [HttpGet]
        public IEnumerable<OrderViewModel> GetAllOrders()
        {
            var orders = _orderRepository.ListAsync(new OrdersWithItemsSpecification()).Result;

            var viewModels = orders.Select(order => new OrderViewModel()
            {
                OrderDate = order.OrderDate,
                OrderItems = order.OrderProducts?.Select(oi => new OrderItemViewModel()
                {
                    Discount = 0,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product.Name,
                    UnitPrice = oi.Price,
                    OrderItemDetails = oi.OrderProductCustomFieldData?.Select(p => new OrderItemDetailViewModel()
                    {
                        FieldData = p.FieldData,
                        FieldDataDescription = p.FieldDataDescription,
                        Price = p.Price,
                        ProductCustomFieldId = p.ProductCustomFieldId,
                        ProductCustomFieldName = p.ProductCustomFieldName
                    }).ToList()
                }).ToList(),
                OrderNumber = order.Id,

                ShippingInfos = order.ShippingInfos.Select(p => new ShippingInfoViewModel()
                {
                    Address = p.Address,
                    Address2 = p.Address2,
                    City = p.City,
                    Company = p.Company,
                    CountryId = p.CountryId,
                    Discount = p.Discount,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    LastUpdateDate = p.LastUpdateDate,
                    Notes = p.Notes,
                    PhoneNumber = p.PhoneNumber,
                    StateName = p.StateName,
                    StoreName = p.StoreName,
                    Title = p.Title,
                    Zip = p.Zip
                }).ToList(),
                Status = "Pending",
                Total = order.Total ?? 0
            }).ToList();

            return viewModels;
        }
    }
}
