using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Concrete;
using ServiceLayer.OrderService.Dto;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Abstract;
using WebShop.Helper;

namespace WebShop.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class CheckoutModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDeliveryPaymentDropdownService _listPaymentDeliveryService;
        private readonly IListOrderService _listOrderService;
        private readonly IListProductService _listProductService;

        public CheckoutModel(IDeliveryPaymentDropdownService listPaymentDeliveryService, IListOrderService listOrderService, IListProductService listProductService, UserManager<ApplicationUser> userManager)
        {
            _listPaymentDeliveryService = listPaymentDeliveryService;
            _listOrderService = listOrderService;
            _listProductService = listProductService;
            _userManager = userManager;
        }
        
        //[BindProperty]
        //public string PaymentOption { get; set; }
        //[BindProperty]
        //public string DeliveryOption { get; set; }
        //[BindProperty]
        //public string Name { get; set; }
        //[BindProperty]
        //public string Email { get; set; }
        //[BindProperty]
        //public string Address { get; set; }

        [BindProperty]
        public OrderDto FullOrder { get; set; }


        public SelectList PaymentOptionDropdown { get; set; }
        public SelectList DeliveryOptionDropdown { get; set; }


        public void OnGet()
        {
            PaymentOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Payment).ToList(), "Value", "Text");
            DeliveryOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Delivery).ToList(), "Value", "Text");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FullOrder.Products = new List<ProductWithAmount>();

                // Bruges til at smide alle produkternes price og amount ind i
                List<ProductAmountPrice> allCartPriceAndAmount = new List<ProductAmountPrice>();

                // Tjekker at session ikke er null
                if (HttpContext.Session.Get<List<SessionData>>("Cart") != null)
                {
                    List<SessionData> sessionDatas = HttpContext.Session.Get<List<SessionData>>("Cart");
                    foreach (var sessionData in sessionDatas)
                    {
                        FullOrder.Products.Add(
                            new ProductWithAmount { ProductsId = sessionData.ProductId, Amount = sessionData.Amount }
                            );
                        allCartPriceAndAmount.Add(
                            new ProductAmountPrice
                            {
                                Price = _listProductService.ViewProductById(sessionData.ProductId).Price,
                                Amount = sessionData.Amount
                            });
                    }
                }

                FullOrder.TotalPrice = allCartPriceAndAmount.Sum(i => i.Price * i.Amount); ;
                _listOrderService.AddOrder(FullOrder, _userManager.GetUserAsync(User).Result.Id);
                HttpContext.Session.Clear();
                return RedirectToPage("Confirmed");
            }
            else
            {
                // Skal sættes igen, ellers så mister dropdowns'ne alle deres values...
                PaymentOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Payment).ToList(), "Value", "Text");
                DeliveryOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Delivery).ToList(), "Value", "Text");
                return Page();
            }
            
        }
    }
}