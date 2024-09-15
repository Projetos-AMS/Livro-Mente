using LivroMente.Domain.Commands.AdminCommands;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Domain.ViewModels;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.AdminHandler
{
    public class GetAllOrdersHandler : IRequestHandler<AdminAllOrdersCommand,List<AllOrders>>
    {
        private readonly IBaseService<Order> _service;

        public GetAllOrdersHandler(IBaseService<Order> service)
        {
            _service = service;
        }
        public async Task<List<AllOrders>> Handle(AdminAllOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = await _service.GetAll();
            
            float total = 0;
            foreach (var item in orders)
            {
                total += item.ValueTotal;
            }

            var allOrders = orders.Select(order => new AllOrders{
                UserId = order.UserId,
                PaymentId = order.PaymentId,
                Date = order.Date,
                ValueTotal = order.ValueTotal,
                Total = total
            }).ToList();

            return allOrders;
        }
    }
}