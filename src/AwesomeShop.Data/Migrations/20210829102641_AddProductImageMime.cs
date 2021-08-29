using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeShop.Data.Migrations
{
    public partial class AddProductImageMime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageBase64Mime",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64Mime",
                table: "Products");
        }
    }
}
