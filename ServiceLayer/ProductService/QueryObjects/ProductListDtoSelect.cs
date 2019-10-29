using DataLayer.Models;
using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.QueryObjects
{
    public static class ProductListDtoSelect
    {
        public static IQueryable<ProductListDto> MapProductToDto(this IQueryable<Car> cars)
        {
            return cars.Select(p => new ProductListDto
            {
                Id = p.CarId,
                BrandName = p.Brand.BrandName,
                ModelName = p.ModelName,
                PhotoPath = p.Photo.PhotoPath,
                Price = p.Price
            });
        }
    }
}
