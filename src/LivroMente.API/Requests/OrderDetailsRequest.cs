using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroMente.API.Requests
{
    public class OrderDetailsRequest
    {
        public string OrderId { get; set; }
        public string BookId { get; set; }
        public int Amount { get; set; }
        public float ValueUni { get; set; }
        
    }
}