using System.IO;
using System.Threading.Tasks;
using ImagePicker.Models;
using ImagePicker.Services;
using ImagePicker.Services.AzureServices;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace ImagePicker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
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

        public void SaveAsync()
        {
            VMimageVIData = File.ReadAllBytes(VMimagePath);
            MessagingCenter.Send(this, "SaveImage", VMimage);
        }

        public async Task<ImageSource> ChooseImageAsync()
        {
            string path = await DependencyService
                .Get<IPhotoPickerService>().ReturnFilePathAsync();

            if (!string.IsNullOrEmpty(path))
            {
                VMimagePath = path;
                return ImageSource.FromFile(path);
            }
            return null;
            
        }

        public async Task<ImageSource> TakeImageAsync()
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

        public async Task<string> GetResponseStringAsync()
        {
            var proj = new AzureCompVisionProj();
            return await proj.ConvertImage(VMimagePath);
        }

        public async Task<string> GetResponseStringCVAsync()
        {
            var client = ComputerVisionService.GetCVClient();
            VMimageResult = await ComputerVisionService
                .ExtractUrlLocal(client, VMimagePath);
            return VMimageResult;
        }

        public ItemDetailViewModel(ViewImage image)
        {
            //IsNewImage = image == null;

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

        public ItemDetailViewModel()
        {
            VMimage = new ViewImage();
        }
    }
}
