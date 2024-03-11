using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_Krivec.Migrations
{
    /// <inheritdoc />
    public partial class merch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetoUstanovitve = table.Column<int>(type: "int", nullable: false),
                    TurnejaTK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starost = table.Column<int>(type: "int", nullable: false),
                    TurnejaTK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NarocanjeMercha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cena = table.Column<int>(type: "int", nullable: false),
                    kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    posta = table.Column<int>(type: "int", nullable: false),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumInCas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TK_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarocanjeMercha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turneja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    turneja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bendi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turneja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UporabnikDSR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RojstniDan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMSO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starost = table.Column<int>(type: "int", nullable: false),
                    KrajRojstva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostnaST = table.Column<double>(type: "float", nullable: false),
                    Posta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UporabnikDSR", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Merch",
                columns: new[] { "Id", "cena", "naziv" },
                values: new object[,]
                {
                    { 1, 15, "Slipknot T-shirt" },
                    { 2, 10, "ACDC Mug" },
                    { 3, 20, "Joker Out Hoodie" }
                });

            migrationBuilder.InsertData(
                table: "UporabnikDSR",
                columns: new[] { "Id", "ConfirmPassword", "Drzava", "EMSO", "Email", "Geslo", "Ime", "KrajRojstva", "Posta", "PostnaST", "Priimek", "RojstniDan", "Role", "naslov", "starost" },
                values: new object[,]
                {
                    { 1, "Password1!", "Slovenia", "1234567890123", "janez.novak@example.com", "Password1!", "Janez", "Ljubljana", "Ljubljana", 1000.0, "Novak", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Slovenska cesta 1", 31 },
                    { 2, "Password2!", "Slovenia", "9876543210987", "ana.kovac@example.com", "Password2!", "Ana", "Maribor", "Maribor", 2000.0, "Kovač", new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Trg Leona Štuklja 1", 26 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bend");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Merch");

            migrationBuilder.DropTable(
                name: "NarocanjeMercha");

            migrationBuilder.DropTable(
                name: "Turneja");

            migrationBuilder.DropTable(
                name: "UporabnikDSR");
        }
    }
}
