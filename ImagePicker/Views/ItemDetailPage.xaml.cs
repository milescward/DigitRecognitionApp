using System;
using System.ComponentModel;
using Xamarin.Forms;
using ImagePicker.ViewModels;
using System.IO;
using System.Linq;
using ImagePicker.Services;
using ImagePicker.Models;

namespace ImagePicker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible (false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public string Path { get; set; }
        public string Result { get; set; }


        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                viewModel.VMimageVIData = File.ReadAllBytes(Path);
            }
            catch (Exception ex)
            {
                await DisplayAlert
                    ("Error", "Enter all information or press cancel",
                    "Cancel", "Ok then");
            }

            
            MessagingCenter.Send(this, "SaveImage", viewModel.VMimage);
            await Navigation.PopToRootAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            string path = await DependencyService
                .Get<IPhotoPickerService>().ReturnFilePathAsync();

            if (!string.IsNullOrEmpty(path))
            {
                image.Source = ImageSource.FromFile(path);
            }

            viewModel.VMimagePath = path;

            (sender as Button).IsEnabled = true;
        }
        async void OnConvertToTextClicked(object sender, EventArgs e)
        {

        }
    }
}