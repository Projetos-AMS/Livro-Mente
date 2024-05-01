namespace LivroMente.Service.Interfaces
{
    public interface IBlobService
    {
        Task<Uri> UploadFileBlobAsyn(string blobContainerName, Stream content, string contentType, string fileName);
    }
}