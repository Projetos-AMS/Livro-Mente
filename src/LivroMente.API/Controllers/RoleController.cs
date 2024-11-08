using System.Net;
using LivroMente.API.ViewModels;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
           // [AllowAnonymous] 
    [ApiController]
    public class RoleController : ControllerBase
    {
         private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRoleService _roleService;
        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, IRoleService roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleService = roleService;
        }
        
        [HttpGet] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var entity = await _roleService.GetAll();
            return Ok(entity);
        }

        [HttpPost("CreateRole")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]      
        public async Task<IActionResult> CreateRole(RoleViewModel roleDto)
        {
            try
            {
                var retorno = await _roleManager.CreateAsync(new Role { Name = roleDto.Name });
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("UpdateUserRole")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRoleViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (model.Delete)
                        await _userManager.RemoveFromRoleAsync(user, model.Role);
                    else
                        await _userManager.AddToRoleAsync(user, model.Role);
                }
                else
                {
                    return NoContent();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR {ex.Message}");
            }
        }
    }
}
