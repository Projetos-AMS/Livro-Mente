using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.UploadCommands
{
    public class UploadGetAllCommand : IRequest<List<string>>
    {
        
    }
}