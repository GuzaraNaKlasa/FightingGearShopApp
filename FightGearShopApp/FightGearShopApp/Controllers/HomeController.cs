using System.Diagnostics;

using FightGearShopApp.Core.Contracts;
using FightGearShopApp.Core.Services;
using FightGearShopApp.Models;
using FightGearShopApp.Models.Product;

using Microsoft.AspNetCore.Mvc;

namespace FightGearShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductIndexVM> topProducts = _productService.GetTop3Products()
                .Select(product => new ProductIndexVM
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Picture = product.Picture,
                    Price = product.Price,
                   
                }).ToList();
            return View(topProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
