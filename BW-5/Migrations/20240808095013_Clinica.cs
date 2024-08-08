using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_5.Migrations
{
    /// <inheritdoc />
    public partial class Clinica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armadi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilita = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armadi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ditte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contatto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ditte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cassetti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ArmadioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cassetti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cassetti_Armadi_ArmadioId",
                        column: x => x.ArmadioId,
                        principalTable: "Armadi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRegistrazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Razza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PossiedeMicrochip = table.Column<bool>(type: "bit", nullable: false),
                    NumeroMicrochip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProprietario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animali_Clienti_IdProprietario",
                        column: x => x.IdProprietario,
                        principalTable: "Clienti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDitta = table.Column<int>(type: "int", nullable: false),
                    Utilizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmadioId = table.Column<int>(type: "int", nullable: true),
                    CassettoId = table.Column<int>(type: "int", nullable: true),
                    DittaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodotti_Armadi_ArmadioId",
                        column: x => x.ArmadioId,
                        principalTable: "Armadi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prodotti_Cassetti_CassettoId",
                        column: x => x.CassettoId,
                        principalTable: "Cassetti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prodotti_Ditte_DittaId",
                        column: x => x.DittaId,
                        principalTable: "Ditte",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prodotti_Ditte_IdDitta",
                        column: x => x.IdDitta,
                        principalTable: "Ditte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRicovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAnimale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ricoveri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ricoveri_Animali_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "Animali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimale = table.Column<int>(type: "int", nullable: false),
                    DataVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Esame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrizioneCura = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visite_Animali_IdAnimale",
                        column: x => x.IdAnimale,
                        principalTable: "Animali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: false),
                    NumeroRicetta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendite_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendite_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animali_IdProprietario",
                table: "Animali",
                column: "IdProprietario");

            migrationBuilder.CreateIndex(
                name: "IX_Cassetti_ArmadioId",
                table: "Cassetti",
                column: "ArmadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_ArmadioId",
                table: "Prodotti",
                column: "ArmadioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_CassettoId",
                table: "Prodotti",
                column: "CassettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_DittaId",
                table: "Prodotti",
                column: "DittaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_IdDitta",
                table: "Prodotti",
                column: "IdDitta");

            migrationBuilder.CreateIndex(
                name: "IX_Ricoveri_IdAnimale",
                table: "Ricoveri",
                column: "IdAnimale");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ClienteId_ProdottoId_NumeroRicetta",
                table: "Vendite",
                columns: new[] { "ClienteId", "ProdottoId", "NumeroRicetta" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ProdottoId",
                table: "Vendite",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Visite_IdAnimale",
                table: "Visite",
                column: "IdAnimale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ricoveri");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendite");

            migrationBuilder.DropTable(
                name: "Visite");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Animali");

            migrationBuilder.DropTable(
                name: "Cassetti");

            migrationBuilder.DropTable(
                name: "Ditte");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Armadi");
        }
    }
}
