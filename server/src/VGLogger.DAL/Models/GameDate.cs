using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGLogger.DAL.Models
{
    [Table("game_dates")]
    public class GameDate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
