using MartinGC94.DisplayConfig.API;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace DisplayShift
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Switch : Window
    {
        ConfigScheme Conf;
        bool GroupA = true;
        public Switch()
        {
            InitializeComponent();
            InitAsync();
        }

        private async void InitAsync()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json");
            string content = await File.ReadAllTextAsync(configPath);
            Conf = JsonSerializer.Deserialize<ConfigScheme>(content);
            if (Conf.CurrentConfig == "A")
            {
                GroupA = false;
                Conf.CurrentConfig = "B";
            }
            else
            {
                GroupA = true;
                Conf.CurrentConfig = "A";
            }
            List<DisplayInfo> Displays = new();
            var config = DisplayConfig.GetConfig();
            foreach (int index in config.AvailablePathIndexes)
            {
                Displays.Add(DisplayInfo.GetDisplayInfo(config, index));
            }
            foreach (var display in Conf.Configs)
            {
            }
            int Count = Conf.Latency;
            while (Count > 0)
            {
                Count--;
                await Task.Delay(1000);
                DelayBar.Value = 100*(1-((float)Count/(float)Conf.Latency));
                Status.Content = $"Switching to group {(GroupA ? "A":"B")} in {Count} seconds...";
            }
            Apply();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Skip_Click(object sender, RoutedEventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.json"), JsonSerializer.Serialize(Conf));
            Close();
        }
    }
}
