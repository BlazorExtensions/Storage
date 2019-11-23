using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;

namespace Blazor.Extensions.Storage
{
    internal class SessionStorage : Storage, ISessionStorage
    {
        public SessionStorage(IJSRuntime runtime) : base(runtime, StorageTypeNames.SESSION_STORAGE) {}
    }
}