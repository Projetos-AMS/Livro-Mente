using System.Net;
using LivroMente.API.Requests;
using LivroMente.API.Commands.BookCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMediator _mediator;

        public BookController(IBookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
       // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();
            if (books.Count() == 0) return NoContent();
            return Ok(books);
        }

        [HttpGet("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(string Id)
        {
            var book = await _bookService.GetById(Id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] BookAddCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response) return BadRequest();
            return CreatedAtRoute(response, response);
        }

        [HttpPut("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(string Id, [FromBody] BookRequest request)
        {
            var cmd = new BookUpdateCommand(Id, request);
            var response = await _mediator.Send(cmd);
            if (!response) return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string Id)
        {
            var cmd = new BookDeleteCommand(Id);
            var response = await _mediator.Send(cmd);
            if (!response) return BadRequest();
            return Ok();
        }
    }
}