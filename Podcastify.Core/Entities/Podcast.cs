using System.ComponentModel.DataAnnotations;

namespace Podcastify.Core.Entities
{
    public class Podcast
    {
        public Podcast()
        {
            CreatedAt = DateTime.Now;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }
        public int EpisodeNumber { get; set; }

        public Guid AudioId { get; set; }
        public Guid? ImageId { get; set; }
    }
}
