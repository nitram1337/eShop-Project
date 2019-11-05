using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Concrete;
using ServiceLayer.ProductService;
using ServiceLayer.ProductService.Abstract;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryPaymentController : ControllerBase
    {
        private readonly IDeliveryPaymentDropdownService _listDeliveryPaymentservice;

        public DeliveryPaymentController(IDeliveryPaymentDropdownService listDeliveryPaymentservice)
        {
            _listDeliveryPaymentservice = listDeliveryPaymentservice;
        }

        // GET: api/DeliveryPayment/1
        [HttpGet("{option}")]
        public ActionResult<IEnumerable<DropdownTuple>> GetDeliveryPayment(DeliveryPaymentOption option)
        {
            return _listDeliveryPaymentservice.GetDeliveryPaymentDropdown(option).ToList();
        }
    }
}