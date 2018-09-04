using FangZhouShuMa.ApplicationCore.Entities.ProductAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Specifications;
using FangZhouShuMa.Web.Interfaces;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Models.HomeViewModels;
using FangZhouShuMa.Web.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Services
{
    public class HomeService : IHomeService
    {
        private readonly ILogger<HomeService> _logger;
        private readonly IRepository<Product> _itemRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
      //  private readonly IUriComposer _uriComposer;

        public HomeService(
            ILoggerFactory loggerFactory,
            IRepository<Product> itemRepository,
            IAsyncRepository<Category> categoryRepository
            //,IUriComposer uriComposer
            )
        {
            _logger = loggerFactory.CreateLogger<HomeService>();
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;
            //_uriComposer = uriComposer;
        }

        public async Task<HomeIndexViewModel> GetHomeItems(int pageIndex, int itemsPage, int? brandId, int? groupId)
        {
            _logger.LogInformation("GetHomeItems called.");

            var filterSpecification = new ProductFilterSpecification(brandId, groupId);
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root
                .Skip(itemsPage * pageIndex)
                .Take(itemsPage)
                .ToList();

            //itemsOnPage.ForEach(x =>
            //{
            //    //x.PictureUri = _uriComposer.ComposePicUri(x.PictureUri);
            //    x.PictureUri = x.PictureUri);
            //});

            var vm = new HomeIndexViewModel()
            {
                Items = itemsOnPage.Select(i => new ProductViewModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    PictureUri = i.PictureUri,
                    Description = i.Description,
                    Price = i.Price
                }),
                Categories = await GetCategories(),
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            _logger.LogInformation("GetCategoriess called.");
            var categories = await _categoryRepository.ListAllAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Category category in categories)
            {
                items.Add(new SelectListItem() { Value = category.Id.ToString(), Text =  category.Name });
            }

            return items;
        }

        //public async Task<IEnumerable<SelectListItem>> GetTypes()
        //{
        //    _logger.LogInformation("GetTypes called.");
        //    var types = await _typeRepository.ListAllAsync();
        //    var items = new List<SelectListItem>
        //    {
        //        new SelectListItem() { Value = null, Text = "All", Selected = true }
        //    };
        //    foreach (CatalogType type in types)
        //    {
        //        items.Add(new SelectListItem() { Value = type.Id.ToString(), Text = type.Type });
        //    }

        //    return items;
        //}
    }
}
