using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeShop.Data.Migrations
{
    public partial class AddUserLockoutDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsManufacturers_Products",
                table: "DeliveryCountry");

            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutDate",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ManufacturerID",
                table: "DeliveryCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsManufacturers_Products",
                table: "DeliveryCountry",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsManufacturers_Products",
                table: "DeliveryCountry");

            migrationBuilder.DropColumn(
                name: "LockoutDate",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManufacturerID",
                table: "DeliveryCountry",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsManufacturers_Products",
                table: "DeliveryCountry",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
