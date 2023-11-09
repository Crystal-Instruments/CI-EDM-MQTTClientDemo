using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
  
    public struct MQTTTestStatus
    {
        public string Timestamp;
        public string Name;
        public string Status;
        public string RunFolder;
        public string MeasureStartAt;
    }

 
    public struct MQTTTest
    {  
        public string Name;
        public string Type;
        public string CreatedTime;
    }

    public struct MQTTLimitStatus
    {
        public string Timestamp;
        public string Name;
        public string Status;
    }

    public struct MQTTVCSTestStage
    {
        public string Timestamp;
        public string Name;
        public string Stage;
    }

    public struct MQTTVCSControlFlag
    {
        public string Timestamp;
        public string Name;
        public string Flag;
    }

    public struct MQTTAdvancedStatusCollection
    {
        public List<MQTTAdvancedStatus> AdvancedStatus;
    }

    public struct MQTTAdvancedStatus
    {
        public string Timestamp;
        public string Name;
        public string Type;
        public string Value;
        public string Unit;
    }
}
