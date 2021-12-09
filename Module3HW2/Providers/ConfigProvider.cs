using Module3HW2.Models;
using Module3HW2.Providers.Abstractions;
using Module3HW2.Services.Abstractions;
using Newtonsoft.Json;

namespace Module3HW2.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private const string _path = "./config.json";
        private readonly IFileService _fileService;

        public ConfigProvider(IFileService fileService)
        {
            _fileService = fileService;
        }

        public Config GetConfig()
        {
            return JsonConvert.DeserializeObject(_fileService.Read(_path), typeof(Config)) as Config;
        }
    }
}
