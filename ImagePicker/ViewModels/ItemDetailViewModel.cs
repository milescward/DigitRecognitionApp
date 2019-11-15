using System;
using Xamarin.Forms;

namespace ImagePicker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Image ViewImage { get; set; }
        public Image Photo { get; set; }
        public ItemDetailViewModel(Image image = null)
        {
            ViewImage = image;
        }
    }
}
