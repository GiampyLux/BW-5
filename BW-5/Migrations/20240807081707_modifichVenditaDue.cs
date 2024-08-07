using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_5.Migrations
{
    /// <inheritdoc />
    public partial class modifichVenditaDue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Cliente_IdCliente",
                table: "Vendite");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Prodotti_IdProdotto",
                table: "Vendite");

            migrationBuilder.RenameColumn(
                name: "IdProdotto",
                table: "Vendite",
                newName: "ProdottoId");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Vendite",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendite_IdProdotto",
                table: "Vendite",
                newName: "IX_Vendite_ProdottoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendite_IdCliente",
                table: "Vendite",
                newName: "IX_Vendite_ClienteId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Cliente_ClienteId",
                table: "Vendite");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendite_Prodotti_ProdottoId",
                table: "Vendite");

            migrationBuilder.RenameColumn(
                name: "ProdottoId",
                table: "Vendite",
                newName: "IdProdotto");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Vendite",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite",
                newName: "IX_Vendite_IdProdotto");

            migrationBuilder.RenameIndex(
                name: "IX_Vendite_ClienteId",
                table: "Vendite",
                newName: "IX_Vendite_IdCliente");

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
    }
}
