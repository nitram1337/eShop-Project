using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Concrete;
using ServiceLayer.ProductService.Dto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<ProductListDto> Products { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IListProductService _listProductService;

        public IndexModel(ILogger<IndexModel> logger, IListProductService listProductService)
        {
            _logger = logger;
            _listProductService = listProductService;

        }

        public IActionResult OnGet()
        {

            // Tuples for DropDownControl i webclient
            //var blogFilterDropdownService = new ProductFilterDropdownService(context);
            //var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

            //foreach (var item in dropdownItems)
            //{
            //    Console.WriteLine("{0} - {1}", item.Value, item.Text);
            //}




            //var blogService = new ListProductService(context);
            var blogs = _listProductService.SortFilterPage(new SortFilterPageOptions
            {
                OrderByOptions = OrderByOptions.ByBrand,
                //FilterBy = ProductsFilterBy.ByBrand,
                //FilterValue = "Mercedes",

                PageNum = 1,
                PageSize = 5
            }).ToList();
            Products = blogs;
            return Page();
        }
    }
}