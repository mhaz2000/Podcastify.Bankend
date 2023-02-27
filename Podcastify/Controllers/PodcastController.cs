using Microsoft.AspNetCore.Mvc;
using Podcastify.Application.Commands;
using Podcastify.Application.Services.PodcastServices;

namespace Podcastify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodcastController : Controller
    {
        private readonly IPodcastService _podcastService;
        public PodcastController(IPodcastService podcastService)
        {
            _podcastService = podcastService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PodcastCommand command)
        {
            var podcastId = await _podcastService.AddPodcast(command);
            return Ok(podcastId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PodcastCommand command)
        {
            await _podcastService.UpdatePodcast(id, command);
            return Ok("Podcast is updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _podcastService.RemovePodcast(id);
            return Ok("Podcast is removed successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var podcast = await _podcastService.GetPodcastById(id);
            return Ok(podcast);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPodcasts(int pageSize, int pageIndex)
        {
            var podcastObj = await _podcastService.GetPodcasts(pageSize, pageIndex);
            return Ok(podcastObj);
        }

        [HttpGet("most-popular")]
        public async Task<IActionResult> GetMostPopularPodcast()
        {
            var podcast = await _podcastService.GetMostPopularPodcast();
            return Ok(podcast);
        }
    }
}