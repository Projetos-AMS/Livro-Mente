using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Requests;
using MediatR;

namespace LivroMente.Domain.Commands.CategoryBookCommands
{
    public class CategoryBookUpdateCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CategoryBookRequest CategoryBookRequest { get; set; }
        public CategoryBookUpdateCommand(Guid id, CategoryBookRequest categoryBookRequest)
        {
            Id = id;
            CategoryBookRequest = categoryBookRequest;
        }
    }
}