using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_5.Migrations
{
    /// <inheritdoc />
    public partial class modificheVendita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Cliente_ClienteId",
                table: "Vendite");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Prodotti_ProdottoId",
                table: "Vendite");

            migrationBuilder.DropIndex(
                name: "IX_Vendite_ClienteId",
                table: "Vendite");

            migrationBuilder.DropIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Vendite");

            migrationBuilder.DropColumn(
                name: "ProdottoId",
                table: "Vendite");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_IdCliente",
                table: "Vendite",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_IdProdotto",
                table: "Vendite",
                column: "IdProdotto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_Cliente_IdCliente",
                table: "Vendite",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_Prodotti_IdProdotto",
                table: "Vendite",
                column: "IdProdotto",
                principalTable: "Prodotti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Cliente_IdCliente",
                table: "Vendite");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Prodotti_IdProdotto",
                table: "Vendite");

            migrationBuilder.DropIndex(
                name: "IX_Vendite_IdCliente",
                table: "Vendite");

            migrationBuilder.DropIndex(
                name: "IX_Vendite_IdProdotto",
                table: "Vendite");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Vendite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdottoId",
                table: "Vendite",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ClienteId",
                table: "Vendite",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite",
                column: "ProdottoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_Cliente_ClienteId",
                table: "Vendite",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendite_Prodotti_ProdottoId",
                table: "Vendite",
                column: "ProdottoId",
                principalTable: "Prodotti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
