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

}
