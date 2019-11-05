using DataLayer;
using DataLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Dto;
using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Concrete
{
    public class ListProductService : IListProductService
    {
        private readonly EshopContext _context;

        public ListProductService(EshopContext context)
        {
            _context = context;
        }

        public IQueryable<ProductListDto> SortFilterPage(SortFilterPageOptions options)
        {
            var productsQuery = _context.Cars
                .AsNoTracking()
                .MapProductToDto()
                .OrderProductsBy(options.OrderByOptions)
                .FilterBlogsBy(options.FilterBy, options.FilterValue);
            options.SetupRestOfDto(productsQuery);                             // Added
            return productsQuery.Page(options.PageNum, options.PageSize);  // Added
        }
        public ProductListDto ViewProductById(int id)
        {
            var product = _context.Cars
                .AsNoTracking()
                .Where(a => a.CarId == id)
                .MapProductToDto()
                .FirstOrDefault();

            return product;
        }
        public ProductListDto CreateProduct(int id)
        {
            var product = _context.Cars
                .AsNoTracking()
                .Where(a => a.CarId == id)
                .MapProductToDto()
                .FirstOrDefault();

            return product;
        }

        public void UpdateProduct(ProductEdit product)
        {
            var originalProduct = _context.Cars.Where(p => p.CarId == product.Id).FirstOrDefault();
            originalProduct.BrandId = product.BrandId;
            originalProduct.ModelName = product.ModelName;
            originalProduct.Price = product.Price;
            _context.Update(originalProduct);
            _context.SaveChanges();
        }
    }
}
