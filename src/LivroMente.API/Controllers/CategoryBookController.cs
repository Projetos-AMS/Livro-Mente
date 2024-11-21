using System.Net;
using LivroMente.API.Commands.CategoryBookCommands;
using LivroMente.API.Requests;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryBookController : ControllerBase
    {
        private readonly ICategoryBookService _categoryBook;
        private readonly IMediator _mediator;
    
        
        public CategoryBookController(ICategoryBookService categoryBook, IMediator mediator)
        {
            _categoryBook = categoryBook;
            _mediator = mediator;
        }

        [HttpGet]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryBook.GetAll();
        

            if (categories == null) return NoContent();

            return Ok(categories);
        }

        [HttpGet("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(string Id)
        {
            var category = await _categoryBook.GetById(Id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CategoryBookAddCommand command)
        {
            var response = await  _mediator.Send(command);
            if(!response) return BadRequest();
            return CreatedAtRoute(response,response);
        }

        [HttpPut("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(string Id,[FromBody] CategoryBookRequest categoryBookRequest)
        {
           var cmd = new CategoryBookUpdateCommand(Id, categoryBookRequest);
           var response = await _mediator.Send(cmd);
           if(response == null) return NotFound();
           if(!response.Value) return BadRequest();
           return Ok();
        }

        [HttpDelete("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string Id)
        {
            var cmd = new CategoryBookDeleteCommand(Id);
            var response = await _mediator.Send(cmd);
            if(response == null) return NotFound();
            if(!response.Value) return BadRequest();
            return Ok();
        }

    }

}
