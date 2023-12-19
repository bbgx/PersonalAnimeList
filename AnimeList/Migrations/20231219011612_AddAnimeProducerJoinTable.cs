using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimeProducerJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producer_Anime_AnimeModelId",
                table: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Producer_AnimeModelId",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Producer");

            migrationBuilder.CreateTable(
                name: "AnimeModelProducer",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaProducersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelProducer", x => new { x.AnimesId, x.MediaProducersId });
                    table.ForeignKey(
                        name: "FK_AnimeModelProducer_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelProducer_Producer_MediaProducersId",
                        column: x => x.MediaProducersId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelProducer_MediaProducersId",
                table: "AnimeModelProducer",
                column: "MediaProducersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeModelProducer");

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Producer",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producer_AnimeModelId",
                table: "Producer",
                column: "AnimeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producer_Anime_AnimeModelId",
                table: "Producer",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");
        }
    }
}
