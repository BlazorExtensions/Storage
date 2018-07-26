using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blazor.Extensions.Storage.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Blazor.Extensions.Storage
            services.AddStorage();

            services.AddLogging(builder => builder
                .AddBrowserConsole()
                .SetMinimumLevel(LogLevel.Trace)
            );
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
