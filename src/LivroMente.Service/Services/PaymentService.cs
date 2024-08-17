using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Data.Context;
using LivroMente.Domain.Models.PaymentModel;

namespace LivroMente.Service.Services
{
    public class PaymentService : BaseService<Payment>
    {
        public PaymentService(DataContext context) : base(context)
        {
        }
    }
}