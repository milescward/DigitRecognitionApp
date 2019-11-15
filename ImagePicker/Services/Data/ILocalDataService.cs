using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services.Data
{
    public interface ILocalDataService
    {
        void Initialize();
        Task<bool> AddPhotoAsync(ViewImage photo);
        Task<ViewImage> GetPhotoAsync();
        void DeletePhotoAsync();
        Task<IEnumerable<ViewImage>> GetAllPhotosAsync();
    }
}
