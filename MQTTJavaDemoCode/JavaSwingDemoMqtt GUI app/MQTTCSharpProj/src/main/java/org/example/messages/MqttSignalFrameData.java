package org.example.messages;

import java.util.ArrayList;

public class MqttSignalFrameData {
    public Signals Signal;
    public ArrayList<Double> ValueX;
    public ArrayList<Double> ValueY;
    public ArrayList<Double> ValueZ;

    public MqttSignalFrameData(){

    }

    public MqttSignalFrameData(Signals signal, ArrayList<Double> valueX, ArrayList<Double> valueY, ArrayList<Double> valueZ) {
        Signal = signal;
        ValueX = valueX;
        ValueY = valueY;
        ValueZ = valueZ;
    }

    @Override
    public String toString() {
        return "MqttSignalFrameData{" +
                "Signal=" + Signal +
                ", ValueX=" + ValueX +
                ", ValueY=" + ValueY +
                ", ValueZ=" + ValueZ +
                '}';
    }
}
