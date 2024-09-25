using System.Net;
using LivroMente.Domain.Commands.UserCommands;
using LivroMente.Domain.Requests;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, UserService userService)
        {
            _userService = userService;
            _mediator = mediator;
        }
        
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Get()
        {
                var entity = _userService.GetUserRolesInclude();
                if (entity.Any())
                    return Ok( entity);
                return NoContent(); 
        }
       
        [HttpPost("Register")]
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

        [HttpPost("Login")]
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
  
        [HttpDelete("{Id}")]
        [Authorize(Roles = "admin")]
        //[AllowAnonymous] 
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