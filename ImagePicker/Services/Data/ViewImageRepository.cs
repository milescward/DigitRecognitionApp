using System;
using SQLite;
using ImagePicker.Models;
using System.Collections.Generic;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace ImagePicker.Services.Data
{
    public class ViewImageRepository : ILocalDataService
    {
        private SQLiteAsyncConnection _database;
        public string StatusMessage { get; set; }

        public ViewImageRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ViewImage>();
        }

        public async Task AddImageAsync(ViewImage image)
        {
            try
            {
                await _database.InsertAsync(image);
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Error occurred, image {image} was not saved {ex.Message}";
            }
        }

        public async Task<IEnumerable<ViewImage>> GetAllImagesAsync()
        {
            try
            {
                return await _database.Table<ViewImage>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data {ex.Message}";
            }
            return new List<ViewImage>();
        }

        public async Task<ViewImage> GetImageAsync(int id)
        {
            var image = _database.Table<ViewImage>()
                        .Where(i => i.IDnum == id)
                        .FirstOrDefaultAsync();

            return await image;
        }
    }
}
