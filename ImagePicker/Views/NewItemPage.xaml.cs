using System;
using System.ComponentModel;
using Xamarin.Forms;

using ImagePicker.ViewModels;

namespace ImagePicker.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible (false)]
    public partial class NewItemPage : ContentPage
    {
        public ItemDetailViewModel viewModel;

        public Image photo { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPhoto", photo);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}