using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchedule.Models
{
    [Table("user_team")]
    public class UserTeam
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}