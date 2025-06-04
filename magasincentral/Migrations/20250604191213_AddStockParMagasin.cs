using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace magasincentral.Migrations
{
    /// <inheritdoc />
    public partial class AddStockParMagasin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StocksMagasin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MagasinId = table.Column<int>(type: "integer", nullable: false),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksMagasin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocksMagasin_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocksMagasin_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StocksMagasin_MagasinId",
                table: "StocksMagasin",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_StocksMagasin_ProduitId",
                table: "StocksMagasin",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StocksMagasin");
        }
    }
}
