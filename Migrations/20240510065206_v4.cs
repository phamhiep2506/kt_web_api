using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kt_web_api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ParentId",
                table: "ProductDetails",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_ProductDetails_ParentId",
                table: "ProductDetails",
                column: "ParentId",
                principalTable: "ProductDetails",
                principalColumn: "ProductDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_ProductDetails_ParentId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ParentId",
                table: "ProductDetails");
        }
    }
}
