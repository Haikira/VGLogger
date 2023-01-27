using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGLogger.DAL.Models
{
    [Table("date_types")]
    public class DateType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("type_of_date")]
        public string TypeOfDate { get; set; }
    }
}
