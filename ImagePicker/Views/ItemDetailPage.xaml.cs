using System;
using System.ComponentModel;
using Xamarin.Forms;
using ImagePicker.ViewModels;
using System.IO;
using ImagePicker.Services;
using ImagePicker.Models;

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
                viewModel.SaveAsync();
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert($"Error", $"{ex.Message}", "Cancel");
            }
            MessagingCenter.Send(this, "SaveImage", viewModel.VMimage);
            
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        async void OnChooseImageButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            try
            {
                image.Source = await viewModel.ChooseImageAsync();
                image.Rotation = 0;
            }
            catch(Exception except)
            {
                await DisplayAlert($"Error", $"{except.Message}", "Cancel");
            }

            (sender as Button).IsEnabled = true;
        }

        async void OnTakeImageButtonClicked(object sender, EventArgs e)
        {
            image.Rotation = 0;
            (sender as Button).IsEnabled = false;
            try
            {
                image.Source = await viewModel.TakeImageAsync();
                image.Rotation = 90;
            }
            catch(Exception exception)
            {
                await DisplayAlert($"Error", $"{exception.Message}", "Cancel");
            }

            (sender as Button).IsEnabled = true;
        }

        async void OnConvertToTextClickedGroup(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            ConversionResult.Text = await viewModel.GetResponseStringAsync();

            (sender as Button).IsEnabled = true;
        }

        async void OnConvertToTextClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            ConversionResult.Text = await viewModel.GetResponseStringCVAsync();

            (sender as Button).IsEnabled = true;
        }
    }
}