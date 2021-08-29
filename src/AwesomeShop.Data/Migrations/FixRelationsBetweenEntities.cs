using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeShop.Data.Migrations
{
    public partial class FixRelationsBetweenEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ProductUser");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Members");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b4a87d46-f7bf-4339-8223-a3ce07ede3c1"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("75ad3dca-3eda-4086-8672-992a26016a68"), "Member" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "BirthDate", "PasswordHash", "RoleID", "Username" },
                values: new object[] { new Guid("146c287c-7695-4e5f-873d-7a929e60e085"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CD916028A2D8A1B901E831246DD5B9B4D3832786DDC63BBF5AF4B50D9FC98F50", new Guid("b4a87d46-f7bf-4339-8223-a3ce07ede3c1"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("146c287c-7695-4e5f-873d-7a929e60e085"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75ad3dca-3eda-4086-8672-992a26016a68"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b4a87d46-f7bf-4339-8223-a3ce07ede3c1"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Members",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductUser",
                columns: table => new
                {
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUser", x => new { x.MembersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductUser_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUser_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUser_ProductsId",
                table: "ProductUser",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
