using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Storage
{
    public class SessionStorage : IStorage
    {
        IJSRuntime jsRuntime;

        public SessionStorage(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public Task<int> Length() => this.jsRuntime.InvokeAsync<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.SESSION_STORAGE);
        public Task Clear() => this.jsRuntime.InvokeAsync<object>(MethodNames.CLEAR_METHOD, StorageTypeNames.SESSION_STORAGE);

        public Task<TItem> GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.jsRuntime.InvokeAsync<TItem>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
        }

        public Task<string> Key(int index) => this.jsRuntime.InvokeAsync<string>(MethodNames.KEY_METHOD, StorageTypeNames.SESSION_STORAGE, index);

        public Task RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.jsRuntime.InvokeAsync<object>(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
        }

        public Task SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.jsRuntime.InvokeAsync<TItem>(MethodNames.SET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key, item);
        }
    }
}
