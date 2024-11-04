using System.Net;
using LivroMente.API.Commands.AdminCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace LivroMente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] 
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Route("allOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = new AdminAllOrdersCommand();
            var request = await _mediator.Send(orders);
            if(request == null) return NoContent();
            return Ok(request);
        }

    }
}