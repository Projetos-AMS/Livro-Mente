using LivroMente.Data.Context;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Service.Dtos;
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

        public  List<OrderDto> GetOrder()
        {
           var orders = _context.Order
                .Include(u => u.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(b => b.Book)
                    .Select(o => new OrderDto
                    {
                        Id = o.Id,
                        Status = o.Status,
                        Date = o.Date,
                        ValueTotal = o.ValueTotal,
                        User = new UserDto { CompleteName = o.User.CompleteName}
                    }).ToList();

            return orders;
            
        }

        public async Task<OrderDto> GetOrderDetails(string id)
        {
            var order = _context.Order
                .Where(o => o.Id == id)
                    .Include(u => u.User)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(b => b.Book)
                    .Select(o => new OrderDto{
                        Id = o.Id,
                        UserId = o.UserId,
                        Date = o.Date,
                        Status = o.Status,
                        ValueTotal = o.ValueTotal,
                        User = new UserDto{ CompleteName = o.User.CompleteName},
                        OrderDetails = o.OrderDetails
                            .Select(od => new OrderDetailsDto{
                                BookId = od.BookId,
                                Amount = od.Amount,
                                ValueUni = od.ValueUni,
                                Book = new BookDto
                                {
                                    Title = od.Book.Title,
                                    Author = od.Book.Author,
                                    PublishingCompany = od.Book.PublishingCompany,
                                    Value = od.Book.Value,
                                    Category = new CategoryDto{
                                    Description = od.Book.CategoryBook.Description,
                                   }
                                }
                      }).ToList()
                    
                }).FirstOrDefault();

            return order;


        }

        public  List<OrderDto> GetOrderDetailsByUser(string userId)
        {
             var order = _context.Order
                .Where(o => o.UserId == userId)
                    .Include(u => u.User)
                    .Include(o => o.OrderDetails)
                        .ThenInclude(b => b.Book)
                    .Select(o => new OrderDto{
                        Id = o.Id,
                        UserId = o.UserId,
                        Date = o.Date,
                        Status = o.Status,
                        ValueTotal = o.ValueTotal,
                        User = new UserDto{ CompleteName = o.User.CompleteName},
                        OrderDetails = o.OrderDetails
                            .Select(od => new OrderDetailsDto{
                                BookId = od.BookId,
                                Amount = od.Amount,
                                ValueUni = od.ValueUni,
                                Book = new BookDto
                                {
                                    Title = od.Book.Title,
                                    Author = od.Book.Author,
                                    PublishingCompany = od.Book.PublishingCompany,
                                    Value = od.Book.Value,
                                    UrlImg = od.Book.UrlImg,
                                    UrlBook = od.Book.UrlBook,
                                    Category = new CategoryDto{
                                    Description = od.Book.CategoryBook.Description,
                                   }
                                }
                      }).ToList()
                    
                }).ToList();

            return order;
        }
    }
}