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
}
