using System.Net;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using LivroMente.API.Commands.OrderCommands;



namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] 
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOrderService _order;

        public OrderController(IMediator mediator,IOrderService order)
        {
            _mediator = mediator;
            _order = order;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var orders = _order.GetOrder();
            if (orders == null) return NoContent();
            return Ok(orders);
        }

        [HttpGet("{Id}")]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(string Id)
        {
            var order = await _order.GetOrderDetails(Id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpGet("{UserId}/orders")]
        // [Authorize(Roles = "admin")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByUserOrder(string UserId)
        {
            var order =  _order.GetOrderDetailsByUser(UserId);
            if (order == null) return NotFound();
            return Ok(order);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] OrderAddCommand command)
        {
            var response = await  _mediator.Send(command);
            if(!response) return BadRequest();
            return CreatedAtRoute(response,response);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string Id)
        {
            var cmd = new OrderDisableCommand(Id);
            var response = await _mediator.Send(cmd);
            if(response == null) return NotFound();
            if(!response.Value) return BadRequest();
            return Ok();
        }









    }

}