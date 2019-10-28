using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class EditPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Car_CarId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_CarId",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Price",
                value: 420000m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Price",
                value: 304000m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 3,
                column: "Price",
                value: 650000m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 4,
                column: "Price",
                value: 2500000m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 5,
                column: "Price",
                value: 1060000m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 6,
                column: "Price",
                value: 2700000m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "DatePlaced", "TotalPrice" },
                values: new object[] { new DateTime(2019, 10, 17, 19, 40, 30, 419, DateTimeKind.Local).AddTicks(1822), 2920000m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "DatePlaced", "TotalPrice" },
                values: new object[] { new DateTime(2019, 10, 17, 19, 40, 30, 421, DateTimeKind.Local).AddTicks(6507), 1364000m });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CarId",
                table: "Photo",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Car_CarId",
                table: "Photo",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Car_CarId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_CarId",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Photo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Price",
                value: 420m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Price",
                value: 304m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 3,
                column: "Price",
                value: 650m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 4,
                column: "Price",
                value: 2500m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 5,
                column: "Price",
                value: 1060m);

            migrationBuilder.UpdateData(
                table: "Car",
                keyColumn: "CarId",
                keyValue: 6,
                column: "Price",
                value: 2700m);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "DatePlaced", "TotalPrice" },
                values: new object[] { new DateTime(2019, 10, 17, 18, 30, 37, 98, DateTimeKind.Local).AddTicks(8949), 2920m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "DatePlaced", "TotalPrice" },
                values: new object[] { new DateTime(2019, 10, 17, 18, 30, 37, 101, DateTimeKind.Local).AddTicks(5796), 1364m });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_CarId",
                table: "Photo",
                column: "CarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Car_CarId",
                table: "Photo",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
