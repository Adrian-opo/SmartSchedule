using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dtos
{
    public class ScheduledDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    
    public class ScheduledCreateDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "O campo Início é obrigatório.")]
        public DateTime Start { get; set; }
        
        [Required(ErrorMessage = "O campo Fim é obrigatório.")]
        public DateTime End { get; set; }
    }

    public class ScheduledUpdateDto : ScheduledCreateDto
    {
    }
}