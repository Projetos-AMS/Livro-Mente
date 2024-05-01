using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.BookCommands
{
    public class BookDeleteCommand : IRequest<bool>
    {
          public Guid Id { get; set; }
        public BookDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}