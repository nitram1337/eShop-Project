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

        public IList<ProductListDto> Products { get; set; }

        #region Ordering/Filtering/Pagination
        [BindProperty(SupportsGet = true)]
        public OrderByOptions OrderBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProductsFilterBy FilterBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterValue { get; set; }


        // Pagination (Antal sider)
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        #endregion


        public IActionResult OnGet()
        {
            SortFilterPageOptions options = new SortFilterPageOptions
            {
                OrderByOptions = OrderBy,
                FilterBy = FilterBy,
                FilterValue = FilterValue,

                PageNum = CurrentPage,
                PageSize = 2
            };

            var products = _listProductService.SortFilterPage(options).ToList();

            // Antal sider
            TotalPages = options.NumPages;
            Products = products;
            return Page();
        }
    }
}