using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.OrderService.Concrete;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_Customer()
        {
            // ARRANGE: Create option object with sql server
            var options = new DbContextOptionsBuilder<EshopContext>()
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = eShopDB; Trusted_Connection = True;")
                .Options;

            // ACT: Run the test against one instance of the context
            using (var context = new EshopContext(options))
            {
                var service = new ListOrderService(context);
                service.AddCustomer("Karl Olsen", "karlolsen@gmail.dk", "Strandvejen 2, Aalborg");
            }

            // ASSERT: Use a separate instance of the context to verify correct data was saved to database
            using (var context = new EshopContext(options))
            {
                Assert.IsTrue(context.Customers.Any(a => a.Email == "karlolsen@gmail.dk"));
            }
        }
    }
}
