using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchedule.Models
{
    [Table("scheduled")]
    public class Scheduled
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")] 
        public string Description { get; set; }

        [Column("start")] 
        public DateTime Start { get; set; }
        
        [Column("end")]
        public DateTime End { get; set; }
        
        
        public ICollection<Assigned> Assigneds { get; set; } = new List<Assigned>();

    }
}