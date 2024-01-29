using AnimeICollection.Models.AnimeModel;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AnimeList.Models
{
    public class CharacterModelConverter : JsonConverter<List<CharacterModel>>
    {
        public override List<CharacterModel> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var characterModels = new List<CharacterModel>();
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;
                var dataArray = root.GetProperty("data").EnumerateArray();

                foreach (var data in dataArray)
                {
                    var character = data.GetProperty("character");
                    var model = new CharacterModel
                    {
                        MalId = character.GetProperty("mal_id").GetInt32(),
                        Name = character.GetProperty("name").GetString(),
                        CharacterImage = character.GetProperty("images").GetProperty("jpg").GetProperty("image_url").GetString()
                    };
                    model.Role = data.GetProperty("role").GetString();
                    model.VoiceActors = ReadVoiceActors(data.GetProperty("voice_actors"));
                    characterModels.Add(model);
                }
            }

            return characterModels;
        }

        private List<CharacterModel.VoiceActor> ReadVoiceActors(JsonElement voiceActorsElement)
        {
            var voiceActors = new List<CharacterModel.VoiceActor>();
            foreach (var v in voiceActorsElement.EnumerateArray())
            {
                var person = v.GetProperty("person");
                var voiceActor = new CharacterModel.VoiceActor
                {
                    MalId = person.GetProperty("mal_id").GetInt32(),
                    Name = person.GetProperty("name").GetString(),
                    Language = v.GetProperty("language").GetString(),
                    VoiceActorImage = person.GetProperty("images").GetProperty("jpg").GetProperty("image_url").GetString()
                };
                voiceActors.Add(voiceActor);
            }

            return voiceActors;
        }

        public override void Write(Utf8JsonWriter writer, List<CharacterModel> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
