﻿using System.ComponentModel.DataAnnotations;

namespace AnimeList.DTO
{
    public class BaseAnimeModelDTO
    {
        public int MalId { get; set; }
        public string? MyAnimeListUrl { get; set; }
        public string? AnimeCoverImage { get; set; }
        public string? TrailerEmbedUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public string? Title { get; set; }
        public string? TitleEnglish { get; set; }
        public string? TitleJapanese { get; set; }
        public string? TransmissionMedia { get; set; }
        public string? MediaOriginalSource { get; set; }
        public string Episodes { get; set; }
        public string? Status { get; set; }
        public bool? Airing { get; set; }
        public DateTimeOffset? AiredFrom { get; set; }
        public DateTimeOffset? AiredTo { get; set; }
        public string? EpisodeDuration { get; set; }
        public string? AgeRating { get; set; }
        public string? Score { get; set; }
        public string? ScoredByUser { get; set; }
        public string? Rank { get; set; }
        public string? Synopsis { get; set; }
        public string? Background { get; set; }
        public string? Season { get; set; }
        public string? BroadcastedWeekDayAndTime { get; set; }
        public List<ProducerDTO>? MediaProducers { get; set; }
        public List<LicensorDTO>? MediaLicensors { get; set; }
        public List<StudioDTO>? MediaStudios { get; set; }
        public List<GenreDTO>? MediaGenres { get; set; }
        public List<ThemeDTO>? MediaThemes { get; set; }
        public List<DemographicDTO>? MediaDemographics { get; set; }
        public List<StreamingDTO>? StreamingWebsites { get; set; } = new();
    }
}
