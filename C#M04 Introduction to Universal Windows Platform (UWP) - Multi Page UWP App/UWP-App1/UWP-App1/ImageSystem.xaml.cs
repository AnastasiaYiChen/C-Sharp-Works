using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImageSystem : Page
    {
        public ImageSystem()
        {
            this.InitializeComponent();
        }

        private async void UploadImage_BTN_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                userInput.Text = "Picked photo: " + file.Name;
                string newPic = "ProfilePic" + file.FileType;
                var storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var newPicFile = await file.CopyAsync(storageFolder, newPic, Windows.Storage.NameCollisionOption.ReplaceExisting);
                image_box.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new System.Uri(newPicFile.Path));
            }
            else
            {
                userInput.Text = "Operation cancelled.";
            }
        }
    }
}
