using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class DeleteUploadHandler : IRequestHandler<UploadDeleteCommand, bool>
    {
        private readonly BlobService _blobService;

        public DeleteUploadHandler(BlobService blobService)
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