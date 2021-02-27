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
    /// Author: Yi Chen
    public sealed partial class FileSystem : Page
    {
        

        public FileSystem()
        {
            this.InitializeComponent();
        }

        /*Create a file in localFolder. when user input text in "userInput text box", save the text which is just inputed to the local file.*/
        private async void CreateAFile_BTN_Click(object sender, RoutedEventArgs e)
        {

            // Create sample file; replace if exists.
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            // show path 
            FilePath_TxtBox.Text = storageFolder.Path;

            //Save file and name is sample.txt
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            // user input text
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, (string)userInput.Text);
        }

        /*read a file which user inputed*/
        private async void ReadFile_BTN_Click(object sender, RoutedEventArgs e)
        {
            //A file is to get the file with StorageFolder.GetFileAsync.
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.GetFileAsync("sample.txt");

            //Read text from your file by calling the FileIO.ReadTextAsync method.
            readBox.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        }
    }
        
}
