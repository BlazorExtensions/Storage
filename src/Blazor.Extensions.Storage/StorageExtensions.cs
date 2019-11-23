using Blazor.Extensions.Storage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Extensions.Storage
{
    public static class StorageExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            return services.AddScoped<ISessionStorage, SessionStorage>()
                .AddScoped<ILocalStorage, LocalStorage>();
        }
    }
}
