using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Helper;

namespace WebShop.Pages.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            int cartAmount = 0;
            if (HttpContext.Session.Get<List<SessionData>>("Cart") != null)
            {
                List<SessionData> cartSession = HttpContext.Session.Get<List<SessionData>>("Cart");

                foreach (SessionData item in cartSession)
                {
                    cartAmount += item.Amount;
                }
            }
            return View(cartAmount);
        }
    }
}
