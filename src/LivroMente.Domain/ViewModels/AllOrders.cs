using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroMente.Domain.ViewModels
{
    public class AllOrders
    {
        public string UserId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public float ValueTotal { get; set; }
        public float Total { get; set; }
    }
}