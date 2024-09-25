// using LivroMente.Domain.Commands.UserCommands;
// using LivroMente.Domain.Models.IdentityEntities;
// using LivroMente.Domain.Requests;
// using LivroMente.Service.Interfaces;
// using MediatR;

// namespace LivroMente.API.Handlers.UserHandler
// {
//     public class LoginHandler : IRequestHandler<LoginCommand, string>
//     {
//         private readonly IUserService<User> _userService;
//         public LoginHandler(IUserService<User> userService) {_userService = userService; }
//         public  Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
//         {
//             var request = new LoginRequest{ Email = command.Email, Password = command.Password };
//             return _userService.LoginAsync(request);
//         }

//     }
// }