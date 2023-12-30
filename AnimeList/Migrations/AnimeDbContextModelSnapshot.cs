﻿// <auto-generated />
using System;
using AnimeList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AnimeList.Migrations
{
    [DbContext(typeof(AnimeDbContext))]
    partial class AnimeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
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

                    b.Property<string>("MediaOriginalSource")
                        .HasColumnType("text");

                    b.Property<string>("MyAnimeListUrl")
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .HasColumnType("text");

                    b.Property<string>("Score")
                        .HasColumnType("text");

                    b.Property<string>("ScoredByUser")
                        .HasColumnType("text");

                    b.Property<string>("Season")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

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

                    b.Property<string>("TransmissionMedia")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Anime");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Demographic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Demographic");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Licensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Licensor");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Streaming", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Streaming");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Studio");
                });

            modelBuilder.Entity("AnimeList.Models.BaseAnimeModel+Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("MalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Theme");
                });

            modelBuilder.Entity("AnimeList.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AnimeModelDemographic", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaDemographicsId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaDemographicsId");

                    b.HasIndex("MediaDemographicsId");

                    b.ToTable("AnimeModelDemographic");
                });

            modelBuilder.Entity("AnimeModelGenre", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaGenresId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaGenresId");

                    b.HasIndex("MediaGenresId");

                    b.ToTable("AnimeModelGenre");
                });

            modelBuilder.Entity("AnimeModelLicensor", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaLicensorsId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaLicensorsId");

                    b.HasIndex("MediaLicensorsId");

                    b.ToTable("AnimeModelLicensor");
                });

            modelBuilder.Entity("AnimeModelProducer", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaProducersId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaProducersId");

                    b.HasIndex("MediaProducersId");

                    b.ToTable("AnimeModelProducer");
                });

            modelBuilder.Entity("AnimeModelStreaming", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("StreamingWebsitesId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "StreamingWebsitesId");

                    b.HasIndex("StreamingWebsitesId");

                    b.ToTable("AnimeModelStreaming");
                });

            modelBuilder.Entity("AnimeModelStudio", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaStudiosId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaStudiosId");

                    b.HasIndex("MediaStudiosId");

                    b.ToTable("AnimeModelStudio");
                });

            modelBuilder.Entity("AnimeModelTheme", b =>
                {
                    b.Property<int>("AnimesId")
                        .HasColumnType("integer");

                    b.Property<int>("MediaThemesId")
                        .HasColumnType("integer");

                    b.HasKey("AnimesId", "MediaThemesId");

                    b.HasIndex("MediaThemesId");

                    b.ToTable("AnimeModelTheme");
                });

            modelBuilder.Entity("AnimeModelDemographic", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Demographic", null)
                        .WithMany()
                        .HasForeignKey("MediaDemographicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelGenre", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Genre", null)
                        .WithMany()
                        .HasForeignKey("MediaGenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelLicensor", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Licensor", null)
                        .WithMany()
                        .HasForeignKey("MediaLicensorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelProducer", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Producer", null)
                        .WithMany()
                        .HasForeignKey("MediaProducersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelStreaming", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Streaming", null)
                        .WithMany()
                        .HasForeignKey("StreamingWebsitesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelStudio", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Studio", null)
                        .WithMany()
                        .HasForeignKey("MediaStudiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimeModelTheme", b =>
                {
                    b.HasOne("AnimeICollection.Models.AnimeModel.AnimeModel", null)
                        .WithMany()
                        .HasForeignKey("AnimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeList.Models.BaseAnimeModel+Theme", null)
                        .WithMany()
                        .HasForeignKey("MediaThemesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
