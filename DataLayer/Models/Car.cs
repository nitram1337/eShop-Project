using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Price { get; set; }

        public int? PhotoId { get; set; } // FK
        public int BrandId { get; set; } // FK

        public ICollection<OrderCar> OrderCars { get; set; }
        public Photo Photo { get; set; }
        public Brand Brand { get; set; }
    }
}
