using System;
using Xamarin.Forms;

namespace ImagePicker.Models
{
    public class Photo
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public Image Source { get; set; }

    }
}