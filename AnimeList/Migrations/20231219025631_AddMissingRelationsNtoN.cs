using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingRelationsNtoN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demographic_Anime_AnimeModelId",
                table: "Demographic");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_Anime_AnimeModelId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Licensor_Anime_AnimeModelId",
                table: "Licensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Streaming_Anime_AnimeModelId",
                table: "Streaming");

            migrationBuilder.DropForeignKey(
                name: "FK_Studio_Anime_AnimeModelId",
                table: "Studio");

            migrationBuilder.DropForeignKey(
                name: "FK_Theme_Anime_AnimeModelId",
                table: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Theme_AnimeModelId",
                table: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Studio_AnimeModelId",
                table: "Studio");

            migrationBuilder.DropIndex(
                name: "IX_Streaming_AnimeModelId",
                table: "Streaming");

            migrationBuilder.DropIndex(
                name: "IX_Licensor_AnimeModelId",
                table: "Licensor");

            migrationBuilder.DropIndex(
                name: "IX_Genre_AnimeModelId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Demographic_AnimeModelId",
                table: "Demographic");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Theme");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Studio");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Streaming");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Licensor");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "AnimeModelId",
                table: "Demographic");

            migrationBuilder.CreateTable(
                name: "AnimeModelDemographic",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaDemographicsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelDemographic", x => new { x.AnimesId, x.MediaDemographicsId });
                    table.ForeignKey(
                        name: "FK_AnimeModelDemographic_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelDemographic_Demographic_MediaDemographicsId",
                        column: x => x.MediaDemographicsId,
                        principalTable: "Demographic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeModelGenre",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaGenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelGenre", x => new { x.AnimesId, x.MediaGenresId });
                    table.ForeignKey(
                        name: "FK_AnimeModelGenre_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelGenre_Genre_MediaGenresId",
                        column: x => x.MediaGenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeModelLicensor",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaLicensorsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelLicensor", x => new { x.AnimesId, x.MediaLicensorsId });
                    table.ForeignKey(
                        name: "FK_AnimeModelLicensor_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelLicensor_Licensor_MediaLicensorsId",
                        column: x => x.MediaLicensorsId,
                        principalTable: "Licensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeModelStreaming",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    StreamingWebsitesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelStreaming", x => new { x.AnimesId, x.StreamingWebsitesId });
                    table.ForeignKey(
                        name: "FK_AnimeModelStreaming_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelStreaming_Streaming_StreamingWebsitesId",
                        column: x => x.StreamingWebsitesId,
                        principalTable: "Streaming",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeModelStudio",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaStudiosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelStudio", x => new { x.AnimesId, x.MediaStudiosId });
                    table.ForeignKey(
                        name: "FK_AnimeModelStudio_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelStudio_Studio_MediaStudiosId",
                        column: x => x.MediaStudiosId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeModelTheme",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    MediaThemesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeModelTheme", x => new { x.AnimesId, x.MediaThemesId });
                    table.ForeignKey(
                        name: "FK_AnimeModelTheme_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeModelTheme_Theme_MediaThemesId",
                        column: x => x.MediaThemesId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelDemographic_MediaDemographicsId",
                table: "AnimeModelDemographic",
                column: "MediaDemographicsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelGenre_MediaGenresId",
                table: "AnimeModelGenre",
                column: "MediaGenresId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelLicensor_MediaLicensorsId",
                table: "AnimeModelLicensor",
                column: "MediaLicensorsId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelStreaming_StreamingWebsitesId",
                table: "AnimeModelStreaming",
                column: "StreamingWebsitesId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelStudio_MediaStudiosId",
                table: "AnimeModelStudio",
                column: "MediaStudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeModelTheme_MediaThemesId",
                table: "AnimeModelTheme",
                column: "MediaThemesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeModelDemographic");

            migrationBuilder.DropTable(
                name: "AnimeModelGenre");

            migrationBuilder.DropTable(
                name: "AnimeModelLicensor");

            migrationBuilder.DropTable(
                name: "AnimeModelStreaming");

            migrationBuilder.DropTable(
                name: "AnimeModelStudio");

            migrationBuilder.DropTable(
                name: "AnimeModelTheme");

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Theme",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Studio",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Streaming",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Licensor",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Genre",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeModelId",
                table: "Demographic",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theme_AnimeModelId",
                table: "Theme",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_AnimeModelId",
                table: "Studio",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Streaming_AnimeModelId",
                table: "Streaming",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensor_AnimeModelId",
                table: "Licensor",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_AnimeModelId",
                table: "Genre",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_AnimeModelId",
                table: "Demographic",
                column: "AnimeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demographic_Anime_AnimeModelId",
                table: "Demographic",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Anime_AnimeModelId",
                table: "Genre",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licensor_Anime_AnimeModelId",
                table: "Licensor",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Streaming_Anime_AnimeModelId",
                table: "Streaming",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Studio_Anime_AnimeModelId",
                table: "Studio",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Theme_Anime_AnimeModelId",
                table: "Theme",
                column: "AnimeModelId",
                principalTable: "Anime",
                principalColumn: "Id");
        }
    }
}
