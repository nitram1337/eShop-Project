﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EshopContext))]
    [Migration("20191017174030_EditPhoto")]
    partial class EditPhoto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            BrandName = "BMW"
                        },
                        new
                        {
                            BrandId = 2,
                            BrandName = "Volvo"
                        },
                        new
                        {
                            BrandId = 3,
                            BrandName = "Mercedes"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(15, 2)");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.ToTable("Car");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            BrandId = 1,
                            ModelName = "320I",
                            PhotoId = 1,
                            Price = 420000m
                        },
                        new
                        {
                            CarId = 2,
                            BrandId = 2,
                            ModelName = "V40",
                            PhotoId = 2,
                            Price = 304000m
                        },
                        new
                        {
                            CarId = 3,
                            BrandId = 3,
                            ModelName = "E220",
                            PhotoId = 3,
                            Price = 650000m
                        },
                        new
                        {
                            CarId = 4,
                            BrandId = 1,
                            ModelName = "M5",
                            Price = 2500000m
                        },
                        new
                        {
                            CarId = 5,
                            BrandId = 2,
                            ModelName = "XC90",
                            Price = 1060000m
                        },
                        new
                        {
                            CarId = 6,
                            BrandId = 3,
                            ModelName = "E63S",
                            Price = 2700000m
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "Æblevej 4, København",
                            Email = "karl@mail.dk",
                            Name = "Karl"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "Nørregade 81, Odense",
                            Email = "bent@mail.dk",
                            Name = "Bent"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeliveryOption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryId");

                    b.ToTable("Delivery");

                    b.HasData(
                        new
                        {
                            DeliveryId = 1,
                            DeliveryOption = "PostNord - Pakkeshop"
                        },
                        new
                        {
                            DeliveryId = 2,
                            DeliveryOption = "GLS - Til døren"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePlaced")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(15, 2)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            DatePlaced = new DateTime(2019, 10, 17, 19, 40, 30, 419, DateTimeKind.Local).AddTicks(1822),
                            DeliveryId = 1,
                            PaymentId = 2,
                            TotalPrice = 2920000m
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            DatePlaced = new DateTime(2019, 10, 17, 19, 40, 30, 421, DateTimeKind.Local).AddTicks(6507),
                            DeliveryId = 2,
                            PaymentId = 3,
                            TotalPrice = 1364000m
                        });
                });

            modelBuilder.Entity("DataLayer.Models.OrderCar", b =>
                {
                    b.Property<int>("OrderCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderCarId");

                    b.HasIndex("CarId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderCar");

                    b.HasData(
                        new
                        {
                            OrderCarId = 1,
                            CarId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            OrderCarId = 2,
                            CarId = 2,
                            OrderId = 2
                        },
                        new
                        {
                            OrderCarId = 3,
                            CarId = 4,
                            OrderId = 1
                        },
                        new
                        {
                            OrderCarId = 4,
                            CarId = 5,
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaymentOption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment");

                    b.HasData(
                        new
                        {
                            PaymentId = 1,
                            PaymentOption = "Kortbetaling"
                        },
                        new
                        {
                            PaymentId = 2,
                            PaymentOption = "PayPal"
                        },
                        new
                        {
                            PaymentId = 3,
                            PaymentOption = "MobilePay"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.HasIndex("CarId")
                        .IsUnique()
                        .HasFilter("[CarId] IS NOT NULL");

                    b.ToTable("Photo");

                    b.HasData(
                        new
                        {
                            PhotoId = 1,
                            CarId = 1,
                            PhotoPath = "Photo320I"
                        },
                        new
                        {
                            PhotoId = 2,
                            CarId = 2,
                            PhotoPath = "PhotoV40"
                        },
                        new
                        {
                            PhotoId = 3,
                            CarId = 3,
                            PhotoPath = "PhotoE220"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Car", b =>
                {
                    b.HasOne("DataLayer.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.Order", b =>
                {
                    b.HasOne("DataLayer.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.OrderCar", b =>
                {
                    b.HasOne("DataLayer.Models.Car", "Car")
                        .WithMany("OrderCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Order", "Order")
                        .WithMany("OrderCars")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Models.Photo", b =>
                {
                    b.HasOne("DataLayer.Models.Car", "Car")
                        .WithOne("Photo")
                        .HasForeignKey("DataLayer.Models.Photo", "CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
