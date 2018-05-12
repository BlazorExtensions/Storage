using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Extensions.Storage
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            return services.AddSingleton<SessionStorage>()
                .AddSingleton<LocalStorage>();
        }
    }
}
