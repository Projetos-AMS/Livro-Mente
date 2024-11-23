using LivroMente.API.Commands.UploadCommands;
using LivroMente.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LivroMente.API.Handlers.UploadHandler
{
    public class GetAllUploadHandler : IRequestHandler<UploadGetAllCommand, List<string>>
    {
        private readonly IBlobService _blobService;

        public GetAllUploadHandler(IBlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<List<string>> Handle(UploadGetAllCommand request, CancellationToken cancellationToken)
        {
            if(request == null)return null; //throw new ArgumentNullException(nameof(request), "File not found.");
            
            var result = await _blobService.GetFileBlobAsync("livromente");
            if(result == null) return null;
            return result.ToList();
        }
    }
}