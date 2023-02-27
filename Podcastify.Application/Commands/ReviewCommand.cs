namespace Podcastify.Application.Commands
{
    public class ReviewCommand
    {
        public int Rate { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}
