using System;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services.Data
{
    public interface ILocalDataService
    {
        void Initialize();
        void AddPhoto(Photo photo);
        Task<Photo> GetPhoto();
        void DeletePhoto();
    }
}
