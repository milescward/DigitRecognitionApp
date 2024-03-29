﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services
{
    public class MockDataStore : ILocalDataService<ViewImage>
    {
        readonly List<ViewImage> items;

        public MockDataStore()
        {
            items = new List<ViewImage>()
            {
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new ViewImage { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(ViewImage item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ViewImage item)
        {
            var oldItem = items.Where((ViewImage arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((ViewImage arg) => arg.IDnum == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ViewImage> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.IDnum == id));
        }

        public async Task<IEnumerable<ViewImage>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}