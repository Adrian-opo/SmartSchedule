using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
    
    public class MemberCreateDto
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "O campo Time é obrigatório.")]
        public int TeamId { get; set; }
        
        [Required(ErrorMessage = "O campo Papel é obrigatório.")]
        public int RoleId { get; set; }
    }

    public class MemberUpdateDto : MemberCreateDto
    {
        
    }
}