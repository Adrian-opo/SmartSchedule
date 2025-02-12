using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartSchedule.Models;

[Table("assigned")]

public class Assigned
{
    //id, member_id, assignment_id,
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("member_id")]
    public int MemberId { get; set; }
    
    [Column("assignment_id")]
    public int AssignmentId { get; set; }
    
    public virtual Member Member { get; set; }
    public virtual Assignment Assignment { get; set; }
}