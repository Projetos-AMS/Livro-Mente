using System.Net;
using LivroMente.API.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
     // [Authorize(Roles = "admin")]
    [AllowAnonymous] 
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly IMediator _mediator;

        public UploadController(IBlobService blobService,IMediator mediator)
        {
            _blobService = blobService;
            _mediator = mediator;
        }

        [HttpPost("")]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null) return BadRequest("File not found.");

            var cmd = new UploadAddCommand(file);
            var response = await  _mediator.Send(cmd);
            if(response == null) return BadRequest();
            return Ok(new {path = response});
        }

        [HttpGet]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var files = new UploadGetAllCommand();
            var request = await _mediator.Send(files);
            if(request == null) return NoContent();
            return Ok(request);
        }

        [HttpGet ("{fileName}")]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByName(string fileName)
        {
            var file = new UploadGetByNameCommand(fileName);
            var request = await _mediator.Send(file);
             if(request == null) return NotFound();
            return Ok(request);
        }

        [HttpDelete("{fileName}")]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var file = new UploadDeleteCommand(fileName);
            var request =  await _mediator.Send(file);
            if(!request) return BadRequest();
            return Ok();
        }
    }
}