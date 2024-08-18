using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.UploadCommands
{
    public class UploadGetByNameCommand : IRequest<string>
    {
        public string FileName { get; set; }
        public UploadGetByNameCommand(string fileName)
        {
            FileName = fileName;
        }
    }
}