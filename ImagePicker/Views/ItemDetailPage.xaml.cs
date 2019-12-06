using System;
using System.ComponentModel;
using Xamarin.Forms;
using ImagePicker.ViewModels;
using System.IO;
using ImagePicker.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ImagePicker.Services.AzureServices;
using ImagePicker.Models;
using System.Threading.Tasks;

namespace ImagePicker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible (false)]
    public partial class ItemDetailPage : ContentPage
    {
        public ViewImage Image { get; set; }
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
                viewModel.VMimageVIData = File.ReadAllBytes(viewModel.VMimagePath);
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

        async void OnChooseImageButtonClicked(object sender, EventArgs e)
        {
            string path = await DependencyService
                .Get<IPhotoPickerService>().ReturnFilePathAsync();

            if (!string.IsNullOrEmpty(path))
            {
                image.Source = ImageSource.FromFile(path);
            }
            image.Rotation = 0;
            viewModel.VMimagePath = path;

            (sender as Button).IsEnabled = true;
        }

        private async void OnTakeImageButtonClicked(object sender, EventArgs e)
        {
            image.Rotation = 0;
            (sender as Button).IsEnabled = false;
            try
            {
                image.Source = await viewModel.TakeImage();
                image.Rotation = 90;
            }
            catch(Exception exception)
            {
                await DisplayAlert("Error", "Error occurred", "Cancel");
            }

            (sender as Button).IsEnabled = true;
        }

        async void OnConvertToTextClickedGroup(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            ConversionResult.Text = await viewModel.GetResponseString();

            (sender as Button).IsEnabled = true;
        }

        async void OnConvertToTextClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            ConversionResult.Text = await viewModel.GetResponseStringCV();

            (sender as Button).IsEnabled = true;
        }
    }
}