using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeShop.Data.Migrations
{
    public partial class RemoveUniqueCountryOnDeliveryCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Delivery__E056F20110CD0BBF",
                table: "DeliveryCountry");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("146c287c-7695-4e5f-873d-7a929e60e085"),
                column: "PasswordHash",
                value: "CD916028A2D8A1B901E831246DD5B9B4D3832786DDC63BBF5AF4B50D9FC98F50");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("146c287c-7695-4e5f-873d-7a929e60e085"),
                column: "PasswordHash",
                value: "D8F5B03A6DECC5258D84C441609B3998B5A959950075E577BA96138574CBDE75");

            migrationBuilder.CreateIndex(
                name: "UQ__Delivery__E056F20110CD0BBF",
                table: "DeliveryCountry",
                column: "CountryName",
                unique: true);
        }
    }
}
