﻿// <auto-generated />
using System;
using AnimeList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    [DbContext(typeof(AnimeDbContext))]
    [Migration("20231211213854_AnimeModelDatabaseMigration")]
    partial class AnimeModelDatabaseMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRating")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("AiredFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("AiredTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("Airing")
                        .HasColumnType("boolean");

                    b.Property<string>("AnimeCoverImage")
                        .HasColumnType("text");

                    b.Property<string>("Background")
                        .HasColumnType("text");

                    b.Property<string>("BroadcastedWeekDayAndTime")
                        .HasColumnType("text");

                    b.Property<string>("EpisodeDuration")
                        .HasColumnType("text");

                    b.Property<int>("Episodes")
                        .HasColumnType("integer");

                    b.Property<int>("MalId")
                        .HasColumnType("integer");

                    b.Property<int?>("MediaOriginalSourceId")
                        .HasColumnType("integer");

                    b.Property<string>("MyAnimeICollectionUrl")
                        .HasColumnType("text");

                    b.Property<int?>("Rank")
                        .HasColumnType("integer");

                    b.Property<double?>("Score")
                        .HasColumnType("double precision");

                    b.Property<int?>("ScoredByUser")
                        .HasColumnType("integer");

                    b.Property<string>("Season")
                        .HasColumnType("text");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Synopsis")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("TitleEnglish")
                        .HasColumnType("text");

                    b.Property<string>("TitleJapanese")
                        .HasColumnType("text");

                    b.Property<string>("TrailerEmbedUrl")
                        .HasColumnType("text");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("text");

                    b.Property<int?>("TransmissionMediaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MediaOriginalSourceId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TransmissionMediaId");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Demographic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Demographics");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Licensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Licensors");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+PublishingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PublishingStatus");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MediaSource")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Streaming", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Streamings");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnimeModelId")
                        .HasColumnType("integer");

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnimeModelId");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TransmissionMedia")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TransmissionMedia");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel+Source", "MediaOriginalSource")
                        .WithMany()
                        .HasForeignKey("MediaOriginalSourceId");

                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel+PublishingStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel+Type", "TransmissionMedia")
                        .WithMany()
                        .HasForeignKey("TransmissionMediaId");

                    b.Navigation("MediaOriginalSource");

                    b.Navigation("Status");

                    b.Navigation("TransmissionMedia");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Demographic", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaDemographics")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Genre", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaGenres")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Licensor", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaLicensors")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Producer", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaProducers")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Streaming", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("StreamingWebsites")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Studio", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaStudios")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel+Theme", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany("MediaThemes")
                        .HasForeignKey("AnimeModelId");
                });

            modelBuilder.Entity("AnimeICollection.Models.AnimeModel.AnimeModel", b =>
                {
                    b.Navigation("MediaDemographics");

                    b.Navigation("MediaGenres");

                    b.Navigation("MediaLicensors");

                    b.Navigation("MediaProducers");

                    b.Navigation("MediaStudios");

                    b.Navigation("MediaThemes");

                    b.Navigation("StreamingWebsites");
                });
#pragma warning restore 612, 618
        }
    }
}
