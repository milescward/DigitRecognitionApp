using System;
using System.IO;
using System.Threading.Tasks;

namespace ImagePicker.Services.NativeServices
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
