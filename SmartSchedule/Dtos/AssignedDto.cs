namespace SmartSchedule.Dtos;

public class AssignedDto
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int AssignmentId { get; set; }
    public MemberDto Member { get; set; }
    public AssignmentDto Assignment { get; set; }
}