using LivroMente.Domain.Commands.UserCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.UserHandler
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, bool>
    {
        private readonly UserService _userService;
        public UserDeleteHandler( UserService userService){_userService = userService;}
        public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteUserAsync(request.UserId);
        }
    }
}