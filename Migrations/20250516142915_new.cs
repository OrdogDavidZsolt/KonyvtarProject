using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonyvtarAPI.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek");

            migrationBuilder.AlterColumn<int>(
                name: "LeltariSzam",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "KolcsonzesId",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek",
                column: "KolcsonzesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek");

            migrationBuilder.DropColumn(
                name: "KolcsonzesId",
                table: "Kolcsonzesek");

            migrationBuilder.AlterColumn<int>(
                name: "LeltariSzam",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek",
                column: "LeltariSzam");
        }
    }
}
