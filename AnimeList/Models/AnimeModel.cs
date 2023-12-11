using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;

namespace AnimeICollection.Models.AnimeModel
{
    [Table("Anime")]
    public partial class AnimeModel
    {
        public int Id { get; set; }

        [JsonProperty("data.mal_id")]
        public int MalId { get; set; }

        [JsonProperty("data.url", NullValueHandling = NullValueHandling.Ignore)]
        public string? MyAnimeICollectionUrl { get; set; }

        [JsonProperty("data.images.jpg.large_image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string? AnimeCoverImage { get; set; }

        [JsonProperty("data.trailer.embed_url")]
        public string? TrailerEmbedUrl { get; set; }

        [JsonProperty("data.trailer.url")]
        public string? TrailerUrl { get; set; }

        [JsonProperty("data.title")]
        public string? Title { get; set; }

        [JsonProperty("data.title_english")]
        public string? TitleEnglish { get; set; }

        [JsonProperty("data.title_japanese")]
        public string? TitleJapanese { get; set; }

        public Type? TransmissionMedia { get; set; }

        public partial class Type
        {
            public int Id { get; set; }

            [JsonProperty("data.type")]
            public string? TransmissionMedia { get; set; }
        }

        public Source? MediaOriginalSource { get; set; }

        public partial class Source
        {
            public int Id { get; set; }

            [JsonProperty("data.source")]
            public string? MediaSource { get; set; }
        }

        [JsonProperty("data.episodes")]
        public int Episodes { get; set; }

        public PublishingStatus? Status { get; set; }

        public partial class PublishingStatus
        {
            public int Id { get; set; }

            [JsonProperty("data.status")]
            public string? Status { get; set; }
        }

        [JsonProperty("data.airing")]
        public bool? Airing { get; set; }

        [JsonProperty("data.aired.from")]
        public DateTimeOffset? AiredFrom { get; set; }

        [JsonProperty("data.aired.to")]
        public DateTimeOffset? AiredTo { get; set; }

        [JsonProperty("data.duration")]
        public string? EpisodeDuration { get; set; }

        [JsonProperty("data.rating")]
        public string? AgeRating { get; set; }

        [JsonProperty("data.score")]
        public double? Score { get; set; }

        [JsonProperty("data.scored_by")]
        public int? ScoredByUser { get; set; }

        [JsonProperty("data.rank")]
        public int? Rank { get; set; }

        [JsonProperty("data.synopsis")]
        [Column(TypeName = "text")]
        public string? Synopsis { get; set; }

        [JsonProperty("data.background")]
        [Column(TypeName = "text")]
        public string? Background { get; set; }

        [JsonProperty("data.season")]
        public string? Season { get; set; }

        [JsonProperty("data.broadcast.string")]
        public string? BroadcastedWeekDayAndTime { get; set; }

        public ICollection<Producer>? MediaProducers { get; set; }

        public partial class Producer
        {
            public int Id { get; set; }

            [JsonProperty("data.producers.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.producers.type")]
            public string? Type { get; set; }

            [JsonProperty("data.producers.name")]
            public string? Name { get; set; }
        }

        public ICollection<Licensor>? MediaLicensors { get; set; }

        public partial class Licensor
        {
            public int Id { get; set; }

            [JsonProperty("data.licensors.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.licensors.name")]
            public string? Name { get; set; }
        }
        
        public ICollection<Studio>? MediaStudios { get; set; }

        public partial class Studio
        {
            public int Id { get; set; }

            [JsonProperty("data.studios.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.studios.name")]
            public string? Name { get; set; }
        }

        public ICollection<Genre>? MediaGenres { get; set; }

        public partial class Genre
        {
            public int Id { get; set; }

            [JsonProperty("data.genres.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.genres.name")]
            public string? Name { get; set; }
        }

        public ICollection<Theme>? MediaThemes { get; set; }

        public partial class Theme
        {
            public int Id { get; set; }

            [JsonProperty("data.themes.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.themes.name")]
            public string? Name { get; set; }
        }

        public ICollection<Demographic>? MediaDemographics { get; set; }

        public partial class Demographic
        {
            public int Id { get; set; }

            [JsonProperty("data.demographics.mal_id")]
            public int? MalId { get; set; }

            [JsonProperty("data.demographics.name")]
            public string? Name { get; set; }
        }

        public ICollection<Streaming>? StreamingWebsites { get; set; }

        public partial class Streaming
        {
            public int Id { get; set; }

            [JsonProperty("data.streaming.mal_id")]
            public string? Name { get; set; }

            [JsonProperty("data.streaming.name")]
            public string? Url { get; set; }
        }
    }
}
