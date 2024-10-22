using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivroMente.Domain.Exceptions
{
    public class LivroMenteException : Exception
    {
        public LivroMenteException(string message) : base(message){}
        public LivroMenteException(string message, Exception innerException) : base(message, innerException){}
    }
}