using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BW_5.Migrations
{
    /// <inheritdoc />
    public partial class modificheModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
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
========
                name: "Cliente",
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
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
                    Microchip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProprietario = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animali_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ditta",
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
                    table.PrimaryKey("PK_Ditta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Magazzino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProdotto = table.Column<int>(type: "int", nullable: false),
                    Disponibilita = table.Column<bool>(type: "bit", nullable: false),
                    Cassetto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Armadio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazzino", x => x.Id);
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
                    Microchip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProprietario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animali_Cliente_IdProprietario",
                        column: x => x.IdProprietario,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                    Utilizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArmadioId = table.Column<int>(type: "int", nullable: true),
                    CassettoId = table.Column<int>(type: "int", nullable: true),
                    DittaId = table.Column<int>(type: "int", nullable: true)
========
                    IdVendita = table.Column<int>(type: "int", nullable: false),
                    IdMagazzino = table.Column<int>(type: "int", nullable: false),
                    Utilizzo = table.Column<string>(type: "nvarchar(max)", nullable: false)
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                    table.ForeignKey(
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
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
========
                        name: "FK_Prodotti_Ditta_IdDitta",
                        column: x => x.IdDitta,
                        principalTable: "Ditta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
                });

            migrationBuilder.CreateTable(
                name: "Ricoveri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRicovero = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                    IdAnimale = table.Column<int>(type: "int", nullable: false),
                    AnimaleId = table.Column<int>(type: "int", nullable: false)
========
                    IdAnimale = table.Column<int>(type: "int", nullable: false)
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
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
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                    DescrizioneCura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimaleId = table.Column<int>(type: "int", nullable: false)
========
                    DescrizioneCura = table.Column<string>(type: "nvarchar(max)", nullable: false)
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
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
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    IdProdotto = table.Column<int>(type: "int", nullable: false),
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                    NumeroRicetta = table.Column<int>(type: "int", nullable: false),
========
                    NumeroRicetta = table.Column<string>(type: "nvarchar(max)", nullable: false),
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
                    ProdottoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendite", x => x.Id);
                    table.ForeignKey(
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                        name: "FK_Vendite_Clienti_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clienti",
========
                        name: "FK_Vendite_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
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
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                name: "IX_Animali_ClienteId",
                table: "Animali",
                column: "ClienteId");

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
========
                name: "IX_Animali_IdProprietario",
                table: "Animali",
                column: "IdProprietario");

            migrationBuilder.CreateIndex(
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
                name: "IX_Prodotti_IdDitta",
                table: "Prodotti",
                column: "IdDitta");

            migrationBuilder.CreateIndex(
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                name: "IX_Ricoveri_AnimaleId",
========
                name: "IX_Ricoveri_IdAnimale",
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
                table: "Ricoveri",
                column: "IdAnimale");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ClienteId",
                table: "Vendite",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendite_ClienteId",
                table: "Vendite",
                column: "ClienteId");

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
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
========
                name: "Magazzino");

            migrationBuilder.DropTable(
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
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
<<<<<<<< HEAD:BW-5/Migrations/20240807143835_Clinica.cs
                name: "Cassetti");

            migrationBuilder.DropTable(
                name: "Ditte");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "Armadi");
========
                name: "Ditta");

            migrationBuilder.DropTable(
                name: "Cliente");
>>>>>>>> BetaMainDue:BW-5/Migrations/20240807080953_modificheModels.cs
        }
    }
}
