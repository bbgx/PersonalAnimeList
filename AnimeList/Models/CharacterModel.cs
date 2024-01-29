using AnimeICollection.Models.AnimeModel;
using System.ComponentModel.DataAnnotations;

namespace AnimeList.Models
{
    public class CharacterModel
    {
        [Key]
        public int Id { get; set; }
        public int MalId { get; set; }
        public string? CharacterImage { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public List<VoiceActor>? VoiceActors { get; set; }
        public partial class VoiceActor
        {
            [Key]
            public int Id { get; set; }
            public int MalId { get; set;}
            public string? Name { get; set; }
            public string? Language { get; set; }
            public string? VoiceActorImage { get; set; }
            public List<CharacterModel>? Character { get; set; }
        }

        public int AnimeId { get; set; }
        public AnimeModel? Anime { get; set; }
    }
}
