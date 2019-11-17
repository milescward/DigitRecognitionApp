using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImagePicker.Models;

namespace ImagePicker.Services.Data
{
    public interface ILocalDataService
    {
        Task AddImageAsync(ViewImage image);
        Task<ViewImage> GetImageAsync(int id);
        Task<IEnumerable<ViewImage>> GetAllImagesAsync();
    }
}
