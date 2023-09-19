using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyUWPGetStartApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await this.WebView2.EnsureCoreWebView2Async();

            string root = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            string path = root + @"\Html";

            // Get the folder object that corresponds to this absolute path in the file system.
            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(path);
            this.WebView2.CoreWebView2.SetVirtualHostNameToFolderMapping("demo", folder.Path, CoreWebView2HostResourceAccessKind.DenyCors);
            this.WebView2.CoreWebView2.Navigate("https://demo/index.html");
            this.WebView2.Focus(FocusState.Programmatic);
        }
    }
}
