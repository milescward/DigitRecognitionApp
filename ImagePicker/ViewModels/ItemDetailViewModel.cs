using System;
using System.Threading.Tasks;
using ImagePicker.Models;
using ImagePicker.Services.AzureServices;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ImagePicker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private ViewImage image;

        public ViewImage VMimage { get; set; }
        public bool IsNewImage { get; set; }

        public int VMimageIDnum
        {
            get { return VMimage.IDnum; }
            private set
            {
                VMimage.IDnum = value;
                OnPropertyChanged();
            }
        }

        public string VMimagePath
        {
            get { return VMimage.Path; }
            set
            {
                VMimage.Path = value;
                OnPropertyChanged();
            }
        }

        public byte[] VMimageVIData
        {
            get { return VMimage.VIData; }
            set
            {
                VMimage.VIData = value;
                OnPropertyChanged();
            }
        }

        public string VMimageResult
        {
            get { return VMimage.Result; }
            set
            {
                VMimage.Result = value;
                OnPropertyChanged();
            }
        }

        public async Task<ImageSource> TakeImage()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync
                (new StoreCameraMediaOptions());

            if (photo != null)
            {
                VMimagePath = photo.Path;
                return ImageSource.FromStream(() => { return photo.GetStream(); });
            }
            return null;
        }

        public async Task<string> GetResponseString()
        {
            var proj = new AzureCompVisionProj();
            return await proj.ConvertImage(VMimagePath);
        }

        public async Task<string> GetResponseStringCV()
        {
            var client = ComputerVisionService.GetCVClient();
            VMimageResult = await ComputerVisionService
                .ExtractUrlLocal(client, VMimagePath);
            return VMimageResult;
        }

        public ItemDetailViewModel(ViewImage image = null)
        {
            IsNewImage = image == null;

            if (image != null)
            {
                VMimage = image;
                VMimageIDnum = image.IDnum;
                VMimagePath = image.Path;
                VMimageResult = image.Result;
                VMimageVIData = image.VIData;
            }
            else
            {
                VMimage = new ViewImage();
            }
        }
    }
}
