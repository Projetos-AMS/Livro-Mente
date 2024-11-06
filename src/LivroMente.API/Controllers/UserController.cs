using System.Net;
using LivroMente.API.Commands.UserCommands;
using LivroMente.API.Requests;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, IUserService userService)
        {
            _userService = userService;
            _mediator = mediator;
        }
        
        [HttpGet("roles")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> GetUserRoles()
        {
                var entity = _userService.GetUserRolesInclude();
                if (entity.Result.Any())
                    return Ok(entity.Result);
                return NoContent(); 
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> GetUserbyId(Guid id)
        {
                var entity = _userService.GetByIdAsync(id);
                if (entity.Result != null)
                    return Ok( entity.Result);
                return NoContent(); 
        }
       
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var command = new RegisterCommand(request);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : Unauthorized();
        }

        [HttpPost("login")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var command = new LoginCommand(request);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : Unauthorized();
        }
  
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
         public async Task<IActionResult>Delete(Guid Id) 
         {
            var command = new UserDeleteCommand(Id);
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest();   
         }
    }
}