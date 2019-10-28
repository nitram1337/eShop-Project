using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
