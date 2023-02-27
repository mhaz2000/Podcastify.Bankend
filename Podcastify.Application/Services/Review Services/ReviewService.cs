using AutoMapper;
using Podcastify.Application.Commands;
using Podcastify.Application.DTOs;
using Podcastify.Core.Entities;
using Podcastify.Core.Repositories.Base;

namespace Podcastify.Application.Services.Review_Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> AddReview(ReviewCommand command)
        {
            var review = _mapper.Map<Review>(command);
            await _unitOfWork.ReviewRepository.AddAsync(review);
            await _unitOfWork.CommitAsync();

            return review.Id;
        }

        public async Task<ReviewDto> GetReview(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            if (review is null)
                throw new ApplicationException("Review cannot be found");

            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<object> GetReviews(int pageSize, int pageIndex)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetWithPagingAsync(pageSize, pageIndex);
            var reviewsDto = _mapper.Map<IEnumerable<ReviewDto>>(reviews);

            return new { reviews = reviewsDto, total = _unitOfWork.ReviewRepository.GetTotal() };
        }

        public async Task Remove(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            if (review is null)
                throw new ApplicationException("Review cannot be found");

            _unitOfWork.ReviewRepository.Remove(review);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateReview(Guid id, ReviewCommand command)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            if (review is null)
                throw new ApplicationException("Review cannot be found");

            review = _mapper.Map<Review>(command);
            _unitOfWork.ReviewRepository.Update(review);
            await _unitOfWork.CommitAsync();
        }
    }
}
