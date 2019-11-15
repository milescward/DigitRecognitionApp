using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImagePicker.Services
{
    public interface IDataStore<Photo>
    {
        Task<bool> AddItemAsync(Photo item);
        Task<bool> UpdateItemAsync(Photo item);
        Task<bool> DeleteItemAsync(int id);
        Task<Photo> GetItemAsync(int id);
        Task<IEnumerable<Photo>> GetItemsAsync(bool forceRefresh = false);
    }
}
