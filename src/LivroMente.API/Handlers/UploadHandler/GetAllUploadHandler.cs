using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Services;
using MediatR;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class GetAllUploadHandler : IRequestHandler<UploadGetAllCommand, List<string>>
    {
        private readonly BlobService _blobService;

        public GetAllUploadHandler(BlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<List<string>> Handle(UploadGetAllCommand request, CancellationToken cancellationToken)
        {
            if(request == null) throw new ArgumentNullException(nameof(request), "File not found.");
            
            var result = await _blobService.GetFileBlobAsync("livromente");
            return result.ToList();
        }
    }
}