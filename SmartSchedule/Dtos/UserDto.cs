using System.ComponentModel.DataAnnotations;

namespace SmartSchedule.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome precisa ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [MinLength(11, ErrorMessage = "O campo CPF precisa ter no mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O campo CPF precisa ter no máximo 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail precisa ser um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        [MinLength(11, ErrorMessage = "O campo Celular precisa ter no mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O campo Celular precisa ter no máximo 11 caracteres")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Usuário precisa ter no mínimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "O campo Usuário precisa ter no máximo 20 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(6, ErrorMessage = "O campo Senha precisa ter no mínimo 6 caracteres")]
        [MaxLength(20, ErrorMessage = "O campo Senha precisa ter no máximo 20 caracteres")]
        public string Password { get; set; }

    }

    public class UserUpdateDto : UserCreateDto
    {
    }
}
