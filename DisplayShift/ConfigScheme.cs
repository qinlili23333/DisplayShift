using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayShift
{
    internal class DisplayCfg
    {
        internal string DevicePath { get; set; } = string.Empty;
        internal bool A { get; set; } = false;
        internal bool B { get; set; } = false;
    }
    internal class ConfigScheme
    {
        internal int Latency { get; set; } = 5;
        internal DisplayCfg[] Configs { get; set; } = [];
        internal string CurrentConfig { get; set; } = "A";
    }
}
