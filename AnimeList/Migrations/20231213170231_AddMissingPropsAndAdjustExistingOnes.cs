using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingPropsAndAdjustExistingOnes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Streaming",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Genre",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Streaming");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Genre");
        }
    }
}
