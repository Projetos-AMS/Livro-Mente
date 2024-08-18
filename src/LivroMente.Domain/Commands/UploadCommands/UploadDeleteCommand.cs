using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace LivroMente.Domain.Commands.UploadCommands
{
    public class UploadDeleteCommand : IRequest<bool>
    {
        public string FileName { get; set; }
        public UploadDeleteCommand(string fileName)
        {
            FileName = fileName;
        }
    }
}