namespace Podcastify.Application.Commands
{
    public class PodcastCommand
    {
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid AudioId { get; set; }
        public Guid? ImageId { get; set; }
    }
}
