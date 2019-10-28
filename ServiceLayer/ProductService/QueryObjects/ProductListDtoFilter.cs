using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
    public enum ProductsFilterBy
    {
        [Display(Name = "All")]
        NoFilter = 0,
        [Display(Name = "By brand...")]
        ByBrand,
        [Display(Name = "By model...")]
        ByModel
    }
    public static class ProductListDtoFilter
    {
        public static IQueryable<ProductListDto> FilterBlogsBy(this IQueryable<ProductListDto> products, ProductsFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return products;

            switch (filterBy)
            {
                case ProductsFilterBy.NoFilter:
                    return products;

                case ProductsFilterBy.ByBrand:
                    return products.Where(x => x.BrandName == filterValue);

                case ProductsFilterBy.ByModel:
                    return products.Where(x => x.ModelName == filterValue);

                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }
    }
}
