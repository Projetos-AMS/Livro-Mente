using LivroMente.API.Commands.UserCommands;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.UserHandler
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        public LoginHandler(IUserService userService) {_userService = userService; }
        public  Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            return _userService.LoginAsync(command.Email, command.Password);
        }
    }
}