using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string DeliveryOption { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
