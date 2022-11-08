using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTDSATestStatus
    {
        public string Timestamp;
        public int AcceptedFrameNum;
        public int TotalFrameNum;
        public int AverageNum;
        public double OutputPeak;
        public int DIOStatus;
        public int DisplaySignalCount;
        public int RPM1;
        public int RPM2;
    }
}
