using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.ProductService.Abstract
{
    public interface IListProductService
    {
        IQueryable<ProductListDto> SortFilterPage(SortFilterPageOptions options);
    }
}
