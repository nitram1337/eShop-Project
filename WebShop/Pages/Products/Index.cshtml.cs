using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ILogger<IndexModel> _logger;
        private readonly IListProductService _listProductService;

        public IndexModel(ILogger<IndexModel> logger, IListProductService listProductService)
        {
            _logger = logger;
            _listProductService = listProductService;
        }

        public List<ProductListDto> Products { get; set; }

        #region Ordering/Filtering
        [BindProperty(SupportsGet = true)]
        public OrderByOptions OrderBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProductsFilterBy FilterBy { get; set; }
        #endregion


        public IActionResult OnGet()
        {
            // Tuples for DropDownControl i webclient
            //var blogFilterDropdownService = new ProductFilterDropdownService(context);
            //var dropdownItems = blogFilterDropdownService.GetFilterDropDownValues(BlogsFilterBy.ByOwner).ToList();

            //foreach (var item in dropdownItems)
            //{
            //    Console.WriteLine("{0} - {1}", item.Value, item.Text);
            //}


            List<ProductListDto> products = _listProductService.SortFilterPage(new SortFilterPageOptions
            {
                OrderByOptions = OrderBy,
                FilterBy = FilterBy,
                FilterValue = "320I",

                PageNum = 1,
                PageSize = 10
            }).ToList();
            Products = products;
            return Page();
        }
    }
}