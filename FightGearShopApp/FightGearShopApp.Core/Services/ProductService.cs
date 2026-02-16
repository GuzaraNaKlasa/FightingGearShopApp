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
            return _context.Products.Find(productId);

        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        public List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName)
        {
          List <Product> products = _context.Products.ToList();

            if (!string.IsNullOrEmpty(searchStringCategoryName)
                && !string.IsNullOrEmpty(searchStringBrandName))
            {
                products =products.Where(x => x.Category.CategoryName.ToLower()
                .Contains (searchStringBrandName.ToLower())).ToList();

            }
            return products;

        }

        public bool RemoveById(int productId)
        {
            var product=GetProductById(productId);
            if (product == default(Product))
            {
                return false;
            }
            _context.Remove(product);
            return _context.SaveChanges() !=0;
        }
        

        public bool Update(int productId, string name, int brandId, int categoryId, string picture, int quanity,
            decimal price, decimal discount)
        {
            var product =GetProductById(productId);
            if (product ==default(Product))
            {
                return false;
            }
            product.ProductName=name;

            // product.BrandId=brandId;
            // product.CategoryId=categoryId;

            product.Brand = _context.Brands.Find(brandId);
            product.Category=_context.Categories.Find(categoryId);

            product.Picture=picture;
            product.Quanity=quanity;
            product.Price=price;
            product.Discount=discount;
            _context.Update(product);
            return _context.SaveChanges() !=0;

        }
    }
}
