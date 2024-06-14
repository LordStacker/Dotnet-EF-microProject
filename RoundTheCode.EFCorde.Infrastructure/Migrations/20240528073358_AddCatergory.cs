using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoundTheCode.EFCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCatergory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "shop",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "shop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "shop",
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Machines" },
                    { 2, "Accesories" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "shop",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "shop",
                table: "Product",
                column: "CategoryId",
                principalSchema: "shop",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                schema: "shop",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "shop");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                schema: "shop",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "shop",
                table: "Product");
        }
    }
}
