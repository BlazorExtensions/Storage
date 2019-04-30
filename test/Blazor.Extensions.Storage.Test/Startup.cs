using Blazor.Extensions.Storage.Test.Interop;
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

            services.AddScoped<InteropStorage>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
