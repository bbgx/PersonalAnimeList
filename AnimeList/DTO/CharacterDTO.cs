namespace AnimeList.DTO
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public List<VoiceActorDTO>? VoiceActors { get; set; }
    }
}
