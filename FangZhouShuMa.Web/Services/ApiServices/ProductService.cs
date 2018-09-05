using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.Web.Interfaces.ApiInterfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Services.ApiServices
{
    //public class ProductService :IProductService
    //{
    //    private readonly ILogger<HomeService> _logger;
    //    private readonly IRepository<Product> _itemRepository;
    //    private readonly IAsyncRepository<Category> _categoryRepository;
    //    //  private readonly IUriComposer _uriComposer;

    //    public HomeService(
    //        ILoggerFactory loggerFactory,
    //        IRepository<Product> itemRepository,
    //        IAsyncRepository<Category> categoryRepository
    //        //,IUriComposer uriComposer
    //        )
    //    {
    //        _logger = loggerFactory.CreateLogger<HomeService>();
    //        _itemRepository = itemRepository;
    //        _categoryRepository = categoryRepository;
    //        //_uriComposer = uriComposer;
    //    }

    //    public async Task<HomeIndexViewModel> GetHomeItems(int pageIndex, int itemsPage, int? brandId, int? groupId)
    //    {
    //        _logger.LogInformation("GetHomeItems called.");

    //        var filterSpecification = new ProductFilterSpecification(brandId, groupId);
    //        var root = _itemRepository.List(filterSpecification);

    //        var totalItems = root.Count();

    //        var itemsOnPage = root
    //            .Skip(itemsPage * pageIndex)
    //            .Take(itemsPage)
    //            .ToList();

    //        //itemsOnPage.ForEach(x =>
    //        //{
    //        //    //x.PictureUri = _uriComposer.ComposePicUri(x.PictureUri);
    //        //    x.PictureUri = x.PictureUri);
    //        //});

    //        var vm = new HomeIndexViewModel()
    //        {
    //            Items = itemsOnPage.Select(i => new ProductViewModel()
    //            {
    //                Id = i.Id,
    //                Name = i.Name,
    //                PictureUri = i.PictureUri,
    //                Description = i.Description,
    //                Price = i.Price
    //            }),
    //            Categories = await GetCategories(),
    //            PaginationInfo = new PaginationInfoViewModel()
    //            {
    //                ActualPage = pageIndex,
    //                ItemsPerPage = itemsOnPage.Count,
    //                TotalItems = totalItems,
    //                TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
    //            }
    //        };

    //        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
    //        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

    //        return vm;
    //    }
    //}
}
