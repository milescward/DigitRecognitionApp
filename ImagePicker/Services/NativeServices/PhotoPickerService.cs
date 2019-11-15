using System;
using System.IO;
using System.Threading.Tasks;

namespace ImagePicker.Services.NativeServices
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public PhotoPickerService()
        {
        }

        public Task<Stream> GetImageStreamAsync()
        {
            throw new NotImplementedException();
        }
    }
}
