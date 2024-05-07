using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kt_web_api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductPropertyName",
                table: "ProductDetails",
                newName: "ProductDetailName"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDetailName",
                table: "ProductDetails",
                newName: "ProductPropertyName"
            );
        }
    }
}
