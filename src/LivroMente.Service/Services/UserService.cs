using LivroMente.Data.Context;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using LivroMente.Service.Dtos;

namespace LivroMente.Service.Services
{
    public class UserService :  IUserService
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        public UserService(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<IEnumerable<UserDto>>  GetUserRolesInclude()
        {
            List<UserDto> users = await _context.User
                                        .Include(u => u.UserRoles)
                                        .ThenInclude(u => u.Role)
                                        .Select(u => new UserDto {
                                            Id = u.Id,
                                            CompleteName = u.CompleteName,
                                            Email = u.Email,
                                            IsActive = u.IsActive,
                                            Roles = u.UserRoles.Select(u => u.Role.Name).ToList()
                                        }).ToListAsync();
            return users;
        }

        public async Task<string> RegisterAsync(string completeName, string email, string role, string password )
        {
            var user = new User
            {
                CompleteName = completeName,
                UserName = email,
                Email = email,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
              throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            
            if (!string.IsNullOrEmpty(role))
              await AssignRoleAsync(user.Id.ToString(), role);

            return await GenerateJWToken(user);
        }
 
        public async Task<string> LoginAsync(string  email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !user.IsActive || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return await GenerateJWToken(user);
        }
        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var formatToken = ("Bearer "+ tokenHandler.WriteToken(token));
            return formatToken;
        }

        public async Task<bool> AssignRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
                throw new Exception("Role does not exist");

            var result = await _userManager.AddToRoleAsync(user, role);
            var token = await GenerateJWToken(user);
            Console.WriteLine($"Generated Token: {token}");
            return result.Succeeded;
        }
         public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            user.IsActive = false; 
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<UserDto> GetByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            List<string> roles = [];
            if(user == null)
                return null;
            
            if (user.UserRoles != null)
            {
               roles = user.UserRoles.Select(u => u.Role.Name).ToList();
            }

            UserDto userDto = new(){
                Id = user.Id,
                CompleteName = user.CompleteName,
                Email = user.Email,
                IsActive = user.IsActive,
                Roles = roles
            };
            return userDto;
        }
    }
}