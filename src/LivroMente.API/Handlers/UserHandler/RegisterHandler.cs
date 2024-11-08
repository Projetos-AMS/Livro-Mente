using LivroMente.API.Commands.UserCommands;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.UserHandler
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserService _userService;
        public RegisterHandler(IUserService userService){_userService = userService;}
        public async Task<string> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
             return await _userService.RegisterAsync(command.CompleteName, command.Email, command.Role, command.Password);
        }
    }
}