using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGLogger.DAL.Models
{
    [Table("platforms")]
    public class Platform
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; } 

        public ICollection<GamePlatform> GamePlatforms { get; set; }
    }
}