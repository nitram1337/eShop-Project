using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public class ProductFilterDropdownService
    {
        private readonly EshopContext _db;

        public ProductFilterDropdownService(EshopContext db)
        {
            _db = db;
        }

        public IEnumerable<DropdownTuple> GetFilterDropDownValues(ProductsFilterBy filterBy)
        {
            switch (filterBy)
            {
                case ProductsFilterBy.NoFilter:
                    return new List<DropdownTuple>();

                case ProductsFilterBy.ByBrand:
                    var result = _db.Brands
                        .OrderBy(x => x.BrandName)
                        .Select(x => new DropdownTuple
                        {
                            Value = x.BrandId.ToString(),
                            Text = x.BrandName
                        }).ToList();
                    return result;

                // TODO: Maybe unødvendigt
                case ProductsFilterBy.ByModel:
                    var result2 = _db.Cars
                    .OrderBy(x => x.ModelName)
                    .Select(x => new DropdownTuple
                    {
                        Value = x.ModelName.ToString(),
                        Text = x.ModelName
                    }).ToList();
                    return result2;

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
