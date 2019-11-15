using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImagePicker.Services
{
    public interface IDataStore<ViewImage>
    {
        Task<bool> AddItemAsync(ViewImage image);
        Task<bool> UpdateItemAsync(ViewImage image);
        Task<bool> DeleteItemAsync(int id);
        Task<ViewImage> GetItemAsync(int id);
        Task<IEnumerable<ViewImage>> GetItemsAsync(bool forceRefresh = false);
    }
}
