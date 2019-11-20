using System;
using SQLite;
using ImagePicker.Models;
using System.Collections.Generic;
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
            _database.CreateTableAsync<ViewImage>().Wait();
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

        public async Task<ViewImage> GetImageAsync(ViewImage VIimage)
        {
            var image = _database.Table<ViewImage>()
                        .Where(i => i.IDnum == VIimage.IDnum)
                        .FirstOrDefaultAsync();

            return await image;
        }
    }
}
