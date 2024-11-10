using System.Net;
using LivroMente.API.Commands.PaymentCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] 
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _payment;
        private readonly IMediator _mediator;

        public PaymentController(IPaymentService payment,IMediator mediator)
        {
            _payment = payment;
            _mediator = mediator;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpGet]
         // [Authorize(Roles = "admin")]
        [AllowAnonymous] 
        public async Task<IActionResult> GetAll()
        {
            var payments = await _payment.GetAll();
            if (payments.Count() == 0) return NoContent();
            return Ok(payments);

        }

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(string Id)
        {
            var payment = await _payment.GetById(Id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] PaymentAddCommand command)
        {
          var response = await _mediator.Send(command);
          if(!response) return BadRequest();
          return CreatedAtRoute(response,response);
        }

        // [HttpPut("{Id}")]
        // [ProducesResponseType((int)HttpStatusCode.NotFound)]
        // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        // [ProducesResponseType((int)HttpStatusCode.OK)]
        // public async Task<IActionResult> Put(Guid Id, [FromBody] PaymentRequest paymentRequest)
        // {
        //     var cmd = new PaymentUpdateCommand(Id,paymentRequest);
        //     var response = await _mediator.Send(cmd);
        //     if(!response) return BadRequest();
        //     return Ok();        
        // }

        // [HttpDelete("{Id}")]
        // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        // [ProducesResponseType((int)HttpStatusCode.OK)]
        // public async Task<IActionResult> Delete(Guid Id)
        // {
        //     var cmd = new PaymentDeleteCommand(Id);
        //     var response = await _mediator.Send(cmd);
        //     if(!response) return BadRequest();
        //     return Ok();
        // }
    }
}