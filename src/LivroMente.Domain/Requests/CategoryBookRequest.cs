using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroMente.Domain.Requests
{
    public class CategoryBookRequest
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}