using AnimeICollection.Models.AnimeModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AnimeList.Models
{
    public class BaseAnimeModel
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
        public int Episodes { get; set; }
        public string? Status { get; set; }
        public bool? Airing { get; set; }
        public DateTimeOffset? AiredFrom { get; set; }
        public DateTimeOffset? AiredTo { get; set; }
        public string? EpisodeDuration { get; set; }
        public string? AgeRating { get; set; }
        public string? Score { get; set; }
        public string? ScoredByUser { get; set; }
        public string? Rank { get; set; }
        [Column(TypeName = "text")]
        public string? Synopsis { get; set; }
        [Column(TypeName = "text")]
        public string? Background { get; set; }
        public string? Season { get; set; }
        public string? BroadcastedWeekDayAndTime { get; set; }
        public List<Producer>? MediaProducers { get; set; } = new();
        public partial class Producer
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Type { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Licensor>? MediaLicensors { get; set; } = new();
        public partial class Licensor
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Studio>? MediaStudios { get; set; } = new();
        public partial class Studio
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Genre>? MediaGenres { get; set; } = new();
        public partial class Genre
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Type { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Theme>? MediaThemes { get; set; } = new();
        public partial class Theme
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Demographic>? MediaDemographics { get; set; } = new();
        public partial class Demographic
        {
            [Key]
            public int Id { get; set; }
            public int? MalId { get; set; }
            public string? Name { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
        public List<Streaming>? StreamingWebsites { get; set; } = new();
        public partial class Streaming
        {
            [Key]
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Url { get; set; }
            public List<AnimeModel> Animes { get; set; } = new();
        }
    }
}
