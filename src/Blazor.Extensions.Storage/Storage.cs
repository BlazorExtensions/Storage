using System;
using System.Threading.Tasks;
using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;

namespace Blazor.Extensions.Storage
{
    internal abstract class Storage : IStorage
    {
        private readonly IJSRuntime runtime;
        private readonly string storageName;

        protected Storage(IJSRuntime runtime, string storageName)
        {
            this.runtime = runtime;
            this.storageName = storageName;
        }

        public ValueTask<int> Length() => this.runtime.InvokeAsync<int>(MethodNames.LENGTH_METHOD, this.storageName);

        public ValueTask Clear() => this.runtime.InvokeVoidAsync(MethodNames.CLEAR_METHOD, this.storageName);

        public ValueTask<TItem> GetItem<TItem>(string key)
        {
            if(string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeAsync<TItem>(MethodNames.GET_ITEM_METHOD, this.storageName, key);
        }

        public ValueTask<string> Key(int index) => this.runtime.InvokeAsync<string>(MethodNames.KEY_METHOD, this.storageName, index);

        public ValueTask RemoveItem(string key)
        {
            if(string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeVoidAsync(MethodNames.REMOVE_ITEM_METHOD, this.storageName, key);
        }

        public ValueTask SetItem<TItem>(string key, TItem item)
        {
            if(string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeVoidAsync(MethodNames.SET_ITEM_METHOD, this.storageName, key, item);
        }

        private class MethodNames
        {
            public const string LENGTH_METHOD = "BlazorExtensions.Storage.Length";
            public const string KEY_METHOD = "BlazorExtensions.Storage.Key";
            public const string GET_ITEM_METHOD = "BlazorExtensions.Storage.GetItem";
            public const string SET_ITEM_METHOD = "BlazorExtensions.Storage.SetItem";
            public const string REMOVE_ITEM_METHOD = "BlazorExtensions.Storage.RemoveItem";
            public const string CLEAR_METHOD = "BlazorExtensions.Storage.Clear";
        }
    }
}
