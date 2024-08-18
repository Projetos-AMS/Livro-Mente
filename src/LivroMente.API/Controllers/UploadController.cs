using System.Net;
using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
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
        [DisableRequestSizeLimit]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UploadProfilePicture(IFormFile file)
        {
            if (file == null) return BadRequest("File not found.");

            var cmd = new UploadAddCommand(file);
            var response = await  _mediator.Send(cmd);
            return Ok(new {path = response});
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var files = new UploadGetAllCommand();
            if(files == null) return NoContent();
            var request = await _mediator.Send(files);
            return Ok(request);
        }

        [HttpGet ("{fileName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByName(string fileName)
        {
            var file = new UploadGetByNameCommand(fileName);
            var request = _mediator.Send(file);
             if(request == null) return NotFound();
            return Ok(request);
        }

        [HttpDelete("{fileName}")]
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