namespace LivroMente.Service.Interfaces
{
    public interface IBlobService
    {
        Task<Uri> UploadFileBlobAsyn(string blobContainerName, Stream content, string contentType, string fileName);
        Task<IEnumerable<string>> GetFileBlobAsync(string blobContainerName);
        Task<string> GetByNameFileBlobAsync (string blobContainerName,string fileName);
        Task DeleteBlobAsync(string blobContainerName,string fileName);
    }
}