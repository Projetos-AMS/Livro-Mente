using LivroMente.Domain.Commands.OrderCommands;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.OrderHandler
{
    public class CreateOrderHandler : IRequestHandler<OrderAddCommand, bool>
    {
        private readonly OrderService _orderService;

        public CreateOrderHandler(OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserId = request.UserId,
                PaymentId = request.PaymentId,
                Date = request.Date,
                ValueTotal = request.ValueTotal,
                OrderDetails = request.OrderDetails,
            };

            var result = await _orderService.Add(order);
            if (!result) return false;
            return true;
        }
    }
}