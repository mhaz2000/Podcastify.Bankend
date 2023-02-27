using Podcastify.Core.Entities;
using Podcastify.Core.Repositories;
using Podcastify.Infrastructure.Data;
using Podcastify.Infrastructure.Repositories.Base;

namespace Podcastify.Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context)
        {
        }
    }
}
