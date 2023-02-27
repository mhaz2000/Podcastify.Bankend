using Podcastify.Core.Entities;
using Podcastify.Core.Repositories;
using Podcastify.Infrastructure.Data;
using Podcastify.Infrastructure.Repositories.Base;

namespace Podcastify.Infrastructure.Repositories
{
    public class AudioFileRepository : Repository<AudioFile>, IAudioFileRepository
    {
        public AudioFileRepository(DataContext context) : base(context)
        {
        }

        public async Task<Guid> AddAudioFile(AudioFile audioFile)
        {
            await Context.AudioFiles.AddAsync(audioFile);
            return audioFile.Id;
        }
    }
}
