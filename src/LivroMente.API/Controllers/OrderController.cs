using System.Net;
using LivroMente.Domain.Commands.OrderCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


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
            var orders =  _order.GetOrderDetails();
            if (orders.Count() == 0) return NoContent();
            return Ok(orders);
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









    }

}