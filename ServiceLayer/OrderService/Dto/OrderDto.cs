using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.OrderService.Dto
{
    public class OrderDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int DeliveryOption { get; set; }
        [Required]
        public int PaymentOption { get; set; }
        public List<ProductWithAmount> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ProductWithAmount
    {
        public int ProductsId { get; set; }
        public int Amount { get; set; }
    }
}
