using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Domain.Requests;
using LivroMente.Domain.ViewModels;

namespace LivroMente.Service.Interfaces
{
    public interface IUserService <User> where User : class
    {
         List<UserRole> GetUserRolesInclude();
         Task<UserViewModel> RegisterAsync(RegisterRequest request);
         Task<string>  LoginAsync(LoginRequest request);
         Task<bool> AssignRoleAsync(string userId, string role);
    }

}