using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initialss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryOption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentOption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    PhotoId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePlaced = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(15, 2)", nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false),
                    DeliveryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(nullable: true),
                    CarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photo_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderCar",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCar", x => new { x.OrderId, x.CarId });
                    table.ForeignKey(
                        name: "FK_OrderCar_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderCar_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Volvo" },
                    { 3, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Æblevej 4, København", "karl@mail.dk", "Karl" },
                    { 2, "Nørregade 81, Odense", "bent@mail.dk", "Bent" }
                });

            migrationBuilder.InsertData(
                table: "Delivery",
                columns: new[] { "DeliveryId", "DeliveryOption" },
                values: new object[,]
                {
                    { 1, "PostNord - Pakkeshop" },
                    { 2, "GLS - Til døren" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "PaymentOption" },
                values: new object[,]
                {
                    { 1, "Kortbetaling" },
                    { 2, "PayPal" },
                    { 3, "MobilePay" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BrandId", "ModelName", "PhotoId", "Price" },
                values: new object[,]
                {
                    { 1, 1, "320I", 1, 420000m },
                    { 4, 1, "M5", null, 2500000m },
                    { 2, 2, "V40", 2, 304000m },
                    { 5, 2, "XC90", null, 1060000m },
                    { 3, 3, "E220", 3, 650000m },
                    { 6, 3, "E63S", null, 2700000m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "DatePlaced", "DeliveryId", "PaymentId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 11, 3, 15, 3, 38, 878, DateTimeKind.Local).AddTicks(26), 1, 2, 2920000m },
                    { 2, 2, new DateTime(2019, 11, 3, 15, 3, 38, 882, DateTimeKind.Local).AddTicks(1715), 2, 3, 1364000m }
                });

            migrationBuilder.InsertData(
                table: "OrderCar",
                columns: new[] { "OrderId", "CarId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 2, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "PhotoId", "CarId", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 1, "Photo320I" },
                    { 2, 2, "PhotoV40" },
                    { 3, 3, "PhotoE220" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCar_CarId",
                table: "OrderCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CarId",
                table: "Photo",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCar");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
