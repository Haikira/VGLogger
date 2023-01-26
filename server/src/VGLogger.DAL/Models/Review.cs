using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGLogger.DAL.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("star_rating")]
        public int StarRating { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("date_reviewed")]
        public DateTime DateReviewed { get; set; }

        [Column("game_id")]
        public int GameId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
    }
}
