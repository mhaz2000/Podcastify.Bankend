using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;

namespace Podcastify.Application.Services.Review_Services
{
    public interface IReviewService
    {
        Task<Guid> AddReview(ReviewCommand command);
        Task UpdateReview(Guid id,ReviewCommand command);
        Task<ReviewDto> GetReview(Guid id);
        Task Remove(Guid id);
        Task<object> GetReviews(int pageSize, int pageIndex);
    }
}
