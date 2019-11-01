using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Dto;
using WebShop.Helper;

namespace WebShop.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly IListProductService _listProductService;

        public CartModel(IListProductService listProductService)
        {
            _listProductService = listProductService;
        }

        [BindProperty]
        public List<ProductCart> AllCartProducts { get; set; }

        public void OnGet()
        {
            // Bruges til at smide alle produkterne over i, som er taget ud fra databasen ud fra produkt id.
            List<ProductCart> allCartProducts = new List<ProductCart>();

            // Tjekker at session ikke er null
            if (HttpContext.Session.Get<List<SessionData>>("Cart") != null)
            {
                List<SessionData> sessionDatas = HttpContext.Session.Get<List<SessionData>>("Cart");
                foreach (var sessionData in sessionDatas)
                {
                    allCartProducts.Add(
                        new ProductCart { 
                        Product = _listProductService.ViewProductById(sessionData.ProductId),
                        Amount = sessionData.Amount
                        });
                }
            }

            AllCartProducts = allCartProducts;
        }
    }
}