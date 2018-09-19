using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Models;
using FangZhouShuMa.Infrastructure.Identity;
using FangZhouShuMa.Web.Interfaces;
using FangZhouShuMa.Web.Models.BasketViewModels;
using FangZhouShuMa.Web.Models.QuoteViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FangZhouShuMa.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        //private readonly IUriComposer _uriComposer;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAppLogger<BasketController> _logger;
        private readonly IOrderService _orderService;
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketService basketService,
           IBasketViewModelService basketViewModelService,
           IOrderService orderService,
           //IUriComposer uriComposer,
           SignInManager<ApplicationUser> signInManager,
           IAppLogger<BasketController> logger)
        {
            _basketService = basketService;
          //  _uriComposer = uriComposer;
            _signInManager = signInManager;
            _logger = logger;
            _orderService = orderService;
            _basketViewModelService = basketViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var basketModel = await GetBasketViewModelAsync();

            return View(basketModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> items)
        {
            var basketViewModel = await GetBasketViewModelAsync();
            await _basketService.SetQuantities(basketViewModel.Id, items);

            return View(await GetBasketViewModelAsync());
        }


        // POST: /Basket/AddToBasket
        [HttpPost]
        public async Task<JsonResult> AddToBasket([FromBody]QuoteResultViewModel productDetails)
        {
            if (productDetails?.ProductId == null)
            {
                var error = new { success = false, message = "failed. " };
                return Json(error);
            }

            var basketViewModel = await GetBasketViewModelAsync();
            var basketItemDetailModels = new List<BasketItemDetailModel>();

            foreach (var group in productDetails.ProductCustomFieldGroups)
            {
                var productCustomDetails = group.ProductCustomFields.Select(p => new BasketItemDetailModel()
                {
                    ProductCustomFieldGroupId = group.ProductCustomFieldGroupId,
                    ProductCustomFieldGroupName = group.ProductCustomFieldGroupName,
                    ProductCustomFieldData = p.ProductCustomFieldData,
                    ProductCustomFieldDataDescription = p.ProductCustomFieldDataDescription,
                    ProductCustomFieldId = p.ProductCustomFieldId,
                    ProductCustomFieldName = p.ProductCustomFieldName,
                    ProductCustomFieldOptionId = p.ProductCustomFieldOptionId,
                    ProductCustomFieldTypeId = p.ProductCustomFieldTypeId
                }).ToList();

                basketItemDetailModels.AddRange(productCustomDetails);
            }

            await _basketService.AddItemToBasket(basketViewModel.Id, productDetails.ProductId, productDetails.QuoteUnitPrice, basketItemDetailModels, productDetails.Quantity);

            var data = new {success = true, message = "Success."};
            return Json(data);
           // return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> RedirectCheckout()
        {
            if (TempData["CheckOut"] == null || !(bool) TempData["CheckOut"])
                return RedirectToAction("Index", "Home");

            TempData.Remove("CheckOut");
            var items = new Dictionary<string, int>();
            var result = await CreateOrder(items);

            return View("Checkout");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(Dictionary<string, int> items)
        {
            var result = await CreateOrder(items);

            return View("Checkout");
        }

        private async Task<bool> CreateOrder(Dictionary<string, int> items)
        {
            try
            {
                var basketViewModel = await GetBasketViewModelAsync();
                if (basketViewModel.Items.Any())
                {

                    var user = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);

                    await _orderService.CreateOrderAsync(basketViewModel.Id, user.Id);

                    await _basketService.DeleteBasketAsync(basketViewModel.Id);

                    return true;
                }
            }
            catch (Exception wx)
            {}

            return false;
        }

        private async Task<BasketViewModel> GetBasketViewModelAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                return await _basketViewModelService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            string anonymousId = GetOrSetBasketCookie();
            return await _basketViewModelService.GetOrCreateBasketForUser(anonymousId);
        }

        private string GetOrSetBasketCookie()
        {
            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                return Request.Cookies[Constants.BASKET_COOKIENAME];
            }
            string anonymousId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Today.AddYears(10);
            Response.Cookies.Append(Constants.BASKET_COOKIENAME, anonymousId, cookieOptions);
            return anonymousId;
        }
    }
}