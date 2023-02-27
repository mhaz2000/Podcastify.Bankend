namespace Podcastify.Core.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IPodcastRepository PodcastRepository { get; }

        IAudioFileRepository AudioFileRepository { get; }

        IReviewRepository ReviewRepository { get; }

        Task<int> CommitAsync();
        int Commit();
    }
}
