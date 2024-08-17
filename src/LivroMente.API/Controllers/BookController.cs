using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.BookCommands;
using LivroMente.Domain.Requests;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IMediator _mediator;

        public BookController(BookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAll();
            if (books.Count() == 0) return NoContent();
            return Ok(books);
        }

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var book = await _bookService.GetById(Id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] BookAddCommand command)
        {
            var response = await _mediator.Send(command);
            if (!response) return BadRequest();
            return CreatedAtRoute(response, response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid Id, [FromBody] BookRequest request)
        {
            var cmd = new BookUpdateCommand(Id, request);
            var response = await _mediator.Send(cmd);
            if (!response) return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var cmd = new BookDeleteCommand(Id);
            var response = await _mediator.Send(cmd);
            if (!response) return BadRequest();
            return Ok();
        }
    }
}