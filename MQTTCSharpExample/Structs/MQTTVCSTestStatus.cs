﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public struct MQTTRandomTestStatus
    {
        public string Timestamp;
        public string AccUnit;
        public string VelUnit;
        public string DisplUnit;

        public int EntryIndex;

        public double DrivePeak;

        public double TargetRMS;
        public double ControlRMS;
        public double Level;

        public double TotalTime;
        public double RemainTime;
        public double FullLevelTime;

        public double VelPeak;
        public double DisplPeakPeak;

        public double Kurtosis;
    }

    public struct MQTTSineTestStatus
    {
        public string Timestamp;
        public string AccUnit;
        public string VelUnit;
        public string DisplUnit;

        public int EntryIndex;

        public double DrivePeak;

        public double TargetPeak;
        public double ControlPeak;
        public double Level;

        public double TotalTime;
        public double RemainTime;
        public double FullLevelTime;

        public double VelPeak;
        public double DisplPeakPeak;
        public double TotalCycle;
        public double ElapsedCycle;

        public double SampleRate;
        public double Frequency;

        public double SweepRate;
        public int SweepNum;
        public int SweepDirection;
        public int SweepIndex;
    }

    public struct MQTTShockTestStatus
    {
        public string Timestamp;
        public string AccUnit;
        public string VelUnit;
        public string DisplUnit;

        public int EntryIndex;

        public double DrivePeak;

        public double TargetPeak;
        public double ControlPeak;
        public double RMS;

        public double Level;

        public int TotalPulse;
        public int RemainPulse;
        public int FullLevelPulse;

        public double VelPeak;
        public double DisplPeakPeak;
    }

    public struct MQTTTWRTestStatus
    {
        public string Timestamp;
        public string AccUnit;
        public string VelUnit;
        public string DisplUnit;

        public int EntryIndex;

        public double DrivePeak;

        public double TargetRMS;
        public double ControlRMS;

        public double Level;

        public double TotalTime;
        public double RemainTime;
        public double FullLevelTime;

        public double VelPeak;
        public double DisplPeakPeak;

        public int OutputIndex;

        public int TotalRepeat;
        public int CurRepeat;
    }
}
