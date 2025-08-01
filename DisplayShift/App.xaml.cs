using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace DisplayShift
{
    public partial class App : Application
    {
        public void InitializeComponent()
        {
            if (!File.Exists("Settings.json"))
            {
                this.StartupUri = new System.Uri("Settings.xaml", System.UriKind.Relative);
            }
        }

        [System.STAThreadAttribute()]
        public static void Main()
        {
            DisplayShift.App app = new();
            app.InitializeComponent();
            app.Run();
        }
    }

}
