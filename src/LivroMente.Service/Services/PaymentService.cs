using LivroMente.Data.Context;
using LivroMente.Domain.Models.PaymentModel;

namespace LivroMente.Service.Services
{
    public class PaymentService : BaseService<Payment>
    {
        public PaymentService(DataContext context) : base(context){}
    }
}