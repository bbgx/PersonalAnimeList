using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeList.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; } = "user";
    }
}
