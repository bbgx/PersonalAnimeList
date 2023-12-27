using AnimeList.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeICollection.Models.AnimeModel
{
    [Table("Anime")]
    public class AnimeModel : BaseAnimeModel
    {
        [Key]
        public int Id { get; set; }
    }
}
