using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchedule.Models
{
    [Table("member")]
    public class Member
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("role_id")]
        public int RoleId { get; set; }
        
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("team_id")]
        public int TeamId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
        public virtual Role Role { get; set; }
        
        public ICollection<Assigned> Assigneds { get; set; } = new List<Assigned>();
    }
}