using FightGearShopApp.Infrastucture.Data.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGearShopApp.Core.Contracts
{
    public interface IProductService
    {
        bool Create(string name, int brandId, int CategoryId, string picture, int quanity,
            decimal price, decimal discount);

        bool Update(int productId, string name, int brandId, int categoryId, string picture, int quanity,
            decimal price, decimal discount);

        List<Product> GetProducts();

        Product GetProductById(int productId);

        bool RemoveById(int delproductId);

        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
    }

}
