using LivroMente.Domain.Models.IdentityEntities;

namespace LivroMente.Service.Interfaces
{
    public interface IUserService <TUser> where TUser : User
    {
         List<UserRole> GetUserRolesInclude();
        Task<string> RegisterAsync(string completeName, string email, string role, string password );
         Task<string>  LoginAsync(string  email, string password);
         Task<bool> AssignRoleAsync(string userId, string role);
         Task<bool> DeleteUserAsync(Guid userId);
    }

}