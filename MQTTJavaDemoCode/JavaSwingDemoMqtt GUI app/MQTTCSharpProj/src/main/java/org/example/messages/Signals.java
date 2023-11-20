package org.example.messages;

public class Signals {
    public String Timestamp;
    public String Name;
    public String Type;
    public String UnitX;
    public String UnitY;
    public String UnitZ;
    public Long BlockSize;
    public float SamplingRate;
    public String WindowType;
    public String DisplayFormat;
    public Signals(){

    }

    @Override
    public String toString() {
        return "Signals{" +
                "Timestamp='" + Timestamp + '\'' +
                ", Name='" + Name + '\'' +
                ", Type='" + Type + '\'' +
                ", UnitX='" + UnitX + '\'' +
                ", UnitY='" + UnitY + '\'' +
                ", UnitZ='" + UnitZ + '\'' +
                ", BlockSize=" + BlockSize +
                ", SamplingRate=" + SamplingRate +
                ", WindowType='" + WindowType + '\'' +
                ", DisplayFormat='" + DisplayFormat + '\'' +
                '}';
    }
}
