using LivroMente.Service.Dtos;

namespace LivroMente.Service.Interfaces
{
    public interface IUserService
    {
         Task<IEnumerable<UserDto>> GetUserRolesInclude();
         Task<UserDto> GetByIdAsync(Guid userId);
        Task<string> RegisterAsync(string completeName, string email, string role, string password );
         Task<string>  LoginAsync(string  email, string password);
         Task<bool> AssignRoleAsync(string userId, string role);
         Task<bool> DeleteUserAsync(Guid userId);
    }

}