using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ProductService.Dto
{
    public class ProductEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
