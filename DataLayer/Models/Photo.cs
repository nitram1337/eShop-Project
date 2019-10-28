using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoPath { get; set; }

        public int? CarId { get; set; } // FK
        public Car Car { get; set; }
    }
}
