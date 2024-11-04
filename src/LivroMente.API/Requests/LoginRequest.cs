using System.ComponentModel.DataAnnotations;

namespace LivroMente.API.Requests
{
    public class LoginRequest
    {
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}