using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTTriggerSettings
    {
        public int TriggerMode;
        public string TriggerSource;
        public int TriggerType;
        public int DelayPoints;
        public float LowLevel;
        public float HighLevel;
    }
}
