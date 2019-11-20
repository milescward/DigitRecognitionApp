using ImagePicker.Models;

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
