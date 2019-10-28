using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EshopContext : DbContext
    {
        // Brugt til, så ConsoleApp kunne kører
        //public EshopContext() 
        //{ }

        public EshopContext(DbContextOptions<EshopContext> options)
        : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = eShopDB; Trusted_Connection = True; ");

            //optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BookStoreDb; Trusted_Connection = True; ")
            //.EnableSensitiveDataLogging(true)
            //.UseLoggerFactory(new ServiceCollection()
            //.AddLogging(builder => builder.AddConsole()
            //    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
            //    .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
            .HasOne(p => p.Customer)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Order>()
            .HasOne(p => p.Payment)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.PaymentId);

            modelBuilder.Entity<Order>()
            .HasOne(p => p.Delivery)
            .WithMany(b => b.Orders)
            .HasForeignKey(p => p.DeliveryId);


            modelBuilder.Entity<OrderCar>()
            .HasOne(p => p.Order)
            .WithMany(b => b.OrderCars)
            .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<OrderCar>()
            .HasOne(p => p.Car)
            .WithMany(b => b.OrderCars)
            .HasForeignKey(p => p.CarId);

            modelBuilder.Entity<Car>()
            .HasOne(p => p.Brand)
            .WithMany(b => b.Cars)
            .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Car>()
            .HasOne(p => p.Photo)
            .WithOne(i => i.Car)
            .HasForeignKey<Photo>(b => b.CarId);


            modelBuilder.Entity<Brand>().HasData(
                new Brand() { BrandId = 1, BrandName = "BMW" },
                new Brand() { BrandId = 2, BrandName = "Volvo" },
                new Brand() { BrandId = 3, BrandName = "Mercedes" }
                );
            modelBuilder.Entity<Photo>().HasData(
                new Photo() { PhotoId = 1, PhotoPath = "Photo320I", CarId = 1 },
                new Photo() { PhotoId = 2, PhotoPath = "PhotoV40", CarId = 2 },
                new Photo() { PhotoId = 3, PhotoPath = "PhotoE220", CarId = 3 }
                );
            modelBuilder.Entity<Car>().HasData(
                new Car() { CarId = 1, ModelName = "320I", Price = 420000, PhotoId = 1, BrandId = 1 },
                new Car() { CarId = 2, ModelName = "V40", Price = 304000, PhotoId = 2, BrandId = 2 },
                new Car() { CarId = 3, ModelName = "E220", Price = 650000, PhotoId = 3, BrandId = 3 },
                new Car() { CarId = 4, ModelName = "M5", Price = 2500000, PhotoId = null, BrandId = 1 },
                new Car() { CarId = 5, ModelName = "XC90", Price = 1060000, PhotoId = null, BrandId = 2 },
                new Car() { CarId = 6, ModelName = "E63S", Price = 2700000, PhotoId = null, BrandId = 3 }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { CustomerId = 1, Name = "Karl", Email = "karl@mail.dk", Address = "Æblevej 4, København" },
                new Customer() { CustomerId = 2, Name = "Bent", Email = "bent@mail.dk", Address = "Nørregade 81, Odense"}
                );
            modelBuilder.Entity<Payment>().HasData(
                new Payment() { PaymentId = 1, PaymentOption = "Kortbetaling"},
                new Payment() { PaymentId = 2, PaymentOption = "PayPal" },
                new Payment() { PaymentId = 3, PaymentOption = "MobilePay" }
                );
            modelBuilder.Entity<Delivery>().HasData(
                new Delivery() { DeliveryId = 1, DeliveryOption = "PostNord - Pakkeshop"},
                new Delivery() { DeliveryId = 2, DeliveryOption = "GLS - Til døren"}
                );
            modelBuilder.Entity<Order>().HasData(
                new Order() { OrderId = 1, DatePlaced = DateTime.Now, TotalPrice = 2920000, CustomerId = 1, PaymentId = 2, DeliveryId = 1},
                new Order() { OrderId = 2, DatePlaced = DateTime.Now, TotalPrice = 1364000, CustomerId = 2, PaymentId = 3, DeliveryId = 2}
                );
            modelBuilder.Entity<OrderCar>().HasData(
                new OrderCar() { OrderCarId = 1, OrderId = 1, CarId = 1 },
                new OrderCar() { OrderCarId = 2, OrderId = 2, CarId = 2 },
                new OrderCar() { OrderCarId = 3, OrderId = 1, CarId = 4 },
                new OrderCar() { OrderCarId = 4, OrderId = 2, CarId = 5 }
                );
        }
    }
}
