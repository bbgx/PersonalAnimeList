using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: false),
                    MyAnimeListUrl = table.Column<string>(type: "text", nullable: true),
                    AnimeCoverImage = table.Column<string>(type: "text", nullable: true),
                    TrailerEmbedUrl = table.Column<string>(type: "text", nullable: true),
                    TrailerUrl = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TitleEnglish = table.Column<string>(type: "text", nullable: true),
                    TitleJapanese = table.Column<string>(type: "text", nullable: true),
                    TransmissionMedia = table.Column<string>(type: "text", nullable: true),
                    MediaOriginalSource = table.Column<string>(type: "text", nullable: true),
                    Episodes = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Airing = table.Column<bool>(type: "boolean", nullable: true),
                    AiredFrom = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AiredTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EpisodeDuration = table.Column<string>(type: "text", nullable: true),
                    AgeRating = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    ScoredByUser = table.Column<int>(type: "integer", nullable: true),
                    Rank = table.Column<int>(type: "integer", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    BroadcastedWeekDayAndTime = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demographic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Streaming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streaming", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

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
                name: "IX_AnimeModelProducer_MediaProducersId",
                table: "AnimeModelProducer",
                column: "MediaProducersId");

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
                name: "AnimeModelProducer");

            migrationBuilder.DropTable(
                name: "AnimeModelStreaming");

            migrationBuilder.DropTable(
                name: "AnimeModelStudio");

            migrationBuilder.DropTable(
                name: "AnimeModelTheme");

            migrationBuilder.DropTable(
                name: "Demographic");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Licensor");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Streaming");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Theme");
        }
    }
}
