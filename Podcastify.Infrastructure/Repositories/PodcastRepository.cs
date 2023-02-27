using Podcastify.Core.Entities;
using Podcastify.Core.Repositories;
using Podcastify.Infrastructure.Data;
using Podcastify.Infrastructure.Repositories.Base;

namespace Podcastify.Infrastructure.Repositories
{
    public class PodcastRepository : Repository<Podcast>, IPodcastRepository
    {
        public PodcastRepository(DataContext context) : base(context)
        {
        }
    }
}
