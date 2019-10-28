using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class OrderCar
    {
        public int OrderCarId { get; set; }

        public int OrderId { get; set; } // FK
        public int CarId { get; set; } // FK
        public Order Order { get; set; }
        public Car Car { get; set; }
    }
}
