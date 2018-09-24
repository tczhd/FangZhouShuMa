using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Specifications;
using Microsoft.AspNetCore.Identity;
using FangZhouShuMa.Infrastructure.Identity;
using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using FangZhouShuMa.Web.Models.OrderViewModels;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using FangZhouShuMa.Web.Models.ProductViewModels;

namespace FangZhouShuMa.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAsyncRepository<Customer> _customerRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrderController(IOrderRepository orderRepository,
              SignInManager<ApplicationUser> signInManager,
                 IAsyncRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _signInManager = signInManager;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            var customerSpecification = new CustomerSpecification(user.Id);
            var customers = await _customerRepository.ListAsync(customerSpecification);

            if (customers.Any())
            {
                var customer = customers.First();
                var orders = await _orderRepository.ListAsync(new CustomerOrdersWithItemsSpecification(customer.Id));

                var viewModel = orders
                    .Select(o => new OrderViewModel()
                    {
                        OrderDate = o.OrderDate,
                        OrderItems = o.OrderProducts?.Select(oi => new OrderItemViewModel()
                        {
                            Discount = 0,
                            ProductId = oi.ProductId,
                            //ProductName = oi.,
                            UnitPrice = oi.Price
                        }).ToList(),
                        OrderNumber = o.Id,
                        ShippingInfos = o.ShippingInfos.Select(p => new ShippingInfoViewModel()
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
                        Total = o.Total??0

                    });

                return View(viewModel);
            }

            return View(null);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Detail(int orderId)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            var customerSpecification = new CustomerSpecification(user.Id);
            var customers = await _customerRepository.ListAsync(customerSpecification);

            if (customers.Any())
            {
                var customer = customers.First();
                var customerOrders = await _orderRepository.ListAsync(new CustomerOrdersWithItemsSpecification(customer.Id));
                var order = customerOrders.FirstOrDefault(o => o.Id == orderId);
                if (order == null)
                {
                    return BadRequest("No such order found for this user.");
                }
                var viewModel = new OrderViewModel()
                {
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderProducts?.Select(oi => new OrderItemViewModel()
                    {
                        Discount = 0,
                        ProductId = oi.ProductId,
                        ProductName = oi.Product.Name,
                        UnitPrice = oi.Price,
                        OrderItemDetails = oi.OrderProductCustomFieldData.Select(p => new OrderItemDetailViewModel() {
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
                    Total = order.Total??0
                };
                return View(viewModel);
            }

            return View(null);
        }
    }
}