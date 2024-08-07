﻿// <auto-generated />
using System;
using BW5.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BW_5.Migrations
{
    [DbContext(typeof(ClinicaDbContext))]
    [Migration("20240807131433_modificheAnimaleMod")]
    partial class modificheAnimaleMod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BW5.Models.Animale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRegistrazione")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdProprietario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroMicrochip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PossiedeMicrochip")
                        .HasColumnType("bit");

                    b.Property<string>("Razza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdProprietario");

                    b.ToTable("Animali");
                });

            modelBuilder.Entity("BW5.Models.Magazzino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Armadio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cassetto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<int>("IdProdotto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Magazzino");
                });

            modelBuilder.Entity("BW5.Models.Prodotto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdDitta")
                        .HasColumnType("int");

                    b.Property<int>("IdMagazzino")
                        .HasColumnType("int");

                    b.Property<int>("IdVendita")
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

                    b.HasIndex("IdDitta");

                    b.ToTable("Prodotti");
                });

            modelBuilder.Entity("BW5.Models.Ricovero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataRicovero")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAnimale")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAnimale");

                    b.ToTable("Ricoveri");
                });

            modelBuilder.Entity("BW5.Models.Vendita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroRicetta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdottoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProdottoId");

                    b.ToTable("Vendite");
                });

            modelBuilder.Entity("BW5.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.HasIndex("IdAnimale");

                    b.ToTable("Visite");
                });

            modelBuilder.Entity("BW_5.Models.Cliente", b =>
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

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("BW_5.Models.Ditta", b =>
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

                    b.ToTable("Ditta");
                });

            modelBuilder.Entity("BW_5.Models.User", b =>
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

            modelBuilder.Entity("BW5.Models.Animale", b =>
                {
                    b.HasOne("BW_5.Models.Cliente", "Cliente")
                        .WithMany("Animali")
                        .HasForeignKey("IdProprietario");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BW5.Models.Prodotto", b =>
                {
                    b.HasOne("BW_5.Models.Ditta", "Ditta")
                        .WithMany("Prodotti")
                        .HasForeignKey("IdDitta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ditta");
                });

            modelBuilder.Entity("BW5.Models.Ricovero", b =>
                {
                    b.HasOne("BW5.Models.Animale", "Animale")
                        .WithMany("Ricoveri")
                        .HasForeignKey("IdAnimale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animale");
                });

            modelBuilder.Entity("BW5.Models.Vendita", b =>
                {
                    b.HasOne("BW_5.Models.Cliente", "Cliente")
                        .WithMany("Vendite")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BW5.Models.Prodotto", "Prodotto")
                        .WithMany()
                        .HasForeignKey("ProdottoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prodotto");
                });

            modelBuilder.Entity("BW5.Models.Visita", b =>
                {
                    b.HasOne("BW5.Models.Animale", "Animale")
                        .WithMany("Visite")
                        .HasForeignKey("IdAnimale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animale");
                });

            modelBuilder.Entity("BW5.Models.Animale", b =>
                {
                    b.Navigation("Ricoveri");

                    b.Navigation("Visite");
                });

            modelBuilder.Entity("BW_5.Models.Cliente", b =>
                {
                    b.Navigation("Animali");

                    b.Navigation("Vendite");
                });

            modelBuilder.Entity("BW_5.Models.Ditta", b =>
                {
                    b.Navigation("Prodotti");
                });
#pragma warning restore 612, 618
        }
    }
}
