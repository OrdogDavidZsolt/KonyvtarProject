using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonyvtarAPI.Migrations
{
    /// <inheritdoc />
    public partial class new1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KolcsonzesId",
                table: "Kolcsonzesek",
                newName: "KolcsonzesSzam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KolcsonzesSzam",
                table: "Kolcsonzesek",
                newName: "KolcsonzesId");
        }
    }
}
