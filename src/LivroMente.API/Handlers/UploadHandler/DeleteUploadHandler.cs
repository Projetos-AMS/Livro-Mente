using LivroMente.API.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class DeleteUploadHandler : IRequestHandler<UploadDeleteCommand, bool>
    {
        private readonly IBlobService _blobService;

        public DeleteUploadHandler(IBlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<bool> Handle(UploadDeleteCommand request, CancellationToken cancellationToken)
        {
             var file = await _blobService.GetByNameFileBlobAsync("livromente",request.FileName);
             if(file == null) return false;
             await _blobService.DeleteBlobAsync("livromente",request.FileName);
             return true;
        }
    }
}