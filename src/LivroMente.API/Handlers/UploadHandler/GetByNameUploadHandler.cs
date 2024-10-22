using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class GetByNameUploadHandler : IRequestHandler<UploadGetByNameCommand, string>
    {
        private readonly IBlobService _blobService;

        public GetByNameUploadHandler(IBlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<string> Handle(UploadGetByNameCommand request, CancellationToken cancellationToken)
        {
            var file = await _blobService.GetByNameFileBlobAsync("livromente",request.FileName);
            if(file == null) throw new ArgumentNullException(nameof(request.FileName), "File not found.");
            return file;
        }
    }
}