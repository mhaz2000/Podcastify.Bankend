namespace Podcastify.Core.Entities
{
    public class Review
    {
        public Review()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
