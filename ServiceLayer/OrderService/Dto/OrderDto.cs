using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.OrderService.Dto
{
    public class OrderDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DeliveryOption { get; set; }
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
