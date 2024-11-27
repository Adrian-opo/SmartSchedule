using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dtos
{
    public class FunctionaryCreateDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome precisa ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [MinLength(11, ErrorMessage = "O campo CPF precisa ter no mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O campo CPF precisa ter no máximo 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo SIAPE é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O campo SIAPE precisa ter no máximo 20 caracteres")]
        public string Siape { get; set; }
    }

    public class FunctionaryUpdateDto : FunctionaryCreateDto
    {
    }
}
