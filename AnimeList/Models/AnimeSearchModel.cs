using AnimeList.DTO;

namespace AnimeList.Models
{
    public class AnimeSearchModel
    {
        public Pagination? Pagination { get; set; }
        public List<BaseAnimeModelDTO>? Data { get; set; }
    }

    public partial class Pagination
    {
        public int? LastVisiblePage { get; set; }
        public bool? HasNextPage { get; set; }
        public int? CurrentPage { get; set; }
        public PaginationItems? Items { get; set; }
    }

    public partial class PaginationItems 
    {
        public int? Count { get; set; }
        public int? Total { get; set; }
        public int? PerPage { get; set; }
    }
}
