using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.OrderService.Abstract;

namespace WebShop.Areas.Identity.Pages.Account.Manage
{
    public class OrdersModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IListOrderService _listOrderService;

        public OrdersModel(IListOrderService listOrderService, UserManager<ApplicationUser> userManager)
        {
            _listOrderService = listOrderService;
            _userManager = userManager;
        }

        public void OnGet()
        {
           var hej = _listOrderService.GetOrdersForCustomerId(_userManager.GetUserAsync(User).Result.Id);
        }
    }
}
