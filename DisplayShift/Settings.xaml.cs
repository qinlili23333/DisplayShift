using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows;

namespace DisplayShift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Settings : Window
    {
        CoreWebView2Environment WebView2Environment;

        public Settings()
        {
            InitializeComponent();
        }

        private async void InitAsync()
        {
            string WebviewArgu = "--disable-features=msSmartScreenProtection,ElasticOverscroll,PersistentHistograms,SubresourceFilter --enable-features=msWebView2EnableDraggableRegions --in-process-gpu --disable-web-security --no-sandbox";
            CoreWebView2EnvironmentOptions options = new()
            {
                AdditionalBrowserArguments = WebviewArgu
            };
            Directory.CreateDirectory(@"\WebviewCache\");
            WebView2Environment = await CoreWebView2Environment.CreateAsync(null, @"\WebviewCache\", options);
            await WebView.EnsureCoreWebView2Async(WebView2Environment);
            WebView.CoreWebView2.Settings.IsBuiltInErrorPageEnabled = false;
            WebView.CoreWebView2.Settings.IsSwipeNavigationEnabled = false;
            WebView.CoreWebView2.Settings.IsZoomControlEnabled = false;
            WebView.CoreWebView2.Settings.IsPinchZoomEnabled = false;
            WebView.CoreWebView2.Settings.IsStatusBarEnabled = false;
#if RELEASE
            WebView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
#endif
            WebView.CoreWebView2.AddHostObjectToScript("Bridge", new WV2Bridge(this));
            WebView.CoreWebView2.NavigateToString(WebRes.Settings);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitAsync();
        }
    }
}