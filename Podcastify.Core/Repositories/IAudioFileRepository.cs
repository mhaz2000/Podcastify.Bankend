using Podcastify.Core.Entities;
using Podcastify.Core.Repositories.Base;

namespace Podcastify.Core.Repositories
{
    public interface IAudioFileRepository : IRepository<AudioFile>
    {
        Task<Guid> AddAudioFile(AudioFile audioFile);
    }
}
