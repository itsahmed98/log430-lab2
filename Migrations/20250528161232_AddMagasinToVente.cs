using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagasinMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddMagasinToVente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagasinId",
                table: "Ventes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_MagasinId",
                table: "Ventes",
                column: "MagasinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Magasins_MagasinId",
                table: "Ventes",
                column: "MagasinId",
                principalTable: "Magasins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Magasins_MagasinId",
                table: "Ventes");

            migrationBuilder.DropIndex(
                name: "IX_Ventes_MagasinId",
                table: "Ventes");

            migrationBuilder.DropColumn(
                name: "MagasinId",
                table: "Ventes");
        }
    }
}
