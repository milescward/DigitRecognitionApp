using System;
using SQLite;
using Xamarin.Forms;

namespace ImagePicker.Models
{
    public class Photo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Path { get; set; }
        public byte[] PhotoData  { get; set; }
    }
}