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