using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;

namespace LivroMente.API.Handlers
{
    public class CreateUploadHandler : IRequestHandler<UploadAddCommand, string>
    {
        private readonly IBlobService _blobService;

        public CreateUploadHandler(IBlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<string> Handle(UploadAddCommand request, CancellationToken cancellationToken)
        {
            if (request.File == null) throw new ArgumentNullException(nameof(request.File), "File not found.");

            var result = await _blobService.UploadFileBlobAsyn(
                "livromente",
                request.File.OpenReadStream(),
                request.File.ContentType,
                request.File.FileName

            );

            return result.AbsoluteUri;
        }
    }
}