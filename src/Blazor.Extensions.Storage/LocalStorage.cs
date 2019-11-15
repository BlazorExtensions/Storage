using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;

namespace Blazor.Extensions.Storage
{
    internal class LocalStorage : Storage, ILocalStorage
    {
        public LocalStorage(IJSRuntime runtime) : base(runtime, StorageTypeNames.LOCAL_STORAGE) {}
    }
}