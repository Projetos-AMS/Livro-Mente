using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Dtos;

namespace LivroMente.Service.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
          public List<OrderDto> GetOrder();
          public Task<OrderDto> GetOrderDetails(string id);
          public List<OrderDto> GetOrderDetailsByUser(string userId);
         
    }
}