using System.ComponentModel.DataAnnotations;

namespace LivroMente.Domain.Requests
{
    public class RegisterRequest
    {
       [Required(ErrorMessage = "Nome completo é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome completo deve ter no máximo 100 caracteres.")]
        public string CompleteName { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmação de senha é obrigatória.")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O papel (role) do usuário é obrigatório.")]
        [RegularExpression("Admin|Usuario", ErrorMessage = "Role deve ser 'Admin' ou 'Usuario'.")]
        public string Role { get; set; }
        public bool IsActive { get; set; } = true; // Valor padrão true
    }
}