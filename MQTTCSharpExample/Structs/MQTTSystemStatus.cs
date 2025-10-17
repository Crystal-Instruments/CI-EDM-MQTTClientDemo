using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{

    public struct MQTTSystemStatus
    {
        public string Timestamp;
        public string Name;
        public string Status;
    }

    public struct MQTTSystem
    {
        public string Name;
        public List<MQTTDeviceModule> Modules;
    }

    public struct MQTTDeviceModule
    {
        public string IPAdress;
        public string SerialNumber;
        public string DeviceType;
        public string Version;
    }

    public struct MQTTDeviceTimeStatus
    {
        public string SerialNumber;
        public int Year;
        public int Month;
        public int Day;
        public int Hour;
        public int Minute;
        public int Second;
        public int Millisecond;
        public int Microsecond;
    }
}
