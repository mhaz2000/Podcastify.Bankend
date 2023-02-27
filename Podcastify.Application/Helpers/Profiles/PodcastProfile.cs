using AutoMapper;
using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;
using Podcastify.Core.Entities;

namespace Podcastify.Application.Helpers.Profiles
{
    public class PodcastProfile : Profile
    {
        public PodcastProfile()
        {
            CreateMap<PodcastCommand, Podcast>();
            CreateMap<Podcast, PodcastDto>().ForMember(c => c.Date, t => t.MapFrom(c => c.CreatedAt.ToLongDateString()));
        }
    }
}
