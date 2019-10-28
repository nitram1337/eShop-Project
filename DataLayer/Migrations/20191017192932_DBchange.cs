using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class DBchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DatePlaced",
                value: new DateTime(2019, 10, 17, 21, 29, 30, 712, DateTimeKind.Local).AddTicks(4732));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DatePlaced",
                value: new DateTime(2019, 10, 17, 21, 29, 30, 717, DateTimeKind.Local).AddTicks(9130));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "DatePlaced",
                value: new DateTime(2019, 10, 17, 19, 40, 30, 419, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "DatePlaced",
                value: new DateTime(2019, 10, 17, 19, 40, 30, 421, DateTimeKind.Local).AddTicks(6507));
        }
    }
}
