using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Core.Migrations
{
    /// <inheritdoc />
    public partial class addIndexUnique_Product_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Article",
                table: "Products",
                column: "Article",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Article",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Number",
                table: "Orders");
        }
    }
}
