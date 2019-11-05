using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Abstract;
using ServiceLayer.ProductService.Dto;
using ServiceLayer.ProductService.QueryObjects;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IListProductService _listProductService;

        public ProductsController(IListProductService listProductService)
        {
            _listProductService = listProductService;
        }

        // GET: api/Products/1
        [HttpGet("{id}")]
        public ActionResult<ProductListDto> GetProduct(int id)
        {
            return _listProductService.ViewProductById(id);
        }


        // GET: api/Products/ByModel/1
        [HttpGet("{orderBy}/{currentPage}")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProducts(OrderByOptions orderBy, int currentPage)
        {
            SortFilterPageOptions options = new SortFilterPageOptions
            {
                OrderByOptions = orderBy,
                FilterBy = ProductsFilterBy.NoFilter,
                FilterValue = "",

                PageNum = currentPage,
                PageSize = 2
            };

            return await _listProductService.SortFilterPage(options).ToListAsync();
        }

        // GET: api/Products/ByModel/ByModel/3/1
        [HttpGet("{orderBy}/{filterBy}/{filterValue}/{currentPage}")]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProducts(OrderByOptions orderBy, ProductsFilterBy filterBy, string filterValue, int currentPage)
        {  
            SortFilterPageOptions options = new SortFilterPageOptions
            {
                OrderByOptions = orderBy,
                FilterBy = filterBy,
                FilterValue = filterValue,

                PageNum = currentPage,
                PageSize = 2
            };

            return await _listProductService.SortFilterPage(options).ToListAsync();
        }

        // PUT: api/Products
        [HttpPut]
        public IActionResult PutProduct(ProductEdit editedProduct)
        {
            if (editedProduct == null)
            {
                return BadRequest();
            }
            else
            {
                _listProductService.UpdateProduct(editedProduct);
                return NoContent();
            }
        }
    }
}