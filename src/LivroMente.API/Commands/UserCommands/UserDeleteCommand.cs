using MediatR;

namespace LivroMente.API.Commands.UserCommands
{
    public class UserDeleteCommand : IRequest<bool>
    {
        public UserDeleteCommand(Guid userId){UserId = userId;}
        public Guid UserId { get; }
    }
}