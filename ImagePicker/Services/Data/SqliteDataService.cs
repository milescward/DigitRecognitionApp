using System;
using SQLite;
using System.IO;
using ImagePicker.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        //public void AddPhoto(Photo photo)
        //{
            
        //}

        //public void DeletePhoto()
        //{
        //    _database.Execute("DELETE FROM Photo");
        //}

        //public Photo GetPhoto()
        //{
        //    return _database.Table<Photo>().FirstOrDefault();
        //}

        //public IList<Photo> GetAllPhotosAsync()
        //{
        //    return _database.
        //}

        public Task<bool> AddPhotoAsync(Photo photo)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> GetPhotoAsync()
        {
            throw new NotImplementedException();
        }

        public void DeletePhotoAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Photo>> ILocalDataService.GetAllPhotosAsync()
        {
            throw new NotImplementedException();
        }

    }
}
