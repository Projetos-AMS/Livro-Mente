using LivroMente.Domain.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.UserCommands
{
    public class LoginCommand : IRequest<string>
    {
        public LoginCommand(LoginRequest request){ Email = request.Email; Password = request.Password;}
        public string Email { get; }
        public string Password { get; }
    }
}