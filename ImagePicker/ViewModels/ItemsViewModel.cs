using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ImagePicker.Models;
using ImagePicker.Views;
using Photo = ImagePicker.Models.Photo;

namespace ImagePicker.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Models.Photo> Images { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Id = "Images";
            Images = new ObservableCollection<Photo>();
            LoadItemsCommand = new Command(async () =>
            await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Photo>
                (this, "AddImage", async (obj, item) =>
            {
                var newImage = item as Photo;
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