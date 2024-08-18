using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivroMente.Domain.Commands.UploadCommands;
using LivroMente.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LivroMente.API.Handlers
{
    public class CreateUploadHandler : IRequestHandler<UploadAddCommand, string>
    {
        private readonly BlobService _blobService;

        public CreateUploadHandler(BlobService blobService)
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