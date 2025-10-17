using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{

    //public struct MQTTChannel
    //{
    //    public string Module;
    //    public bool Enable;
    //    public string LocationId;
    //    public string Quantity;
    //    public string Unit;
    //    public double Sensitivity;
    //    public string InputMode;
    //    public string ChannelType;
    //    public string InputRange;
    //    public double HighPassFrequency;
    //    public string Integration;
    //    public string ControlWeighting;
    //}

    public struct MQTTChannel
    {
        /// <summary>
        /// 0
        /// </summary>
        public string Module;
        /// <summary>
        /// 1
        /// </summary>
        public bool Enable;
        /// <summary>
        /// 2
        /// </summary>
        public string LocationId;
        /// <summary>
        /// 3
        /// </summary>
        public string Quantity;
        /// <summary>
        /// 4
        /// </summary>
        public string Unit;
        /// <summary>
        /// 5
        /// </summary>
        public double Sensitivity;
        /// <summary>
        /// 7
        /// </summary>
        public string InputMode;
        /// <summary>
        /// 14
        /// </summary>
        public string ChannelType;
        /// <summary>
        /// 28
        /// </summary>
        public string InputRange;
        /// <summary>
        /// 8
        /// </summary>
        public double HighPassFrequency;
        /// <summary>
        /// 9
        /// </summary>
        public string Integration;
        /// <summary>
        /// 15
        /// </summary>
        public string ControlWeighting;
    }


    public struct MQTTChannelStatus
    {
        public float Min;
        public float Max;
        public float Peak;
        public float RMS;
        public float Average;
        public float MaxPeak;
        public float MaxRms;
        public float VelPeak;
        public float DisplPeak;
        public int MaxInputRange;//Max Input Range in mV

        public bool IsIEPE; //IEPE enabled
        public bool IsOverload; //Channel overload
        public bool IsIEPEWithSensor; //IEPE enabled and sensor detected; IEPE sensor not detected
        public bool IsStrainGageNotConnected;
        public bool IsSensorOverload; //Sensor overload
        public bool IsFailed; //Channel Failed 

        public string Unit;
        public string LocationId;
        public string VelUnit;
        public string DisplUnit;

        public string ChannelLost; //Channel lost(all test types except VCS or MIMO VCS); Control/Monitor/Limit Channel Lost (For VCS, MIMO VCS only)
        public string LimitExceed; //Abort/Alarm Limit Exceeded
        public string Notching; //Notching (For VCS Only) 
    }

}
