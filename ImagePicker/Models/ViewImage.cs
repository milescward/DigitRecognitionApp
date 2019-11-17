using System;
using SQLite;
using Xamarin.Forms;

namespace ImagePicker.Models
{
    [Table ("Images")]
    public class ViewImage : Image
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int IDnum { get; set; }
        public new ImageSource Source { get; set; }
        public string Path { get; set; }
        public byte[] VIData  { get; set; }
        public string Result { get; set; }
    }
}