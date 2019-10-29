using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Dto;

namespace WebShop.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public ProductListDto Product { get; set; }

        private readonly IListProductService _listProductService;

        public DetailsModel(IListProductService listProductService)
        {
            _listProductService = listProductService;

        }
        public IActionResult OnGet(int productId)
        {
            
                Product = _listProductService.ViewProductById(productId);
            return Page();
        }
    }
}