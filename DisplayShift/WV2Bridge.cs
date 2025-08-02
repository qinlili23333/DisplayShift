
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using MartinGC94.DisplayConfig.API;

namespace DisplayShift
{
    public class WV2Bridge
    {
        Settings CurrentWindow;
        public WV2Bridge(Settings window)
        {
            CurrentWindow = window;
        }
        public uint[] DisplayId { get; set; }
        public DisplayInfo[] GetAllConnectedDisplays()
        {
            List<DisplayInfo> Displays = new();
            var config = DisplayConfig.GetConfig();
            if (DisplayId is null)
            {
                foreach (int index in config.AvailablePathIndexes)
                {
                    Displays.Add(DisplayInfo.GetDisplayInfo(config, index));
                }
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
                return "[]";
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

    }
}
