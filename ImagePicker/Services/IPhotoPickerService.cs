using System;
using System.IO;
using System.Threading.Tasks;

namespace ImagePicker.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
        Task<string> ReturnFilePathAsync();
    }
}
