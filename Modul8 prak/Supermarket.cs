using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul8_prak
{
    public class Supermarket
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotal()
        {
            decimal total = products.Sum(p => p.Price);

            if (IsDiscountTime())
            {
                total *= 0.95m;
            }

            return total;
        }

        private bool IsDiscountTime()
        {
            var now = DateTime.Now;
            return now.Hour >= 8 && now.Hour < 12;
        }
    }

}
