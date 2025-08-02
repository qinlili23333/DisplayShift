using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayShift
{
    public class DisplayCfg
    {
        public string DevicePath { get; set; } = string.Empty;
        public bool A { get; set; } = false;
        public bool B { get; set; } = false;
    }
    public class ConfigScheme
    {
        public int Latency { get; set; } = 5;
        public DisplayCfg[] Configs { get; set; } = [];
        public string CurrentConfig { get; set; } = "A";
    }
}
