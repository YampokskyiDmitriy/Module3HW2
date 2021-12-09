using Module3HW2.Models;
using Module3HW2.Services.Abstractions;
using Module3HW2.Providers.Abstractions;

namespace Module3HW2.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        private readonly Config _config;
        public ConfigService(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            _config = _configProvider.GetConfig();
        }

        public Config GetConfig()
        {
            return _config;
        }
    }
}
