using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroMente.API.ViewModels
{
    public class AllOrders
    {
        public string UserId { get; set; }
        public DateTime Date { get; set; } 
        public float ValueTotal { get; set; }
        public float Total { get; set; }
    }
}