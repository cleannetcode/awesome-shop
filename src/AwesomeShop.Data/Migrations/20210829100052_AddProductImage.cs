using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeShop.Data.Migrations
{
    public partial class AddProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsManufacturers_Categories",
                table: "DeliveryCountry");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "DeliveryCountry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsManufacturers_Categories",
                table: "DeliveryCountry",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsManufacturers_Categories",
                table: "DeliveryCountry");

            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductID",
                table: "DeliveryCountry",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsManufacturers_Categories",
                table: "DeliveryCountry",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
