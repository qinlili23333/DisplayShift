
using System.Runtime.InteropServices;
using MartinGC94.DisplayConfig.API;

namespace DisplayShift
{
    public class WV2Bridge
    {
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
    }
}
