using Microsoft.Extensions.DependencyInjection;
using Module3HW2.Providers;
using Module3HW2.Providers.Abstractions;
using Module3HW2.Services;
using Module3HW2.Services.Abstractions;

namespace Module3HW2
{
    public class Starter
    {
        public void Start()
        {
            var starter = new ServiceCollection()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<Application>()
                .BuildServiceProvider();
            var app = starter.GetService<Application>();
            app.Run();
        }
    }
}
