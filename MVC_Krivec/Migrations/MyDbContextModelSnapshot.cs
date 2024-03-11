﻿// <auto-generated />
using System;
using MVC_Krivec;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Krivec.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Krivec.Models.Bend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LetoUstanovitve")
                        .HasColumnType("int");

                    b.Property<int>("TurnejaTK")
                        .HasColumnType("int");

                    b.Property<string>("drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bend");
                });

            modelBuilder.Entity("MVC_Krivec.Models.Clan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TurnejaTK")
                        .HasColumnType("int");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priimek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("starost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("MVC_Krivec.Models.Merch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cena")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Merch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            cena = 15,
                            naziv = "Slipknot T-shirt"
                        },
                        new
                        {
                            Id = 2,
                            cena = 10,
                            naziv = "ACDC Mug"
                        },
                        new
                        {
                            Id = 3,
                            cena = 20,
                            naziv = "Joker Out Hoodie"
                        });
                });

            modelBuilder.Entity("MVC_Krivec.Models.NarocanjeMercha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumInCas")
                        .HasColumnType("datetime2");

                    b.Property<int>("TK_User")
                        .HasColumnType("int");

                    b.Property<int>("cena")
                        .HasColumnType("int");

                    b.Property<string>("kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("posta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NarocanjeMercha");
                });

            modelBuilder.Entity("MVC_Krivec.Models.Turneje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("bendi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("turneja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turneja");
                });

            modelBuilder.Entity("MVC_Krivec.Models.Uporabnik_z_Gesli", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMSO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KrajRojstva")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Posta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PostnaST")
                        .HasColumnType("float");

                    b.Property<string>("Priimek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RojstniDan")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naslov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("starost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UporabnikDSR");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "Password1!",
                            Drzava = "Slovenia",
                            EMSO = "1234567890123",
                            Email = "janez.novak@example.com",
                            Geslo = "Password1!",
                            Ime = "Janez",
                            KrajRojstva = "Ljubljana",
                            Posta = "Ljubljana",
                            PostnaST = 1000.0,
                            Priimek = "Novak",
                            RojstniDan = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Admin",
                            naslov = "Slovenska cesta 1",
                            starost = 31
                        },
                        new
                        {
                            Id = 2,
                            ConfirmPassword = "Password2!",
                            Drzava = "Slovenia",
                            EMSO = "9876543210987",
                            Email = "ana.kovac@example.com",
                            Geslo = "Password2!",
                            Ime = "Ana",
                            KrajRojstva = "Maribor",
                            Posta = "Maribor",
                            PostnaST = 2000.0,
                            Priimek = "Kovač",
                            RojstniDan = new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Role = "Admin",
                            naslov = "Trg Leona Štuklja 1",
                            starost = 26
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
