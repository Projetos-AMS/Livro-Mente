using LivroMente.Domain.Requests;
using LivroMente.Domain.ViewModels;
using MediatR;

namespace LivroMente.Domain.Commands.UserCommands
{
    public class RegisterCommand : IRequest<UserViewModel>
    {
        public RegisterCommand(RegisterRequest request)
        {
            CompleteName = request.CompleteName;
            Email = request.Email;
            Password = request.Password;
            ConfirmPassword = request.ConfirmPassword;
            Role = request.Role;
            IsActive = request.IsActive;
        }

        public string CompleteName { get; }
        public string UserName { get; }
        public string Email { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }
        public string Role { get; }
        public bool IsActive { get; }
    }
}