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
        public string WindowType;
        public string DisplayFormat;
    }

    public struct MQTTSignalFrameData
    {
        public MQTTSignal Signal;
        public double[] ValueX;
        public double[] ValueY;
        public double[] ValueZ;

        public int XSequenceType;//0-->linear,1-->log
        public double XStart;
        public double XDelta;
        public int XLength;
    }

    public struct MQTTSignalProperty
    {
        public string SignalName;
        public string PropertyName;
        public double Value;
        public string Unit;
    }

}
