using ServiceLayer.OrderService.Dto;
using ServiceLayer.ProductService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.OrderService.Abstract
{
    public interface IListOrderService
    {
        void AddCustomer(string name, string email, string adress);
        void AddOrder(OrderDto nyOrder, string UserId);
    }
}
