using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcastify.Core.Entities
{
    public class AudioFile
    {
        public AudioFile(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName;
            CreatedAt= DateTime.Now;
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
