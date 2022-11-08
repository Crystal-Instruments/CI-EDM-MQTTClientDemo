using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTTHStatus
    {
        public string Timestamp;
        public double TotalTime;
        public double RemainTime;
        public double TargetTemperature;
        public double ControlTemperature;
        public double TargetHumdity;
        public double ControlHumidity;     
        public List<MQTTTemperatureStatus> LatestTemperatures;
        public List<MQTTHumditiyStatus> LatestHumdities;
    }


    public struct MQTTVTStatus
    {
        public string Timestamp;
        public double TotalTime;
        public double RemainTime;
        public double TargetTemperature;
        public double ControlTemperature;      
        public double TargetVibration;
        public double ControlVibration;
        public List<MQTTTemperatureStatus> LatestTemperatures;
        public List<MQTTVibrationStatus> LatestVibrations;
    }

    public struct MQTTTemperatureStatus
    {
        public string Name;
        public double Temperature;
        public string Unit;
    }

    public struct MQTTHumditiyStatus
    {
        public string Name;
        public double Humdity;
        public string Unit;
    }

    public struct MQTTVibrationStatus
    {
        public string Name;
        public double Vibration;
        public string Unit;
    }
}
