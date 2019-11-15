using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services
{
    public class MockDataStore : IDataStore<Photo>
    {
        readonly List<Photo> items;

        public MockDataStore()
        {
            items = new List<Photo>()
            {
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new Photo { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Photo item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Photo item)
        {
            var oldItem = items.Where((Photo arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Photo arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Photo> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Photo>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}