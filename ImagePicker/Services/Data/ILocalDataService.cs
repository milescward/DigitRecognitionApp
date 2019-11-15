using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services.Data
{
    public interface ILocalDataService
    {
        void Initialize();
        Task<bool> AddPhotoAsync(Photo photo);
        Task<Photo> GetPhotoAsync();
        void DeletePhotoAsync();
        Task<IEnumerable<Photo>> GetAllPhotosAsync();
    }
}
