using Newtonsoft.Json;

namespace AnimeList.DTO
{
    public class AnimeResponse
    {
        public class AnimeDTO
        {
            public DataDTO? Data { get; set; }
        }

        public class DataDTO
        {
            public long? MalId { get; set; }
            public string Url { get; set; }
            public Dictionary<string, ImageDTO> Images { get; set; }
            public TrailerDTO Trailer { get; set; }
            public bool? Approved { get; set; }
            public IEnumerable<TitleDTO> Titles { get; set; }
            public string Title { get; set; }
            public string TitleEnglish { get; set; }
            public string TitleJapanese { get; set; }
            public IEnumerable<string> TitleSynonyms { get; set; }
            public string Type { get; set; }
            public string Source { get; set; }
            public long? Episodes { get; set; }
            public string Status { get; set; }
            public bool? Airing { get; set; }
            public AiredDTO Aired { get; set; }
            public string Duration { get; set; }
            public string Rating { get; set; }
            public long? Score { get; set; }
            public long? ScoredBy { get; set; }
            public long? Rank { get; set; }
            public long? Popularity { get; set; }
            public long? Members { get; set; }
            public long? Favorites { get; set; }
            public string Synopsis { get; set; }
            public string Background { get; set; }
            public string Season { get; set; }
            public long? Year { get; set; }
            public BroadcastDTO Broadcast { get; set; }
            public IEnumerable<DemographicDTO> Producers { get; set; }
            public IEnumerable<DemographicDTO> Licensors { get; set; }
            public IEnumerable<DemographicDTO> Studios { get; set; }
            public IEnumerable<DemographicDTO> Genres { get; set; }
            public IEnumerable<DemographicDTO> ExplicitGenres { get; set; }
            public IEnumerable<DemographicDTO> Themes { get; set; }
            public IEnumerable<DemographicDTO> Demographics { get; set; }
            public IEnumerable<RelationDTO> Relations { get; set; }
            public ThemeDTO Theme { get; set; }
            public IEnumerable<ExternalDTO> External { get; set; }
            public IEnumerable<ExternalDTO> Streaming { get; set; }
        }

        public class AiredDTO
        {
            public string From { get; set; }
            public string To { get; set; }
            public PropDTO Prop { get; set; }
        }

        public class PropDTO
        {
            public FromDTO From { get; set; }
            public FromDTO To { get; set; }
            public string String { get; set; }
        }

        public class FromDTO
        {
            public long? Day { get; set; }
            public long? Month { get; set; }
            public long? Year { get; set; }
        }

        public class BroadcastDTO
        {
            public string Day { get; set; }
            public string Time { get; set; }
            public string Timezone { get; set; }
            public string String { get; set; }
        }

        public class DemographicDTO
        {
            public long? MalId { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class ExternalDTO
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public class ImageDTO
        {
            public string ImageUrl { get; set; }
            public string SmallImageUrl { get; set; }
            public string LargeImageUrl { get; set; }
        }

        public class RelationDTO
        {
            public string RelationRelation { get; set; }
            public IEnumerable<DemographicDTO> Entry { get; set; }
        }

        public class ThemeDTO
        {
            public IEnumerable<string> Openings { get; set; }
            public IEnumerable<string> Endings { get; set; }
        }

        public class TitleDTO
        {
            public string Type { get; set; }
            public string TitleTitle { get; set; }
        }

        public class TrailerDTO
        {
            public string YoutubeId { get; set; }
            public string Url { get; set; }
            public string EmbedUrl { get; set; }
        }
    }
}
