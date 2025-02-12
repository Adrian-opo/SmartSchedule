using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchedule.Models
{
    [Table("assignment")]
    public class Assignment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }
        
        public ICollection<Assigned> AssignedMembers { get; set; } = new List<Assigned>();
        
    }
}