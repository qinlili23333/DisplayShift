
using MartinGC94.DisplayConfig.API;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows;

namespace DisplayShift
{
    public class WV2Bridge
    {
        Settings CurrentWindow;
        public WV2Bridge(Settings window)
        {
            CurrentWindow = window;
        }

        public DisplayInfo[] GetAllConnectedDisplays()
        {
            List<DisplayInfo> Displays = new();
            var config = DisplayConfig.GetConfig();
            foreach (int index in config.AvailablePathIndexes)
            {
                Displays.Add(DisplayInfo.GetDisplayInfo(config, index));
            }
            return [.. Displays];
        }

        public void ChangeWindowHeight(double height)
        {
            CurrentWindow.MainGrid.Height = height;
        }

        public string ReadConfig()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");
            if (File.Exists(configPath))
            {
                return File.ReadAllText(configPath);
            }
            else
            {
                return JsonSerializer.Serialize(new ConfigScheme());
            }
        }

        public void WriteConfig(string config)
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");
            File.WriteAllText(configPath, config);
        }

        public void CloseWindow()
        {
            CurrentWindow.Close();
        }

        public void Apply()
        {
            new Switch().Show(); 
        }
    }
}
