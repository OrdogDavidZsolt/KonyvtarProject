using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonyvtarAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kolcsonzesek",
                columns: table => new
                {
                    OlvasoSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LeltariSzam = table.Column<int>(type: "INTEGER", nullable: false),
                    KolcsonzesIdeje = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VisszahozasHatarido = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzesek", x => x.OlvasoSzam);
                });

            migrationBuilder.CreateTable(
                name: "Konyvek",
                columns: table => new
                {
                    LeltariSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cim = table.Column<string>(type: "TEXT", nullable: false),
                    Szerzo = table.Column<string>(type: "TEXT", nullable: false),
                    Kiado = table.Column<string>(type: "TEXT", nullable: false),
                    KiadasEve = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konyvek", x => x.LeltariSzam);
                });

            migrationBuilder.CreateTable(
                name: "Olvasok",
                columns: table => new
                {
                    OlvasoSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OlvasoNev = table.Column<string>(type: "TEXT", nullable: false),
                    Lakcim = table.Column<string>(type: "TEXT", nullable: false),
                    SzuletesiDatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olvasok", x => x.OlvasoSzam);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolcsonzesek");

            migrationBuilder.DropTable(
                name: "Konyvek");

            migrationBuilder.DropTable(
                name: "Olvasok");
        }
    }
}
