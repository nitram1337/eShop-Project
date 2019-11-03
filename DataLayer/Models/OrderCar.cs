using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class OrderCar
    {
        public int OrderId { get; set; } // FK
        public int CarId { get; set; } // FK
        public int Amount { get; set; }
        public Order Order { get; set; }
        public Car Car { get; set; }
    }
}
