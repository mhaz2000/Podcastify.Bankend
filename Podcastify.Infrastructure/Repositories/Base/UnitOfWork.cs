using Podcastify.Core.Repositories;
using Podcastify.Core.Repositories.Base;
using Podcastify.Infrastructure.Data;

namespace Podcastify.Infrastructure.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private PodcastRepository _podcastRepository;
        private AudioFileRepository _audioFileRepository;
        private ReviewRepository _reviewRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IPodcastRepository PodcastRepository => _podcastRepository ?? new PodcastRepository(_context);

        public IAudioFileRepository AudioFileRepository => _audioFileRepository ?? new AudioFileRepository(_context);

        public IReviewRepository ReviewRepository => _reviewRepository ?? new ReviewRepository(_context);

        public async Task<int> CommitAsync()
        {
            var result = await _context.SaveChangesAsync();
            Dispose();
            return result;
        }

        public int Commit()
        {
            var result = _context.SaveChanges();
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
