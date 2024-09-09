using System.Net;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Domain.ViewModels;
using LivroMente.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
         private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleService _roleService;
        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager, RoleService roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleService = roleService;
        }

        
        [HttpGet] 
        // [Authorize(Roles = "Admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var entity = await _roleService.GetAll();
            return Ok(entity);
        }

        [HttpPost("CreateRole")]
        [AllowAnonymous]  
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
        [AllowAnonymous] 
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
