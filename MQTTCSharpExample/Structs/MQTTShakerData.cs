using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTShakerData
    {
        public double RandomForceRMS;
        public double RandomMaxAcc;
        public double SineForcePeak;
        public double SineMaxAcc;
        public double ShockForcePeak;
        public double ShockMaxAcc;

        public double MaxPosDispl;
        public double MaxNegDispl;

        public String Orientation;
        public double MaxVelocity;
        public double MaxDriveVolt;
        public double MinDriveFreq;
        public double MaxDriveFreq;

        public bool MeasurementNoisy;
        public double ArmatureDiameter;
        public double ArmatureMass;
        public double FixtureMass;

        /// <summary>
        /// Header expander mass, vertical only.
        /// </summary>
        public double HeaderExpanderMass;
        /// <summary>
        /// Slip table mass, horizontal only.
        /// </summary>
        public double SlipTableMass;
        /// <summary>
        /// Drive bar mass, horizontal only.
        /// </summary>
        public double DriveBarMass;
    }

    public struct MQTTMassParameters
    {
        public double UUTMass;
        public double FixtureMass;
    }
}
