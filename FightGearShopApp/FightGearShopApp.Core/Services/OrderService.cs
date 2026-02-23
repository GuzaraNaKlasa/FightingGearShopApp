using FightGearShopApp.Core.Contracts;
using FightGearShopApp.Infrastucture.Data;
using FightGearShopApp.Infrastucture.Data.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGearShopApp.Core.Services
{

    public class OrderService : IOrderService

    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;

    



    public OrderService(ApplicationDbContext context, IProductService productService)

        {
            _context = context;
            _productService = productService;
        }
        public bool Create(int productId, string userId, int quantity)
        {
            var product = this._context.Products.SingleOrDefault
                (x => x.Id == productId);

            if (product == null)
            {
                return false;
            }

            Order item = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productId,
                UserId = userId,
                Quanity = quantity,
                Price = product.Price,
                Discount = product.Discount,
            };
            //-minus product
            product.Quantity -= quantity;
            //changes in collection
            this._context.Products.Update(product);
            this._context.Orders.Add(item);
            ///SAVE in DB
            return _context.SaveChanges() !=0;

        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}