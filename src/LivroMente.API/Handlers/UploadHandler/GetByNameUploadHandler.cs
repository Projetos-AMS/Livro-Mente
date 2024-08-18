using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class GetByNameUploadHandler : IRequestHandler<UploadGetByNameCommand, string>
    {
        private readonly BlobService _blobService;

        public GetByNameUploadHandler(BlobService blobService)
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