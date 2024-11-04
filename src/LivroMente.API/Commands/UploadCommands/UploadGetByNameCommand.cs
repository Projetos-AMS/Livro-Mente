using MediatR;

namespace LivroMente.API.Commands.UploadCommands
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