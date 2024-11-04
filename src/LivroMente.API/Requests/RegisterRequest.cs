using System.ComponentModel.DataAnnotations;
namespace LivroMente.API.Requests
{
    public class RegisterRequest
    {
        public string CompleteName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [RegularExpression("Admin|Usuario", ErrorMessage = "Role deve ser 'Admin' ou 'Usuario'.")]
        public string Role { get; set; }
        public bool IsActive { get; set; } = true; 
    }
}