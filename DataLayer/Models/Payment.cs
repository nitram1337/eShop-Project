using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentOption { get; set; }

        public ICollection<Order> Orders { get; set; } 

    }
}
