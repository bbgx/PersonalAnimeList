using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEpisodesTypeToStringToValidateNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Episodes",
                table: "Anime",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Episodes",
                table: "Anime",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
