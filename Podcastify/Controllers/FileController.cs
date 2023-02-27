using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Podcastify.Application.Commands;
using Podcastify.Application.Services.FileServices;
using System.IO;

namespace Podcastify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        private readonly string _fileStoragePath;
        public FileController(IConfiguration configuration, IFileService fileService)
        {
            _configuration = configuration;
            _fileService = fileService;
            _fileStoragePath = _configuration["FileStoragePath"] ??
                throw new ApplicationException("There is no path for storing files in project configuration.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FileCommand command)
        {
           var fileId = await _fileService.StoreFile(command.File, _fileStoragePath);

            return Ok(fileId);
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(Guid id)
        {
            var file = await _fileService.GetFile(id, _fileStoragePath);
            var fileStream = file.Item1;
            var fileName = file.Item2;

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var cdStr = $"inline; filename=\"{fileName}\"";

            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Disposition");
            Response.Headers.Add("Content-Disposition", cdStr);
            Response.Headers.Add("X-Content-Type-Options", "nosniff");

            return File(fileStream, contentType, fileName);
        }
    }
}
