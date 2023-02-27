using Microsoft.AspNetCore.Http;
using Podcastify.Core.Repositories.Base;

namespace Podcastify.Application.Services.FileServices
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(FileStream, string)> GetFile(Guid id, string path)
        {
            var fileModel = await _unitOfWork.AudioFileRepository.GetByIdAsync(id);
            if (fileModel is null)
                throw new ApplicationException("Podcast audio cannot be found.");

            var filePath = Path.Combine(path, $"{id}.dat");

            if (!File.Exists(filePath))
                throw new ApplicationException("File cannot be found.");

            return (new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read), fileModel.FileName);
        }

        public async Task<Guid> StoreFile(IFormFile file, string path)
        {
            var fileId = Guid.NewGuid();
            var dir = Path.Combine(path, $"{fileId}.dat");

            using (var fileStream = new FileStream(dir, FileMode.CreateNew, FileAccess.Write, FileShare.Write))
            {
                await file.CopyToAsync(fileStream);
            }

            await _unitOfWork.AudioFileRepository.AddAsync(new Core.Entities.AudioFile(fileId, file.FileName));
            await _unitOfWork.CommitAsync();
            return fileId;
        }
    }
}
