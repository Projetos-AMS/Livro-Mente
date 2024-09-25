using LivroMente.Data.Context;
using LivroMente.Domain.Models.PaymentModel;
using LivroMente.Service.Interfaces;

namespace LivroMente.Service.Services
{
    public class PaymentService : BaseService<Payment>,IPaymentService
    {
        public PaymentService(DataContext context) : base(context){}
    }
}