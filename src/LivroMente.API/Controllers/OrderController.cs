using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.OrderCommands;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] 
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly OrderService _orderService;

        public OrderController(IMediator mediator,OrderService orderService)
        {
            _mediator = mediator;
            _orderService = orderService;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetAll()
        {
            var orders =  _orderService.GetOrderDetails();
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