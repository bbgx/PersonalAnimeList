using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AnimeModelFixedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeData");

            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AiredFrom",
                table: "Anime",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AiredTo",
                table: "Anime",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Airing",
                table: "Anime",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimeCoverImage",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Background",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BroadcastedWeekDayAndTime",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EpisodeDuration",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Episodes",
                table: "Anime",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MalId",
                table: "Anime",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MediaOriginalSource",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyAnimeListUrl",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Anime",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Anime",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoredByUser",
                table: "Anime",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEnglish",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleJapanese",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerEmbedUrl",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerUrl",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransmissionMedia",
                table: "Anime",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Demographic",
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
                    table.PrimaryKey("PK_Demographic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demographic_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
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
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Licensor",
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
                    table.PrimaryKey("PK_Licensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licensor_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Producer",
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
                    table.PrimaryKey("PK_Producer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producer_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Streaming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    AnimeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streaming", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streaming_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Studio",
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
                    table.PrimaryKey("PK_Studio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studio_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Theme",
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
                    table.PrimaryKey("PK_Theme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theme_Anime_AnimeModelId",
                        column: x => x.AnimeModelId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_AnimeModelId",
                table: "Demographic",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_AnimeModelId",
                table: "Genre",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Licensor_AnimeModelId",
                table: "Licensor",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Producer_AnimeModelId",
                table: "Producer",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Streaming_AnimeModelId",
                table: "Streaming",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_AnimeModelId",
                table: "Studio",
                column: "AnimeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Theme_AnimeModelId",
                table: "Theme",
                column: "AnimeModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Theme");

            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AiredFrom",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AiredTo",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Airing",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeCoverImage",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Background",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "BroadcastedWeekDayAndTime",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "EpisodeDuration",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Episodes",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "MalId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "MediaOriginalSource",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "MyAnimeListUrl",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "ScoredByUser",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TitleEnglish",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TitleJapanese",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TrailerEmbedUrl",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TrailerUrl",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "TransmissionMedia",
                table: "Anime");

            migrationBuilder.CreateTable(
                name: "AnimeData",
                columns: table => new
                {
                    AgeRating = table.Column<string>(type: "text", nullable: true),
                    AiredFrom = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AiredTo = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Airing = table.Column<bool>(type: "boolean", nullable: true),
                    AnimeCoverImage = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    BroadcastedWeekDayAndTime = table.Column<string>(type: "text", nullable: true),
                    EpisodeDuration = table.Column<string>(type: "text", nullable: true),
                    Episodes = table.Column<int>(type: "integer", nullable: false),
                    MalId = table.Column<int>(type: "integer", nullable: false),
                    MediaOriginalSource = table.Column<string>(type: "text", nullable: true),
                    MyAnimeListUrl = table.Column<string>(type: "text", nullable: true),
                    Rank = table.Column<int>(type: "integer", nullable: true),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    ScoredByUser = table.Column<int>(type: "integer", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TitleEnglish = table.Column<string>(type: "text", nullable: true),
                    TitleJapanese = table.Column<string>(type: "text", nullable: true),
                    TrailerEmbedUrl = table.Column<string>(type: "text", nullable: true),
                    TrailerUrl = table.Column<string>(type: "text", nullable: true),
                    TransmissionMedia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
