using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeICollection.Models.AnimeModel
{
    [Table("Anime")]
    public class AnimeModel
    {
        [Key]
        public int Id { get; set; }
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
        public int Episodes { get; set; }
        public string? Status { get; set; }
        public bool? Airing { get; set; }
        public DateTimeOffset? AiredFrom { get; set; }
        public DateTimeOffset? AiredTo { get; set; }
        public string? EpisodeDuration { get; set; }
        public string? AgeRating { get; set; }
        public double? Score { get; set; }
        public int? ScoredByUser { get; set; }
        public int? Rank { get; set; }
        [Column(TypeName = "text")]
        public string? Synopsis { get; set; }
        [Column(TypeName = "text")]
        public string? Background { get; set; }
        public string? Season { get; set; }
        public string? BroadcastedWeekDayAndTime { get; set; }
        public ICollection<Producer>? MediaProducers { get; set; }
        public partial class Producer
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Type { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Licensor>? MediaLicensors { get; set; }
        public partial class Licensor
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Studio>? MediaStudios { get; set; }
        public partial class Studio
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Genre>? MediaGenres { get; set; }
        public partial class Genre
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Type { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Theme>? MediaThemes { get; set; }
        public partial class Theme
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Demographic>? MediaDemographics { get; set; }
        public partial class Demographic
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
        }
        public ICollection<Streaming>? StreamingWebsites { get; set; }
        public partial class Streaming
        {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Url { get; set; }
        }
    }
}
