using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SmartSchedule.Models;

[Table("assigned")]

public class Assigned
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("member_id")]
    public int MemberId { get; set; }
    
    [Column("assignment_id")]
    public int AssignmentId { get; set; }
    
    [Column("scheduled_id")]
    public int ScheduledId { get; set; }
    
    [JsonIgnore]
    public virtual Member Member { get; set; }
    
    [JsonIgnore]
    public virtual Assignment Assignment { get; set; }
    
    [JsonIgnore]
    public virtual Scheduled Scheduled { get; set; }

}