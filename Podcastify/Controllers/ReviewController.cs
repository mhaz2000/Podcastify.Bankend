using Microsoft.AspNetCore.Mvc;
using Podcastify.Application.Commands;
using Podcastify.Application.Services.Review_Services;

namespace Podcastify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReviewCommand command)
        {
            var reviewId = await _reviewService.AddReview(command);
            return Ok(reviewId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ReviewCommand command)
        {
            await _reviewService.UpdateReview(id, command);
            return Ok("Review is updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _reviewService.Remove(id);
            return Ok("Review is removed successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _reviewService.GetReview(id);
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int pageSize, int pageIndex)
        {
            var reviewObj = await _reviewService.GetReviews(pageSize, pageIndex);
            return Ok(reviewObj);
        }
    }
}
