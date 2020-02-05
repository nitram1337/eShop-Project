using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.OrderService.Dto
{
    public class OrderListDto
    {
        public int OrderId { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
