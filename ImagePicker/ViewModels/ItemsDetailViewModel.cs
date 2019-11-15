using System;

using ImagePicker.Models;

namespace ImagePicker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Photo Photo { get; set; }
        public ItemDetailViewModel(Photo photo = null)
        {
            Photo = photo;
        }
    }
}
