using System;
using SQLite;
using System.IO;
using ImagePicker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ImagePicker.Services.Data
{
    public class SqliteDataService : ILocalDataService
    {
        private SQLiteConnection _database;

        public void Initialize()
        {
            // Create the database if it doesn't exist.
            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "DigitPhotosDb.db3");
                _database = new SQLiteConnection(dbPath);
            }

            // Create a table for a specific model
            _database.CreateTable<Photo>();
        }

        public async void AddPhoto(Photo photo)
        {
            _database.Insert(photo);
        }

        public void DeletePhoto()
        {
            _database.Execute("DELETE FROM Photo");
        }

        public async Task<Photo> GetPhoto()
        {
            return _database.Table<Photo>().FirstOrDefault();
        }
    }
}
