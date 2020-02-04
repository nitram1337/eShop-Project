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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebShop.Helper;
using Microsoft.AspNetCore.Authorization;

namespace WebShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        #region SESSION
        public const string SessionKey = "Cart";
        #endregion

        //private readonly ILogger<IndexModel> _logger;
        private readonly IListProductService _listProductService;

        public IndexModel(/*ILogger<IndexModel> logger,*/ IListProductService listProductService)
        {
            //_logger = logger;
            _listProductService = listProductService;
        }

        public List<ProductListDto> Products { get; set; }

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
        public IActionResult OnPost(int productId)
        {
            // Tjekker om session ikke findes, hvis true, så laver den en session med en ny list, med det valgte produkt.
            if (HttpContext.Session.Get<List<SessionData>>(SessionKey) == null)
            {
                List<SessionData> nyCartSession = new List<SessionData> { new SessionData { ProductId = productId, Amount = 1 } };
                HttpContext.Session.Set(SessionKey, nyCartSession);
            }
            // Findes session, så tager den listen og tilføjer til listen og smider den i session igen.
            else
            {
                List<SessionData> cartSession = HttpContext.Session.Get<List<SessionData>>(SessionKey);
                if (cartSession.Any(a => a.ProductId == productId))
                {
                    SessionData foundProduct = cartSession.Where(a => a.ProductId == productId).FirstOrDefault();
                    foundProduct.Amount++;

                }
                else
                {
                    cartSession.Add(
                    new SessionData { ProductId = productId, Amount = 1 }
                    );
                }
                HttpContext.Session.Set(SessionKey, cartSession);
            }
            return RedirectToPage("Index");
        }
    }
}