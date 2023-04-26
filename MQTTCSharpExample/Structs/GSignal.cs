using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public class GSignal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string NvhType { get; set; }
        public List<FrameData> Data { get; set; }
        public double? RMS { get; set; }
        public double? Pk { get; set; }
        public double? PkPk { get; set; }
        public double? Mean { get; set; }
        public double? RPM { get; set; }
        public double? OverallRMS { get; set; }
    }

    public class FrameData
    {       
        public double[] Values { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
    }
}
