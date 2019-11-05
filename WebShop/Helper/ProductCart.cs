using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Helper
{
    // Bruges til at display produktet, sammen med antallet af hvert produkt, i cart
    public class ProductCart
    {
        public ProductListDto Product { get; set; }
        public int Amount { get; set; }
    }
}
