using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Dto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebShop.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IListProductService _listProductService;
        private readonly IProductFilterDropdownService _productFilterDropdownService;

        public EditModel(IListProductService listProductService, IProductFilterDropdownService productFilterDropdownService)
        {
            _listProductService = listProductService;
            _productFilterDropdownService = productFilterDropdownService;

        }

        public ProductListDto Product { get; set; }

        [BindProperty]
        public ProductEdit EditedProduct { get; set; }

        public SelectList Brands { get; set; }
        public void OnGet(int productId)
        {
            Product = _listProductService.ViewProductById(productId);
            Brands = new SelectList(_productFilterDropdownService.GetFilterDropDownValues(ProductsFilterBy.ByBrand).OrderByDescending(a => a.Text == Product.BrandName).ToList(), "Value", "Text");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Product = _listProductService.ViewProductById(EditedProduct.Id);
                Brands = new SelectList(_productFilterDropdownService.GetFilterDropDownValues(ProductsFilterBy.ByBrand).OrderByDescending(a => a.Text == Product.BrandName).ToList(), "Value", "Text");
                return Page();

            }
            if (EditedProduct.Id > 0)
            {
                _listProductService.UpdateProduct(EditedProduct);
            }
            return RedirectToPage("/Products/Index");
        }
    }
}