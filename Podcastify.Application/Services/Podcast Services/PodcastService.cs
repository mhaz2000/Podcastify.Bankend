using AutoMapper;
using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;
using Podcastify.Core.Entities;
using Podcastify.Core.Repositories.Base;

namespace Podcastify.Application.Services.PodcastServices
{
    public class PodcastService : IPodcastService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PodcastService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddPodcast(PodcastCommand podcastCommand)
        {
            if (_unitOfWork.PodcastRepository.Any(c => c.Title == podcastCommand.Title))
                throw new ApplicationException("There is already an existing podcast with this title");

            var podcast = _mapper.Map<PodcastCommand, Podcast>(podcastCommand);
            await _unitOfWork.PodcastRepository.AddAsync(podcast);
            await _unitOfWork.CommitAsync();

            return podcast.Id;
        }

        public async Task<Podcast> GetMostPopularPodcast()
        {
            return await _unitOfWork.PodcastRepository.FirstOrDefaultAsync(c => true);
        }

        public async Task<Podcast> GetPodcastById(Guid id)
        {
            var podcast = await _unitOfWork.PodcastRepository.GetByIdAsync(id);
            if (podcast is null)
                throw new ApplicationException("Podcast cannot be found");

            return podcast;
        }

        public async Task<object> GetPodcasts(int pageSize, int pageIndex)
        {
            var podcasts = await _unitOfWork.PodcastRepository.GetWithPagingAsync(pageSize, pageIndex);
            var podcastsDto = _mapper.Map<IEnumerable<Podcast>, IEnumerable<PodcastDto>>(podcasts);
            return new { podcasts = podcastsDto.OrderByDescending(c => c.EpisodeNumber), total = _unitOfWork.PodcastRepository.GetTotal() };
        }

        public async Task RemovePodcast(Guid id)
        {
            var podcast = await _unitOfWork.PodcastRepository.GetByIdAsync(id);
            if (podcast is null)
                throw new ApplicationException("Podcast cannot be found");

            _unitOfWork.PodcastRepository.Remove(podcast);
        }

        public async Task UpdatePodcast(Guid id, PodcastCommand podcastCommand)
        {
            var prevoiusPodcast = await _unitOfWork.PodcastRepository.GetByIdAsync(id);
            if (prevoiusPodcast is null)
                throw new ApplicationException("Podcast cannot be found");

            var podcast = _mapper.Map<PodcastCommand, Podcast>(podcastCommand);

            podcast.Id = prevoiusPodcast.Id;
            _unitOfWork.PodcastRepository.Update(podcast);
        }
    }
}