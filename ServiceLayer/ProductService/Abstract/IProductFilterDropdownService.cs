using ServiceLayer.ProductService.QueryObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ProductService.Abstract
{
    public interface IProductFilterDropdownService
    {
        IEnumerable<DropdownTuple> GetFilterDropDownValues(ProductsFilterBy filterBy);
    }
}
