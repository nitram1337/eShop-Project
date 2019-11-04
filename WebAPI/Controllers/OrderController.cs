using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IListOrderService _listOrderService;

        public OrderController(IListOrderService listOrderService)
        {
            _listOrderService = listOrderService;
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult PostOrder(OrderDto order)
        {
            _listOrderService.AddOrder(order);
            return NoContent();
        }
    }
}