using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyInventory2026.Migrations
{
    /// <inheritdoc />
    public partial class ProductsProviderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductProviders",
                columns: table => new
                {
                    Productsid = table.Column<int>(type: "int", nullable: false),
                    ProvidersId = table.Column<string>(type: "varchar(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProviders", x => new { x.Productsid, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_ProductProviders_products_Productsid",
                        column: x => x.Productsid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProviders_providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProviders_ProvidersId",
                table: "ProductProviders",
                column: "ProvidersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProviders");
        }
    }
}
