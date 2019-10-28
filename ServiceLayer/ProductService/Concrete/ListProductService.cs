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
            return productsQuery.Page(options.PageNum - 1, options.PageSize);  // Added
        }
    }
}
