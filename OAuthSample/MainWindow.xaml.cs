using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace OAuthSample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            var uriToLaunch = new Uri("https://github.com/login/oauth/authorize?" +
                "client_id=2258ff44810cecc89e3f&" +
                "redirect_uri=ms-store://oauthsample");

            // Launch the URI
            await Windows.System.Launcher.LaunchUriAsync(uriToLaunch);
        }

        internal void OnUriCallback(Uri uri)
        {
            var callbackParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            codeText.Text = callbackParams["code"];
        }
    }
}
