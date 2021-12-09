using System.IO;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Services
{
    public class FileService : IFileService
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
