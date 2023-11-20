package org.example.messages;

public class MqttShockTestStatus {
    public String Timestamp;
    public String AccUnit;
    public String VelUnit;
    public String DisplUnit;

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
    public MqttShockTestStatus(){

    }
}
