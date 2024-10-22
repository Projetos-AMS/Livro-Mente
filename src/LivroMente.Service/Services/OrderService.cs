using LivroMente.Data.Context;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivroMente.Service.Services
{
    public class OrderService : BaseService<Order>,IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context) : base(context)
        {
            _context = context;
        }

        public List<Order> GetOrderDetails()
        {
            IQueryable<Order> entity = _context.Order
            .Include(o => o.OrderDetails);

            return entity.ToList();
        }
    }
}