using Microsoft.AspNetCore.Http;

namespace Podcastify.Application.Commands
{
    public class FileCommand
    {
        public IFormFile File { get; set; }
    }
}
