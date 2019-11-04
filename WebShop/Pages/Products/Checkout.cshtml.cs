using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Concrete;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Abstract;

namespace WebShop.Pages.Products
{
    public class CheckoutModel : PageModel
    {
        private readonly IDeliveryPaymentDropdownService _listPaymentDeliveryService;
        private readonly IListOrderService _listOrderService;

        public CheckoutModel(IDeliveryPaymentDropdownService listPaymentDeliveryService, IListOrderService listOrderService)
        {
            _listPaymentDeliveryService = listPaymentDeliveryService;
            _listOrderService = listOrderService;
        }

        [BindProperty]
        public string PaymentOption { get; set; }
        [BindProperty]
        public string DeliveryOption { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Address { get; set; }

        public SelectList PaymentOptionDropdown { get; set; }
        public SelectList DeliveryOptionDropdown { get; set; }


        public void OnGet()
        {
            PaymentOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Payment).ToList(), "Value", "Text");
            DeliveryOptionDropdown = new SelectList(_listPaymentDeliveryService.GetDeliveryPaymentDropdown(DeliveryPaymentOption.Delivery).ToList(), "Value", "Text");
        }

        public void OnPost()
        {
            //_listOrderService.AddOrder("navntest","emailtest","addressetest");
        }
    }
}