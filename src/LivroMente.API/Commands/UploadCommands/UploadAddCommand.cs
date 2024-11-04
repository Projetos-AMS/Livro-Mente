using MediatR;

namespace LivroMente.API.Commands.UploadCommands
{
    public class UploadAddCommand : IRequest<string>
    {
        public IFormFile File { get; }
        public UploadAddCommand(IFormFile file)
        {
            File = file;
        }
    }
}