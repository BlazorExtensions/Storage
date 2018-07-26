using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Storage
{
    public class SessionStorage : IStorage
    {
        public Task<int> Length() => JSRuntime.Current.InvokeAsync<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.SESSION_STORAGE);
        public Task Clear() => JSRuntime.Current.InvokeAsync<object>(MethodNames.CLEAR_METHOD, StorageTypeNames.SESSION_STORAGE);

        public async Task<TItem> GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            // HACK: While we wait for https://github.com/aspnet/Blazor/issues/1205 to be fixed we just get back a string and deserialize it in C# land 
            var json = await JSRuntime.Current.InvokeAsync<object>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
            
            return Json.Deserialize<TItem>(json.ToString());
        }

        public Task<string> Key(int index) => JSRuntime.Current.InvokeAsync<string>(MethodNames.KEY_METHOD, StorageTypeNames.SESSION_STORAGE, index);

        public Task RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return JSRuntime.Current.InvokeAsync<object>(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
        }

        public Task SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return JSRuntime.Current.InvokeAsync<object>(MethodNames.SET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key, Json.Serialize(item));
        }
    }
}
