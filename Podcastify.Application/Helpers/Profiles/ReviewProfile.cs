using AutoMapper;
using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;
using Podcastify.Core.Entities;

namespace Podcastify.Application.Helpers.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewCommand, Review>();
            CreateMap<Review, ReviewDto>().ForMember(c => c.Date, t => t.MapFrom(c => c.CreatedAt.ToLongDateString()));
        }
    }
}
