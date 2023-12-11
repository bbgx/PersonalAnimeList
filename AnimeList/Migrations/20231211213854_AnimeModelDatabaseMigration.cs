using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AnimeModelDatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublishingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MediaSource = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransmissionMedia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: false),
                    MyAnimeICollectionUrl = table.Column<string>(type: "text", nullable: true),
                    AnimeCoverImage = table.Column<string>(type: "text", nullable: true),
                    TrailerEmbedUrl = table.Column<string>(type: "text", nullable: true),
                    TrailerUrl = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TitleEnglish = table.Column<string>(type: "text", nullable: true),
                    TitleJapanese = table.Column<string>(type: "text", nullable: true),
                    TransmissionMediaId = table.Column<int>(type: "integer", nullable: true),
                    MediaOriginalSourceId = table.Column<int>(type: "integer", nullable: true),
                    Episodes = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Anime_PublishingStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "PublishingStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_Source_MediaOriginalSourceId",
                        column: x => x.MediaOriginalSourceId,
                        principalTable: "Source",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Anime_TransmissionMedia_TransmissionMediaId",
                        column: x => x.TransmissionMediaId,
                        principalTable: "TransmissionMedia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demographics_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genres_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Licensors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licensors_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producers_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Streamings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streamings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streamings_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studios_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_MediaOriginalSourceId",
                table: "Anime",
                column: "MediaOriginalSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_StatusId",
                table: "Anime",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_TransmissionMediaId",
                table: "Anime",
                column: "TransmissionMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographics_AnimeModelId",
                table: "Demographics",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AnimeModelId",
                table: "Genres",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensors_AnimeModelId",
                table: "Licensors",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Producers_AnimeModelId",
                table: "Producers",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Streamings_AnimeModelId",
                table: "Streamings",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Studios_AnimeModelId",
                table: "Studios",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_AnimeModelId",
                table: "Themes",
                column: "AnimeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demographics");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Licensors");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Streamings");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "PublishingStatus");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "TransmissionMedia");
        }
    }
}
