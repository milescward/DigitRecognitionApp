using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ImagePicker.Views;
using ImagePicker.Models;

namespace ImagePicker.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ViewImage> Images { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Id = "Images";
            Images = new ObservableCollection<ViewImage>();
            LoadItemsCommand = new Command(async () =>
            await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ViewImage>
                (this, "AddImage", async (obj, item) =>
            {
                var newImage = item as ViewImage;
                Images.Add(newImage);
                await DataStore.AddItemAsync(newImage);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Images.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Images.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}