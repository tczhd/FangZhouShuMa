using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FangZhouShuMa.Web.Models;
using FangZhouShuMa.Web.Interfaces;

namespace FangZhouShuMa.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService) => _homeService = homeService;

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var itemsPage = 10;
            var catalogModel = await _homeService.GetHomeItems(0, itemsPage, null, null);
            return View(catalogModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "方舟标识简介.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "联系方式.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
