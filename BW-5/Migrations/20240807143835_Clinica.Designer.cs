﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using clinica.DataContext;

#nullable disable

namespace BW_5.Migrations
{
    [DbContext(typeof(ClinicaDbContext))]
    [Migration("20240807143835_Clinica")]
    partial class Clinica
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("clinica.Models.Animale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataRegistrazione")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProprietario")
                        .HasColumnType("int");

                    b.Property<string>("Microchip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Nascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Razza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Animali");
                });

            modelBuilder.Entity("clinica.Models.Armadio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Armadi");
                });

            modelBuilder.Entity("clinica.Models.Cassetto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmadioId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArmadioId");

                    b.ToTable("Cassetti");
                });

            modelBuilder.Entity("clinica.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodiceFiscale")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("clinica.Models.Ditta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contatto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ditte");
                });

            modelBuilder.Entity("clinica.Models.Prodotto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArmadioId")
                        .HasColumnType("int");

                    b.Property<int?>("CassettoId")
                        .HasColumnType("int");

                    b.Property<int?>("DittaId")
                        .HasColumnType("int");

                    b.Property<int>("IdDitta")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Utilizzo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArmadioId");

                    b.HasIndex("CassettoId");

                    b.HasIndex("DittaId");

                    b.HasIndex("IdDitta");

                    b.ToTable("Prodotti");
                });

            modelBuilder.Entity("clinica.Models.Ricovero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimaleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataRicovero")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAnimale")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimaleId");

                    b.ToTable("Ricoveri");
                });

            modelBuilder.Entity("clinica.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("clinica.Models.Vendita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProdotto")
                        .HasColumnType("int");

                    b.Property<int>("NumeroRicetta")
                        .HasColumnType("int");

                    b.Property<int>("ProdottoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdottoId");

                    b.ToTable("Vendite");
                });

            modelBuilder.Entity("clinica.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimaleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVisita")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescrizioneCura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Esame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAnimale")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimaleId");

                    b.ToTable("Visite");
                });

            modelBuilder.Entity("clinica.Models.Animale", b =>
                {
                    b.HasOne("clinica.Models.Cliente", null)
                        .WithMany("Animali")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("clinica.Models.Cassetto", b =>
                {
                    b.HasOne("clinica.Models.Armadio", "Armadio")
                        .WithMany("Cassetti")
                        .HasForeignKey("ArmadioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armadio");
                });

            modelBuilder.Entity("clinica.Models.Prodotto", b =>
                {
                    b.HasOne("clinica.Models.Armadio", "armadio")
                        .WithMany("Prodotti")
                        .HasForeignKey("ArmadioId");

                    b.HasOne("clinica.Models.Cassetto", "Cassetto")
                        .WithMany()
                        .HasForeignKey("CassettoId");

                    b.HasOne("clinica.Models.Ditta", null)
                        .WithMany("Prodotti")
                        .HasForeignKey("DittaId");

                    b.HasOne("clinica.Models.Ditta", "Ditta")
                        .WithMany()
                        .HasForeignKey("IdDitta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cassetto");

                    b.Navigation("Ditta");

                    b.Navigation("armadio");
                });

            modelBuilder.Entity("clinica.Models.Ricovero", b =>
                {
                    b.HasOne("clinica.Models.Animale", "Animale")
                        .WithMany("Ricoveri")
                        .HasForeignKey("AnimaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animale");
                });

            modelBuilder.Entity("clinica.Models.Vendita", b =>
                {
                    b.HasOne("clinica.Models.Cliente", "Cliente")
                        .WithMany("Vendite")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("clinica.Models.Prodotto", "Prodotto")
                        .WithMany()
                        .HasForeignKey("ProdottoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("clinica.Models.Visita", b =>
                {
                    b.HasOne("clinica.Models.Animale", "Animale")
                        .WithMany("Visite")
                        .HasForeignKey("AnimaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animale");
                });

            modelBuilder.Entity("clinica.Models.Animale", b =>
                {
                    b.Navigation("Ricoveri");

                    b.Navigation("Visite");
                });

            modelBuilder.Entity("clinica.Models.Armadio", b =>
                {
                    b.Navigation("Cassetti");

                    b.Navigation("Prodotti");
                });

            modelBuilder.Entity("clinica.Models.Cliente", b =>
                {
                    b.Navigation("Animali");

                    b.Navigation("Vendite");
                });

            modelBuilder.Entity("clinica.Models.Ditta", b =>
                {
                    b.Navigation("Prodotti");
                });
#pragma warning restore 612, 618
        }
    }
}
