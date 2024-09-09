using System.ComponentModel.DataAnnotations;

namespace LivroMente.Domain.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        // [Required(ErrorMessage = "Senha é obrigatória.")]
        // [DataType(DataType.Password)]
        // [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Password { get; set; }
    }
}