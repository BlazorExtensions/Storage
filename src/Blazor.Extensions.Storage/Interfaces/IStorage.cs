using System.Threading.Tasks;

namespace Blazor.Extensions.Storage.Interfaces
{
    public interface IStorage
    {
        Task<TItem> GetItem<TItem>(string key);
        Task<string> Key(int index);
        Task RemoveItem(string key);
        Task SetItem<TItem>(string key, TItem item);
        Task Clear();
        Task<int> Length();
    }
}
