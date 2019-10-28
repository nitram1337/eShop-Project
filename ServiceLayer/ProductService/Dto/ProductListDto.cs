using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService.Dto
{
    public class ProductListDto
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}
