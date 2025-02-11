using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dtos;

public class AssignmentDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres")]
    [MaxLength(100, ErrorMessage = "O campo Nome precisa ter no máximo 100 caracteres")]
    public string Name { get; set; }

    [MaxLength(255, ErrorMessage = "O campo Descrição precisa ter no máximo 255 caracteres")]
    public string Description { get; set; }
}
