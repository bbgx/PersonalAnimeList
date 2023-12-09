using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AnimeList.Models.AnimeModel
{
    public class AnimeModel
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("data")]
        public Data? Data { get; set; }
    }

    public partial class Data
    {
        public Data()
        {
            Producers = new List<Demographic>();
            Licensors = new List<Demographic>();
            Studios = new List<Demographic>();
            Demographics = new List<Demographic>();
        }

        [Key]
        public int Id { get; set; }

        [JsonProperty("mal_id")]
        public long? MalId { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("images")]
        public Images? Images { get; set; }

        [JsonProperty("trailer")]
        public Trailer? Trailer { get; set; }

        [JsonProperty("approved")]
        public bool? Approved { get; set; }

        [JsonProperty("titles")]
        public List<Title>? Titles { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("title_english")]
        public string? TitleEnglish { get; set; }

        [JsonProperty("title_japanese")]
        public string? TitleJapanese { get; set; }

        [JsonProperty("title_synonyms")]
        public string[]? TitleSynonyms { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }

        [JsonProperty("episodes")]
        public long? Episodes { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("airing")]
        public bool? Airing { get; set; }

        [JsonProperty("aired")]
        public Aired? Aired { get; set; }

        [JsonProperty("duration")]
        public string? Duration { get; set; }

        [JsonProperty("rating")]
        public string? Rating { get; set; }

        [JsonProperty("score")]
        public long? Score { get; set; }

        [JsonProperty("scored_by")]
        public long? ScoredBy { get; set; }

        [JsonProperty("rank")]
        public long? Rank { get; set; }

        [JsonProperty("popularity")]
        public long? Popularity { get; set; }

        [JsonProperty("members")]
        public long? Members { get; set; }

        [JsonProperty("favorites")]
        public long? Favorites { get; set; }

        [JsonProperty("synopsis")]
        public string? Synopsis { get; set; }

        [JsonProperty("background")]
        public string? Background { get; set; }

        [JsonProperty("season")]
        public string? Season { get; set; }

        [JsonProperty("year")]
        public long? Year { get; set; }

        [JsonProperty("broadcast")]
        public Broadcast? Broadcast { get; set; }

        [JsonProperty("producers")]
        public List<Demographic> Producers { get; set; }

        [JsonProperty("licensors")]
        public List<Demographic> Licensors { get; set; }

        [JsonProperty("studios")]
        public List<Demographic> Studios { get; set; }

        [JsonProperty("genres")]
        public List<Demographic>? Genres { get; set; }

        [JsonProperty("explicit_genres")]
        public List<Demographic>? ExplicitGenres { get; set; }

        [JsonProperty("themes")]
        public List<Demographic>? Themes { get; set; }

        [JsonProperty("demographics")]
        public List<Demographic> Demographics { get; set; }

        [JsonProperty("relations")]
        public List<Relation>? Relations { get; set; }

        [JsonProperty("theme")]
        public Theme? Theme { get; set; }

        [JsonProperty("external")]
        public List<External> External { get; set; }

        [JsonProperty("streaming")]
        public List<External> Streaming { get; set; }
    }

    public partial class Aired
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("from")]
        public DateTimeOffset? From { get; set; }

        [JsonProperty("to")]
        public DateTimeOffset? To { get; set; }

        [JsonProperty("prop")]
        public Prop? Prop { get; set; }
    }

    public partial class Prop
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("from")]
        public FromTo? From { get; set; }

        [JsonProperty("to")]
        public FromTo? To { get; set; }
    }

    public partial class FromTo
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("day")]
        public int? Day { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }
    }

    public partial class Broadcast
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("day")]
        public string? Day { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("string")]
        public string? String { get; set; }
    }

    public partial class Demographic
    {
        [Key]
        public int Id { get; set; }

        public int? DataIdForProducers { get; set; }

        public int? DataIdForLicensors { get; set; }

        public int? DataIdForStudios { get; set; }

        public int? DataIdForDemographics { get; set; }

        public int? DataIdForThemes { get; set; }

        public int? DataIdForGenres { get; set; }

        public int? DataIdForExplicitGenres { get; set; }

        [JsonProperty("mal_id")]
        public long? MalId { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [ForeignKey("DataIdForProducers")]
        public Data? DataForProducers { get; set; }

        [ForeignKey("DataIdForLicensors")]
        public Data? DataForLicensors { get; set; }

        [ForeignKey("DataIdForStudios")]
        public Data? DataForStudios { get; set; }

        [ForeignKey("DataIdForDemographics")]
        public Data? DataForDemographics { get; set; }

        [ForeignKey("DataIdForThemes")]
        public Data? DataForThemes { get; set; }

        [ForeignKey("DataIdForGenres")]
        public int? DataForGenres { get; set; }

        [ForeignKey("DataIdForExplicitGenres")]
        public int? DataForExplicitGenres { get; set; }
    }

    public partial class External
    {
        [Key]
        public int Id { get; set; }

        public int? EDataId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [ForeignKey("EDataId")]
        public Data? Data { get; set; }
    }

    public partial class Images
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("jpg")]
        public ImageDetails? Jpg { get; set; }

        [JsonProperty("webp")]
        public ImageDetails? Webp { get; set; }
    }

    public partial class ImageDetails
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("image_url")]
        public string? ImageUrl { get; set; }

        [JsonProperty("small_image_url")]
        public string? SmallImageUrl { get; set; }

        [JsonProperty("large_image_url")]
        public string? LargeImageUrl { get; set; }
    }

    public partial class Relation
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("relation")]
        public string? RelationType { get; set; }

        [JsonProperty("entry")]
        public List<Demographic>? Entry { get; set; }
    }

    public partial class Theme
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("openings")]
        public List<string>? Openings { get; set; }

        [JsonProperty("endings")]
        public List<string>? Endings { get; set; }
    }

    public partial class Title
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public string? TitleType { get; set; }

        [JsonProperty("title")]
        public string? TitleTitle { get; set; }
    }

    public partial class Trailer
    {
        [Key]
        public int? Id { get; set; }

        [JsonProperty("youtube_id")]
        public string? YoutubeId { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("embed_url")]
        public string? EmbedUrl { get; set; }
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json)
        {
            var result = JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
            return result ?? throw new InvalidOperationException("Invalid JSON for Welcome object");
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
