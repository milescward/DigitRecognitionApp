using System;
using SQLite;
using Xamarin.Forms;

namespace ImagePicker.Models
{
    public class ViewImage : Image
    {
        [PrimaryKey, AutoIncrement]
        public int IDnum { get; set; }
        public string Path { get; set; }
        public byte[] VIData  { get; set; }

        public ViewImage()
        {

        }
    }
}