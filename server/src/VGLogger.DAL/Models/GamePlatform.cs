using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGLogger.DAL.Models
{
    [Table("games_platforms")]
    public class GamePlatform
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("game_id")]
        public int GameId { get; set; }

        [Column("platform_id")]
        public int PlatformId { get; set; }

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
