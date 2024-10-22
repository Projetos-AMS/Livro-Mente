// using LivroMente.Domain.Commands.UserCommands;
// using LivroMente.Domain.Models.IdentityEntities;
// using LivroMente.Domain.ViewModels;
// using LivroMente.Service.Interfaces;
// using MediatR;

// namespace LivroMente.API.Handlers.UserHandler
// {
//     public class RegisterHandler : IRequestHandler<RegisterCommand, UserViewModel>
//     {
//         private readonly IUserService<User> _userService;
//         public RegisterHandler(IUserService<User> userService){_userService = userService;}
//         public async Task<UserViewModel> Handle(RegisterCommand command, CancellationToken cancellationToken)
//         {
//             var request = new Domain.Requests.RegisterRequest {
//                 CompleteName = command.CompleteName,
//                 Email = command.Email,
//                 Password = command.Password,
//                 ConfirmPassword = command.ConfirmPassword,
//                 Role = command.Role,
//                 IsActive = command.IsActive,
//             };
//              return await _userService.RegisterAsync(request);
//         }
//     }
// }