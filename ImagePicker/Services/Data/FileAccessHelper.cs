using System;
using Xamarin.Essentials;

namespace ImagePicker.Services.Data
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine
                (FileSystem.AppDataDirectory, filename);
        }
    }
}
