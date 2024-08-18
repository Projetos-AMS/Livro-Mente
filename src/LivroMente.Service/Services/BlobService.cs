using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using LivroMente.Service.Interfaces;

namespace LivroMente.Service.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task DeleteBlobAsync(string blobContainerName, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            var blobCliente = containerClient.GetBlobClient(fileName);
            await blobCliente.DeleteIfExistsAsync();
        }

        public async Task<string> GetByNameFileBlobAsync(string blobContainerName, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            var file = blobClient.Uri.AbsoluteUri;
            return file;
        }

        public async Task<IEnumerable<string>> GetFileBlobAsync(string blobContainerName)
        {
            var containerClient = GetContainerClient(blobContainerName);
            var items = new List<string>();
            await foreach (var item in containerClient.GetBlobsAsync())
            {
                items.Add(item.Name);
            }
            return items;
        }

        public async Task<Uri> UploadFileBlobAsyn(string blobContainerName, Stream content, string contentType, string fileName)
        {
            var containerClient = GetContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(content,new BlobHttpHeaders { ContentType = contentType});
            return blobClient.Uri;
        }

        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);
            return containerClient;
        }
    }
}