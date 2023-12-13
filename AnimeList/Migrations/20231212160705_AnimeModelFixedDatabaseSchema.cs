using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    /// <inheritdoc />
    public partial class AnimeModelFixedDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeData",
                columns: table => new
                {
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
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "AnimeData");
        }
    }
}
