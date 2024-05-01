using System.Net;
using LivroMente.Domain.Commands.CategoryBookCommands;
using LivroMente.Domain.Requests;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryBookController : ControllerBase
    {
        private readonly CategoryBookService _categoryBookService;
        private readonly IMediator _mediator;

        public CategoryBookController(CategoryBookService categoryBookService, IMediator mediator)
        {
            _categoryBookService = categoryBookService;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryBookService.GetAll();

            if (categories.Count() == 0) return NoContent();

            return Ok(categories);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var category = await _categoryBookService.GetById(Id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CategoryBookAddCommand command)
        {
            var response = await  _mediator.Send(command);
            if(!response) return BadRequest();
            return CreatedAtRoute(response,response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid Id,[FromBody] CategoryBookRequest categoryBookRequest)
        {
           var cmd = new CategoryBookUpdateCommand(Id, categoryBookRequest);
           var response = await _mediator.Send(cmd);
           if(!response) return BadRequest();
           return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var cmd = new CategoryBookDeleteCommand(Id);
            var response = await _mediator.Send(cmd);
            if(!response) return BadRequest();
            return Ok();
        }

    }

}
