using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcastify.Application.DTOs
{
    public class PodcastDto
    {
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public TimeSpan Duration { get; set; }
        public Guid AudioId { get; set; }
        public Guid? ImageId { get; set; }
        public Guid Id { get; set; }
        public string Date { get; set; }
    }
}
