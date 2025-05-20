using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class AddFurnitureProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 3, "Ergonomik oturumlu, modern tarzda sandalye.", "/images/sandalye.jpg", "Yemek Sandalyesi", 800.0 },
                    { 4, 4, "Orta sehpa olarak kullanılabilecek modern yuvarlak sehpa.", "/images/sehpa.jpg", "Yuvarlak Sehpa", 700.0 },
                    { 5, 5, "Küçük alanlar için ideal, sade tasarımlı dolap.", "/images/dolap.jpg", "Minimal Dolap", 1200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);
        }
    }
}
