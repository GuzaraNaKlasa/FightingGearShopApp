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
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService (ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int brandId, int CategoryId, string picture, int quanity,
            decimal price, decimal discount)
        {
            Product item = new Product
            {
                ProductName = name,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(CategoryId),

                Picture = picture,
                Quanity = quanity,
                Price = price,
                Discount = discount
            };

            _context.Products.Add(item);
            return _context.SaveChanges() != 0;

        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int delproductId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int productId, string name, int brandId, int categoryId, string picture, int quanity, decimal price, decimal discount)
        {
            throw new NotImplementedException();
        }
    }
}
