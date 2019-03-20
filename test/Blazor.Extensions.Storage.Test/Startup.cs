using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Extensions.Storage.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Blazor.Extensions.Storage
            services.AddStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
