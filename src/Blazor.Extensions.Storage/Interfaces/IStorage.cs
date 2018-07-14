using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Extensions.Storage.Interfaces
{
    public interface IStorage
    {
        TItem GetItem<TItem>(string key);
        string Key(int index);
        void RemoveItem(string key);
        void SetItem<TItem>(string key, TItem item);
        void Clear();
        int Length { get; }
    }
}
