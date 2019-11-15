using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImagePicker.Services;
using ImagePicker.Views;
using ImagePicker.Services.Data;

namespace ImagePicker
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            InitApp();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        private void InitApp()
        {
            var dataService = new SqliteDataService();
            dataService.Initialize();
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
