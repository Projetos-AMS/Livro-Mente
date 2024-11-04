using MediatR;

namespace LivroMente.API.Commands.UploadCommands
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