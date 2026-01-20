using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FightGearShopApp.Infrastucture.Data.Domain
{
    internal class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]

        public string ProductName { get; set; } = null!;

        [Required]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public string Picture { get; set; } = null!;

        [Range(0, 5000)]
        public int Quanity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
