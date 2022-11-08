using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTSignal
    {
        public string Timestamp;
        public string Name;
        public string Type;
        public string UnitX;
        public string UnitY;
        public string UnitZ;
        public ulong BlockSize;
        public double SamplingRate;
    }

    public struct MQTTSignalFrameData
    {
        public MQTTSignal Signal;
        public double[] ValueX;
        public double[] ValueY;
        public double[] ValueZ;
    }

    public struct MQTTSignalProperty
    {
        public string SignalName;
        public string PropertyName;
        public double Value;
        public string Unit;
    }

}
