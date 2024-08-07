using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_5.Migrations
{
    /// <inheritdoc />
    public partial class modificaModelAnimale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animali_Cliente_IdProprietario",
                table: "Animali");

            migrationBuilder.RenameColumn(
                name: "Microchip",
                table: "Animali",
                newName: "NumeroMicrochip");

            migrationBuilder.AlterColumn<int>(
                name: "IdProprietario",
                table: "Animali",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "PossiedeMicrochip",
                table: "Animali",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Animali_Cliente_IdProprietario",
                table: "Animali",
                column: "IdProprietario",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animali_Cliente_IdProprietario",
                table: "Animali");

            migrationBuilder.DropColumn(
                name: "PossiedeMicrochip",
                table: "Animali");

            migrationBuilder.RenameColumn(
                name: "NumeroMicrochip",
                table: "Animali",
                newName: "Microchip");

            migrationBuilder.AlterColumn<int>(
                name: "IdProprietario",
                table: "Animali",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animali_Cliente_IdProprietario",
                table: "Animali",
                column: "IdProprietario",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
