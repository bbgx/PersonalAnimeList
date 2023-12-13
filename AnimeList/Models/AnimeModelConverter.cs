using AnimeICollection.Models.AnimeModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeList.Models
{
    public class AnimeModelConverter : JsonConverter<AnimeModel>
    {
        public override AnimeModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var animeModel = new AnimeModel();
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var images = data.GetProperty("images");
                var jpg = images.GetProperty("jpg");
                var trailer = data.GetProperty("trailer");
                var aired = data.GetProperty("aired");
                var broadcast = data.GetProperty("broadcast");
                var producers = data.GetProperty("producers").EnumerateArray().Select(p =>
                    new AnimeModel.Producer
                    {
                        MalId = p.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Type = p.TryGetProperty("type", out var typeJson) ? typeJson.GetString() : null,
                        Name = p.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    }).ToList();
                var licensors = data.GetProperty("licensors").EnumerateArray().Select(l =>
                    new AnimeModel.Licensor
                    {
                        MalId = l.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = l.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    }).ToList();
                var studios = data.GetProperty("studios").EnumerateArray().Select(s =>
                    new AnimeModel.Studio
                    {
                        MalId = s.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = s.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    }).ToList();
                var genres = data.GetProperty("genres").EnumerateArray().Select(g =>
                new AnimeModel.Genre
                {
                    MalId = g.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                    Type = g.TryGetProperty("type", out var typeJson) ? typeJson.GetString() : null,
                    Name = g.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                }).ToList();
                var theme = data.GetProperty("themes").EnumerateArray().Select(t =>
                new AnimeModel.Theme
                {
                    MalId = t.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                    Name = t.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                }).ToList();
                var demographic = data.GetProperty("demographics").EnumerateArray().Select(d =>
                    new AnimeModel.Demographic
                    {
                        MalId = d.TryGetProperty("mal_id", out var malIdJson) ? malIdJson.GetInt16() : null,
                        Name = d.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                    }).ToList();
                var streaming = data.GetProperty("streaming").EnumerateArray().Select(s =>
                    new AnimeModel.Streaming
                    {
                        Name = s.TryGetProperty("name", out var nameJson) ? nameJson.GetString() : null,
                        Url = s.TryGetProperty("url", out var malIdJson) ? malIdJson.GetString() : null,
                    }).ToList();
                animeModel.MalId = data.GetProperty("mal_id").GetInt16();
                animeModel.MyAnimeListUrl = data.GetProperty("url").GetString();
                animeModel.AnimeCoverImage = jpg.GetProperty("image_url").GetString();
                animeModel.TrailerEmbedUrl = trailer.GetProperty("url").GetString();
                animeModel.TrailerUrl = trailer.GetProperty("embed_url").GetString();
                animeModel.Title = data.GetProperty("title").GetString();
                animeModel.TitleEnglish = data.GetProperty("title_english").GetString();
                animeModel.TitleJapanese = data.GetProperty("title_japanese").GetString();
                animeModel.TransmissionMedia = data.GetProperty("type").GetString();
                animeModel.MediaOriginalSource = data.GetProperty("source").GetString();
                animeModel.Episodes = data.GetProperty("episodes").GetInt16();
                animeModel.Status = data.GetProperty("status").GetString();
                animeModel.Airing = data.GetProperty("airing").GetBoolean();
                animeModel.AiredFrom = aired.GetProperty("from").GetDateTimeOffset();
                animeModel.EpisodeDuration = data.GetProperty("duration").GetString();
                animeModel.AgeRating = data.GetProperty("rating").GetString();
                animeModel.Score = data.GetProperty("score").GetDouble();
                animeModel.ScoredByUser = data.GetProperty("scored_by").GetInt32();
                animeModel.Rank = data.GetProperty("rank").GetInt32();
                animeModel.Synopsis = data.GetProperty("synopsis").GetString();
                animeModel.Background = data.GetProperty("background").GetString();
                animeModel.Season = data.GetProperty("season").GetString();
                animeModel.BroadcastedWeekDayAndTime = broadcast.GetProperty("string").GetString();
                animeModel.MediaProducers = producers;
                animeModel.MediaLicensors = licensors;
                animeModel.MediaStudios = studios;
                animeModel.MediaGenres = genres;
                animeModel.MediaThemes = theme;
                animeModel.MediaDemographics = demographic;
                animeModel.StreamingWebsites = streaming;
            }
            return animeModel;
        }

        public override void Write(Utf8JsonWriter writer, AnimeModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
