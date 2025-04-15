using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KonyvtarAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
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
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "OlvasoSzam",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek",
                column: "LeltariSzam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek");

            migrationBuilder.AlterColumn<int>(
                name: "OlvasoSzam",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "LeltariSzam",
                table: "Kolcsonzesek",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kolcsonzesek",
                table: "Kolcsonzesek",
                column: "OlvasoSzam");
        }
    }
}
