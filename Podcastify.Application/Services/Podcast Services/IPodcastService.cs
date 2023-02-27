using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;
using Podcastify.Core.Entities;

namespace Podcastify.Application.Services.PodcastServices
{
    public interface IPodcastService
    {
        Task<object> GetPodcasts(int pageSize, int pageIndex);
        Task<Podcast> GetPodcastById(Guid id);
        Task<Podcast> GetMostPopularPodcast();
        Task RemovePodcast(Guid id);
        Task UpdatePodcast(Guid id, PodcastCommand podcast);
        Task<Guid> AddPodcast(PodcastCommand podcast);
    }
}
