using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.OrderService.Abstract;
using ServiceLayer.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.OrderService.Concrete
{
    public class ListOrderService : IListOrderService
    {
        // Dependency Injection of Context
        private readonly EshopContext _context;
        public ListOrderService(EshopContext context)
        {
            _context = context;
        }

        public void AddCustomer(string name, string email, string adress)
        {
            Customer customer = new Customer { Name = name, Email = email, Address = adress };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        public void AddOrder(OrderDto nyOrder, string UserId)
        {
            var foundUser = _context.ApplicationUsers.Include(T => T.Orders).FirstOrDefault(T => T.Id == UserId);
            Customer customer = new Customer {
                Name = nyOrder.Name,
                Email = nyOrder.Email,
                Address = nyOrder.Address

            };
            Order newOrder = new Order {
                PaymentId = nyOrder.PaymentOption,
                DeliveryId = nyOrder.DeliveryOption,
                DatePlaced = DateTime.Now,
                TotalPrice = nyOrder.TotalPrice 
            };
            newOrder.OrderCars = new List<OrderCar>();

            foreach (ProductWithAmount product in nyOrder.Products)
            {
                //newOrder.OrderCars.Add(new OrderCar { OrderId = newOrder.OrderId, CarId = product.ProductsId, Amount = product.Amount });
                newOrder.OrderCars.Add(new OrderCar { CarId = product.ProductsId, Amount = product.Amount });
            }

            //customer.Orders = new List<Order> { newOrder };
            foundUser.Orders.Add(newOrder);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
