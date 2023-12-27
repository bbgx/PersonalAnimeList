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

                BaseAnimeModelConverter.ReadBaseModelProperties(animeModel, data);
            }
            return animeModel;
        }
        public override void Write(Utf8JsonWriter writer, AnimeModel value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
