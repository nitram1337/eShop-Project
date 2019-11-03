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
        public decimal TotalPrice { get; set; }

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
            TotalPrice = AllCartProducts.Sum(i => i.Product.Price * i.Amount);
        }

        public IActionResult OnGetDelete(int id)
        {
            List<SessionData> sessionDatas = HttpContext.Session.Get<List<SessionData>>("Cart");
            int index = Exists(sessionDatas, id);
            sessionDatas.RemoveAt(index);
            HttpContext.Session.Set<List<SessionData>>("Cart", sessionDatas);
            return RedirectToPage("Cart");
        }

        private int Exists(List<SessionData> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            List<SessionData> sessionDatas = HttpContext.Session.Get<List<SessionData>>("Cart");
            for (var i = 0; i < sessionDatas.Count; i++)
            {
                sessionDatas[i].Amount = quantities[i];
            }
            HttpContext.Session.Set<List<SessionData>>("Cart", sessionDatas);
            return RedirectToPage("Cart");
        }
    }
}