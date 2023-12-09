using System;
using System.Collections.Generic;
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
                name: "Broadcast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Day = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    String = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FromTo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Day = table.Column<int>(type: "integer", nullable: true),
                    Month = table.Column<int>(type: "integer", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromTo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    SmallImageUrl = table.Column<string>(type: "text", nullable: true),
                    LargeImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Openings = table.Column<List<string>>(type: "text[]", nullable: true),
                    Endings = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YoutubeId = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    EmbedUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromId = table.Column<int>(type: "integer", nullable: true),
                    ToId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prop_FromTo_FromId",
                        column: x => x.FromId,
                        principalTable: "FromTo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prop_FromTo_ToId",
                        column: x => x.ToId,
                        principalTable: "FromTo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JpgId = table.Column<int>(type: "integer", nullable: true),
                    WebpId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ImageDetails_JpgId",
                        column: x => x.JpgId,
                        principalTable: "ImageDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_ImageDetails_WebpId",
                        column: x => x.WebpId,
                        principalTable: "ImageDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aired",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    To = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PropId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aired", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aired_Prop_PropId",
                        column: x => x.PropId,
                        principalTable: "Prop",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MalId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ImagesId = table.Column<int>(type: "integer", nullable: true),
                    TrailerId = table.Column<int>(type: "integer", nullable: true),
                    Approved = table.Column<bool>(type: "boolean", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TitleEnglish = table.Column<string>(type: "text", nullable: true),
                    TitleJapanese = table.Column<string>(type: "text", nullable: true),
                    TitleSynonyms = table.Column<string[]>(type: "text[]", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Episodes = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Airing = table.Column<bool>(type: "boolean", nullable: true),
                    AiredId = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<string>(type: "text", nullable: true),
                    Score = table.Column<long>(type: "bigint", nullable: true),
                    ScoredBy = table.Column<long>(type: "bigint", nullable: true),
                    Rank = table.Column<long>(type: "bigint", nullable: true),
                    Popularity = table.Column<long>(type: "bigint", nullable: true),
                    Members = table.Column<long>(type: "bigint", nullable: true),
                    Favorites = table.Column<long>(type: "bigint", nullable: true),
                    Synopsis = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    Season = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<long>(type: "bigint", nullable: true),
                    BroadcastId = table.Column<int>(type: "integer", nullable: true),
                    ThemeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_Aired_AiredId",
                        column: x => x.AiredId,
                        principalTable: "Aired",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Data_Broadcast_BroadcastId",
                        column: x => x.BroadcastId,
                        principalTable: "Broadcast",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Data_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Data_Theme_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Theme",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Data_Trailer_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_Data_DataId",
                        column: x => x.DataId,
                        principalTable: "Data",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "External",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EDataId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    DataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_External", x => x.Id);
                    table.ForeignKey(
                        name: "FK_External_Data_DataId",
                        column: x => x.DataId,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_External_Data_EDataId",
                        column: x => x.EDataId,
                        principalTable: "Data",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RelationType = table.Column<string>(type: "text", nullable: true),
                    DataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relation_Data_DataId",
                        column: x => x.DataId,
                        principalTable: "Data",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleType = table.Column<string>(type: "text", nullable: true),
                    TitleTitle = table.Column<string>(type: "text", nullable: true),
                    DataId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Title_Data_DataId",
                        column: x => x.DataId,
                        principalTable: "Data",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Demographic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataIdForProducers = table.Column<int>(type: "integer", nullable: true),
                    DataIdForLicensors = table.Column<int>(type: "integer", nullable: true),
                    DataIdForStudios = table.Column<int>(type: "integer", nullable: true),
                    DataIdForDemographics = table.Column<int>(type: "integer", nullable: true),
                    DataIdForThemes = table.Column<int>(type: "integer", nullable: true),
                    DataIdForGenres = table.Column<int>(type: "integer", nullable: true),
                    DataIdForExplicitGenres = table.Column<int>(type: "integer", nullable: true),
                    MalId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    DataForDemographicsId = table.Column<int>(type: "integer", nullable: true),
                    DataForThemesId = table.Column<int>(type: "integer", nullable: true),
                    DataForGenres = table.Column<int>(type: "integer", nullable: true),
                    DataForExplicitGenres = table.Column<int>(type: "integer", nullable: true),
                    RelationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataForDemographicsId",
                        column: x => x.DataForDemographicsId,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataForThemesId",
                        column: x => x.DataForThemesId,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForDemographics",
                        column: x => x.DataIdForDemographics,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForExplicitGenres",
                        column: x => x.DataIdForExplicitGenres,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForGenres",
                        column: x => x.DataIdForGenres,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForLicensors",
                        column: x => x.DataIdForLicensors,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForProducers",
                        column: x => x.DataIdForProducers,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForStudios",
                        column: x => x.DataIdForStudios,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Data_DataIdForThemes",
                        column: x => x.DataIdForThemes,
                        principalTable: "Data",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Demographic_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aired_PropId",
                table: "Aired",
                column: "PropId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_DataId",
                table: "Animes",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_AiredId",
                table: "Data",
                column: "AiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_BroadcastId",
                table: "Data",
                column: "BroadcastId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ImagesId",
                table: "Data",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ThemeId",
                table: "Data",
                column: "ThemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_TrailerId",
                table: "Data",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataForDemographicsId",
                table: "Demographic",
                column: "DataForDemographicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataForThemesId",
                table: "Demographic",
                column: "DataForThemesId");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForDemographics",
                table: "Demographic",
                column: "DataIdForDemographics");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForExplicitGenres",
                table: "Demographic",
                column: "DataIdForExplicitGenres");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForGenres",
                table: "Demographic",
                column: "DataIdForGenres");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForLicensors",
                table: "Demographic",
                column: "DataIdForLicensors");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForProducers",
                table: "Demographic",
                column: "DataIdForProducers");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForStudios",
                table: "Demographic",
                column: "DataIdForStudios");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_DataIdForThemes",
                table: "Demographic",
                column: "DataIdForThemes");

            migrationBuilder.CreateIndex(
                name: "IX_Demographic_RelationId",
                table: "Demographic",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_External_DataId",
                table: "External",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_External_EDataId",
                table: "External",
                column: "EDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_JpgId",
                table: "Images",
                column: "JpgId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_WebpId",
                table: "Images",
                column: "WebpId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_FromId",
                table: "Prop",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Prop_ToId",
                table: "Prop",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Relation_DataId",
                table: "Relation",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_DataId",
                table: "Title",
                column: "DataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "Demographic");

            migrationBuilder.DropTable(
                name: "External");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Aired");

            migrationBuilder.DropTable(
                name: "Broadcast");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Theme");

            migrationBuilder.DropTable(
                name: "Trailer");

            migrationBuilder.DropTable(
                name: "Prop");

            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.DropTable(
                name: "FromTo");
        }
    }
}
