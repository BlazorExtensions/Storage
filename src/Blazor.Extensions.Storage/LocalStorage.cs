using Blazor.Extensions.Storage.Interfaces;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;

namespace Blazor.Extensions.Storage
{
    public class LocalStorage : IStorage
    {
        public int Length => RegisteredFunction.Invoke<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.LOCAL_STORAGE);
        public void Clear() => RegisteredFunction.InvokeUnmarshalled<object>(MethodNames.CLEAR_METHOD, StorageTypeNames.LOCAL_STORAGE);

        public TItem GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return RegisteredFunction.Invoke<TItem>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public string Key(int index) => RegisteredFunction.Invoke<string>(MethodNames.KEY_METHOD, StorageTypeNames.LOCAL_STORAGE, index);

        public void RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            RegisteredFunction.InvokeUnmarshalled<object>(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key);
        }

        public void SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            RegisteredFunction.Invoke<object>(MethodNames.SET_ITEM_METHOD, StorageTypeNames.LOCAL_STORAGE, key, JsonUtil.Serialize(item));
        }
    }
}
