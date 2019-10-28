using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.OrderService.Concrete
{
    public class ListOrderService
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
    }
}
