using System.Threading.Tasks;

namespace Blazor.Extensions.Storage.Interfaces
{
    public interface IStorage
    {
        ValueTask<TItem> GetItem<TItem>(string key);
        ValueTask<string> Key(int index);
        ValueTask RemoveItem(string key);
        ValueTask SetItem<TItem>(string key, TItem item);
        ValueTask Clear();
        ValueTask<int> Length();
    }
}
