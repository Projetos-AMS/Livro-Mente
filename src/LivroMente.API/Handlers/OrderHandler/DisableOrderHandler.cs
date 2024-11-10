using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.API.Commands.OrderCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.OrderHandler
{
    public class DisableOrderHandler : IRequestHandler<OrderDisableCommand, bool>
    {
        private readonly IOrderService _orderService;

        public DisableOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> Handle(OrderDisableCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetById(request.Id);
            if(order == null) return false;

            order.Disabled();
            await _orderService.Save();
            return true;
        }
    }
}