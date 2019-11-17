using System;
using ImagePicker.Models;
using ImagePicker.Services.Data;
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
        }

        public ImageSource VMimageSource
        {
            get { return VMimage.Source; }
            set
            {
                VMimage.Source = value;
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
            VMimage = image;
        }
    }
}
