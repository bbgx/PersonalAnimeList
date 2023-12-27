using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeList.Models
{
    public class BaseAnimeModelConverter : JsonConverter<BaseAnimeModel>
    {
        public override BaseAnimeModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var model = new BaseAnimeModel();
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                ReadBaseModelProperties(model, jsonDoc.RootElement);
            }
            return model;
        }
        public static void ReadBaseModelProperties(BaseAnimeModel model, JsonElement root)
        {
            var data = root;
            var images = root.GetProperty("images");
            var jpg = images.GetProperty("jpg");
            var trailer = data.GetProperty("trailer");
            var aired = data.GetProperty("aired");
            var broadcast = data.GetProperty("broadcast");
            List<BaseAnimeModel.Producer>? producer = null;
            if (data.TryGetProperty("producers", out JsonElement producersElement) && producersElement.ValueKind == JsonValueKind.Array) 
            { 
                producer = producersElement.EnumerateArray().Select(p => 
                {
                    return new BaseAnimeModel.Producer
                    {
                        MalId = p.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Type = p.TryGetProperty("type", out var typeJson) ? typeJson.GetString() : null,
                        Name = p.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    };
                }).ToList();
            };
            List<BaseAnimeModel.Licensor>? licensor = null;
            if (data.TryGetProperty("licensors", out JsonElement licensorsElement) && licensorsElement.ValueKind == JsonValueKind.Array) 
            {
                licensor = licensorsElement.EnumerateArray().Select(l => {
                    return new BaseAnimeModel.Licensor
                    {
                        MalId = l.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = l.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    };
                }).ToList();
            };
            List<BaseAnimeModel.Studio>? studio = null;
            if (data.TryGetProperty("studios", out JsonElement studiosElement) && studiosElement.ValueKind == JsonValueKind.Array)
            {
                studio = studiosElement.EnumerateArray().Select(s =>
                {
                    return new BaseAnimeModel.Studio
                    {
                        MalId = s.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = s.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    };
                }).ToList();
            };
            List<BaseAnimeModel.Genre>? genre = null;
            if (data.TryGetProperty("genres", out JsonElement genresElement) && genresElement.ValueKind == JsonValueKind.Array)
            {
                genre = genresElement.EnumerateArray().Select(g => 
                {
                    return new BaseAnimeModel.Genre
                    {
                        MalId = g.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Type = g.TryGetProperty("type", out var typeJson) ? typeJson.GetString() : null,
                        Name = g.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    };
                }).ToList();
            };
            List<BaseAnimeModel.Theme>? theme = null;
            if (data.TryGetProperty("themes", out JsonElement themesElement) && themesElement.ValueKind == JsonValueKind.Array)
            {
                theme = themesElement.EnumerateArray().Select(t =>
                {
                    return new BaseAnimeModel.Theme
                    {
                        MalId = t.GetProperty("mal_id").GetInt16(), // Directly access since it's guaranteed to exist
                        Name = t.GetProperty("name").GetString() // Directly access since it's guaranteed to exist
                    };
                }).ToList();
            }
            List<BaseAnimeModel.Demographic>? demographic = null;
            if (data.TryGetProperty("demographics", out JsonElement demographicsElement) && demographicsElement.ValueKind == JsonValueKind.Array)
            {
                demographic = demographicsElement.EnumerateArray().Select(d =>
                {
                    return new BaseAnimeModel.Demographic
                    {
                        MalId = d.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = d.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    };
                }).ToList();
            }
            List<BaseAnimeModel.Streaming>? streaming = null;
            if (data.TryGetProperty("streaming", out JsonElement streamingsElement) && streamingsElement.ValueKind == JsonValueKind.Array)
            {
                streaming = streamingsElement.EnumerateArray().Select(s => 
                {
                    return new BaseAnimeModel.Streaming
                    {
                        Name = s.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                        Url = s.TryGetProperty("url", out var malIdJson) ? malIdJson.GetString() : null,
                    };
                }).ToList();
            }
            model.MalId = data.GetProperty("mal_id").GetInt32();
            model.MyAnimeListUrl = data.GetProperty("url").GetString();
            model.AnimeCoverImage = jpg.GetProperty("image_url").GetString();
            model.TrailerEmbedUrl = trailer.GetProperty("url").GetString();
            model.TrailerUrl = trailer.GetProperty("embed_url").GetString();
            model.Title = data.GetProperty("title").GetString();
            model.TitleEnglish = data.GetProperty("title_english").GetString();
            model.TitleJapanese = data.GetProperty("title_japanese").GetString();
            model.TransmissionMedia = data.GetProperty("type").GetString();
            model.MediaOriginalSource = data.GetProperty("source").GetString();
            model.Episodes = data.GetProperty("episodes").GetInt16();
            model.Status = data.GetProperty("status").GetString();
            model.Airing = data.GetProperty("airing").GetBoolean();
            model.AiredFrom = aired.GetProperty("from").SafeGetDateTimeOffset();
            model.AiredTo = aired.GetProperty("to").SafeGetDateTimeOffset();
            model.EpisodeDuration = data.GetProperty("duration").GetString();
            model.AgeRating = data.GetProperty("rating").GetString();
            model.Score = data.TryGetProperty("score", out JsonElement scoreElement) && scoreElement.ValueKind == JsonValueKind.Number
             ? scoreElement.GetDouble().ToString()
             : "N/A";
            model.ScoredByUser = data.TryGetProperty("scored_by", out JsonElement scoredByUserElement) && scoredByUserElement.ValueKind == JsonValueKind.Number
             ? scoredByUserElement.GetInt32().ToString()
             : "N/A";
            model.Rank = data.TryGetProperty("rank", out JsonElement rankElement) && rankElement.ValueKind == JsonValueKind.Number
             ? rankElement.GetInt32().ToString() 
             : "N/A";
            model.Synopsis = data.GetProperty("synopsis").GetString();
            model.Background = data.GetProperty("background").GetString();
            model.Season = data.GetProperty("season").GetString();
            model.BroadcastedWeekDayAndTime = broadcast.GetProperty("string").GetString();
            model.MediaProducers = producer;
            model.MediaLicensors = licensor;
            model.MediaStudios = studio;
            model.MediaGenres = genre;
            model.MediaThemes = theme;
            model.MediaDemographics = demographic;
            model.StreamingWebsites = streaming;
        }
        public override void Write(Utf8JsonWriter writer, BaseAnimeModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    public static class JsonExtensions
    {
        public static DateTimeOffset? SafeGetDateTimeOffset(this JsonElement element)
        {
            return element.ValueKind != JsonValueKind.Null ? element.GetDateTimeOffset() : null;
        }
    }
}
