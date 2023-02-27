using Microsoft.EntityFrameworkCore;
using Podcastify.Core.Entities;

namespace Podcastify.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
