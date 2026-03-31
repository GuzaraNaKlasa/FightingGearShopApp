using FightGearShopApp.Core.Contracts;
using FightGearShopApp.Infrastucture.Data.Domain;
using FightGearShopApp.Models.Order;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Identity.Client;

using System.Globalization;
using System.Security.Claims;

namespace FightGearShopApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderController(IProductService productService,IOrderService orderService)
        {
            _productService = productService;
                _orderService= orderService;
        }      

        // GET: OrderController/Create
        public ActionResult Create(int id)
        {
            Product product = _productService.GetProductById(id);

            if (product == null) 
            {
                return NotFound();
            }

            OrderCreateVM order = new OrderCreateVM()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                QuantityInStock = product.Quantity,
                Price = product.Price,
                Discount = product.Discount,
                Picture = product.Picture,
            };  
            return View(order);
        }

        //POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (OrderCreateVM bindingModel) 
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = this._productService.GetProductById(bindingModel.ProductId);
            if (currentUserId==null || product==null || product.Quantity<bindingModel.Quantity || product.Quantity==0)
            {

                return RedirectToAction("Denied", "Order");

            }
            if (ModelState.IsValid)
            {
                _orderService.Create(bindingModel.ProductId, currentUserId, bindingModel.Quantity); 
            }
            ///Successfull Order
            return this.RedirectToAction("Index","Product");
        }

        /// Get:OrderController/Action Denied
        public ActionResult Denied () 
        {
            return View();
        }

        // GET: OrderController
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            List<OrderIndexVM> orders = _orderService.GetOrders()
                .Select(x=> new OrderIndexVM
                { 
                    Id = x.Id,
                    OrderDate=x.OrderDate.ToString("dd-MMM-yyyy hh:mm",CultureInfo.InvariantCulture),
                    UserId=x.UserId,
                    User=x.User.UserName,
                    ProductId=x.ProductId,
                    Product=x.Product.ProductName,
                    Picture=x.Product.Picture,
                    Quantity=x.Quanity,
                    Price=x.Price,
                    Discount=x.Discount,
                    TotalPrice=x.TotalPrice,


                }).ToList();
            return View(orders);
        }

        public ActionResult MyOrders()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<OrderIndexVM> orders = _orderService.GetOrdersByUser(currentUserId)
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM-yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ProductId = x.ProductId,
                    Product = x.Product.ProductName,
                    Picture = x.Product.Picture,
                    Quantity = x.Quanity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,


                }).ToList();

            return View(orders);
        }
    }
}
