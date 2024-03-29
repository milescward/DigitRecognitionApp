﻿using System;
using SQLite;
using System.IO;
using ImagePicker.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace ImagePicker.Services.Data
{
    public class ViewImageRepository : ILocalDataService
    {
        private SQLiteConnection _database;
        public string StatusMessage { get; set; }

        public void Initialize()
        {
            // Create the database if it doesn't exist.
            if (_database == null)
            {
                var libFolder = FileSystem.AppDataDirectory;
                _database = new SQLiteConnection(libFolder);
            }

            // Create a table for a specific model
            _database.CreateTable<ViewImage>();
        }

        public void AddImageAsync(ViewImage image)
        {
            try
            {
                _database.Insert(image);
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Error occurred, image {image} was not saved {ex.Message}";
            }

        }

        public IEnumerable<ViewImage> GetAllImagesAsync()
        {
            try
            {
                return _database.Table<ViewImage>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                    $"Failed to retrieve data {ex.Message}";
            }
            return new List<ViewImage>();
        }

        public ViewImage GetImageAsync(int id)
        {
            var image = _database.Table<ViewImage>()
                        .Where(i => i.IDnum == id);

            return image.FirstOrDefault();
        }
    }
}
