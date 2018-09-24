using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Specifications;
using FangZhouShuMa.Web.Models.OrderViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace FangZhouShuMa.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderApiController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApiController(IOrderRepository orderRepository) =>  _orderRepository = orderRepository;

        [HttpGet]
        public  IEnumerable<OrderViewModel> GetAllOrders()
        {
            var orders =  _orderRepository.ListAsync(new OrdersWithItemsSpecification()).Result;

            var viewModels = orders .Select(order => new OrderViewModel()
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

               ShippingInfos = order.ShippingInfos.Select(p => new ShippingInfoViewModel() {
                   Address=p.Address,
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
               }) .ToList(),
                Status = "Pending",
                Total = order.Total ?? 0
            }).ToList();

            return viewModels;
        }
    }
}