using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
    public enum OrderByOptions
    {
        [Display(Name = "Sort by brand ↓...")]
        ByBrand = 0,
        [Display(Name = "Brand ↑")]
        ByBrandDesc,
        [Display(Name = "Model ↓")]
        ByModel,
        [Display(Name = "Model ↑")]
        ByModelDesc,
        [Display(Name = "Price ↓")]
        ByPrice,
        [Display(Name = "Price ↑")]
        ByPriceDesc
    }

    public static class ProductListDtoSort
    {
        public static IQueryable<ProductListDto> OrderProductsBy(this IQueryable<ProductListDto> products, OrderByOptions orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptions.ByBrand:
                    return products.OrderBy(x => x.BrandName);

                case OrderByOptions.ByBrandDesc:
                    return products.OrderByDescending(x => x.BrandName);

                case OrderByOptions.ByModel:
                    return products.OrderBy(x => x.ModelName);

                case OrderByOptions.ByModelDesc:
                    return products.OrderByDescending(x => x.ModelName);

                case OrderByOptions.ByPrice:
                    return products.OrderBy(x => x.Price);

                case OrderByOptions.ByPriceDesc:
                    return products.OrderByDescending(x => x.Price);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }
    }
}
