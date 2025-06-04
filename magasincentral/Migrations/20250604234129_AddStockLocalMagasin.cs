using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace magasincentral.Migrations
{
    /// <inheritdoc />
    public partial class AddStockLocalMagasin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StocksProduitsMagasins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProduitId = table.Column<int>(type: "integer", nullable: false),
                    MagasinId = table.Column<int>(type: "integer", nullable: false),
                    Quantite = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksProduitsMagasins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocksProduitsMagasins_Magasins_MagasinId",
                        column: x => x.MagasinId,
                        principalTable: "Magasins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StocksProduitsMagasins_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StocksProduitsMagasins_MagasinId",
                table: "StocksProduitsMagasins",
                column: "MagasinId");

            migrationBuilder.CreateIndex(
                name: "IX_StocksProduitsMagasins_ProduitId",
                table: "StocksProduitsMagasins",
                column: "ProduitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StocksProduitsMagasins");
        }
    }
}
