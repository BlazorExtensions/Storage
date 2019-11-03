using System.Threading.Tasks;

namespace Blazor.Extensions.Storage.Interfaces
{
    public interface IStorage
    {
        ValueTask<TItem> GetItemAsync<TItem>(string key);
        ValueTask<string> GetKeyAsync(int index);
        ValueTask RemoveItemAsync(string key);
        ValueTask SetItemAsync<TItem>(string key, TItem item);
        ValueTask ClearAsync();
        ValueTask<int> GetLengthAsync();
    }
}
