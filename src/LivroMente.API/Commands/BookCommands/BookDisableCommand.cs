using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.API.Commands.BookCommands
{
    public class BookDisableCommand :IRequest<bool?>
    {
        public BookDisableCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}