using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTRandomSimpleProfile
    {
        public string AccUnit;
        public List<MQTTRandomProfileEntry> Entries;
    }

    public struct MQTTRandomProfileEntry
    {
        public float Frequency;
        public float Profile;

        public float HighAbort;
        public float HighAlarm;
        public float LowAbort;
        public float LowAlarm;
    }

    public struct MQTTSineSimpleProfile
    {
        public string AccUnit;
        public List<MQTTSineProfileEntry> Entries;
    }

    public struct MQTTSineProfileEntry
    {
        public float Frequency;
        public float Profile;

        public int SegmentType;

        public float HighAbort;
        public float HighAlarm;
        public float LowAbort;
        public float LowAlarm;
    }

    public struct MQTTShockSimpleProfile
    {
        public int MainPulseType;
        public int LimitType;

        public float Amplitude;
        public float PulseWidth;

        public int CompensationType;
        public int CompensationPulseType;

        public float PrePulseHeight;
        public float PostPulseHeight;
    }
}
