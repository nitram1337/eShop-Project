﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DatePlaced { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal TotalPrice { get; set; }


        public int CustomerId { get; set; } // FK
        public int PaymentId { get; set; } // FK
        public int DeliveryId { get; set; } // FK
        public ICollection<OrderCar> OrderCars { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public Delivery Delivery { get; set; }
    }
}
