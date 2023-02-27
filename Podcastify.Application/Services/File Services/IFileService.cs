using Microsoft.AspNetCore.Http;

namespace Podcastify.Application.Services.FileServices
{
    public interface IFileService
    {
        Task<Guid> StoreFile(IFormFile file, string path);

        Task<(FileStream, string)> GetFile(Guid id, string path);
    }
}
