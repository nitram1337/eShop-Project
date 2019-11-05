using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Helper
{
    // Bruges til checkout, for at få alle priserne og amount og så regne TotalAmount ud
    public class ProductAmountPrice
    {
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
