using LivroMente.API.Commands.OrderCommands;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.OrderHandler
{
    public class CreateOrderHandler : IRequestHandler<OrderAddCommand, bool>
    {
        private readonly IOrderService _orderService;

        public CreateOrderHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = request.OrderRequest.OrderDetails.Select(od => new OrderDetails{
                    BookId = od.BookId,
                    Amount = od.Amount,
                    ValueUni = od.ValueUni
                }).ToList();


            var order = new Order
            (
                request.OrderRequest.UserId,
                request.OrderRequest.PaymentId,
                request.OrderRequest.Date,
                request.OrderRequest.ValueTotal,
                request.OrderRequest.Status,
                orderDetails
            );

            var result = await _orderService.Add(order);
            if (!result) return false;
            return true;
        }
    }
}