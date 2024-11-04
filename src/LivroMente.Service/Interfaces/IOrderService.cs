using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Models.OrderModel;

namespace LivroMente.Service.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
         public List<Order> GetOrder();
        //  public Task<Order> GetOrderDetails(Guid id);
    }
}