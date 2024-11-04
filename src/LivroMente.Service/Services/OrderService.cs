using LivroMente.Data.Context;
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

        public List<Order> GetOrder()
        {
            IQueryable<Order> entity = _context.Order
                .Include(u => u.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(b => b.Book);

            return entity.ToList();
        }

        // public async Task<Order> GetOrderDetails(Guid id)
        // {
        //     var order = _context.Order
        //          .Include(o => o.OrderDetails)
        //              .ThenInclude(b => b.Book)
        //          .FirstOrDefault(o => o.Id == id);

        //     return order;


        // }


    }
}