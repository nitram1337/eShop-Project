using ServiceLayer.OrderService.Concrete;
using ServiceLayer.ProductService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.OrderService.Abstract
{
    public interface IDeliveryPaymentDropdownService
    {
        IEnumerable<DropdownTuple> GetDeliveryPaymentDropdown(DeliveryPaymentOption getOptionBy);
    }
}
