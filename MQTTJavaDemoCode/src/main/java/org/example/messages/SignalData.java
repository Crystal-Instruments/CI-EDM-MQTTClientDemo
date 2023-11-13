package org.example.messages;

import java.util.ArrayList;

public class SignalData {
    public Signals Signal;
    public ArrayList<Double> ValueX;
    public ArrayList<Double> ValueY;
    public ArrayList<Double> ValueZ;

    public SignalData(){

    }

    public SignalData(Signals signal, ArrayList<Double> valueX, ArrayList<Double> valueY, ArrayList<Double> valueZ) {
        Signal = signal;
        ValueX = valueX;
        ValueY = valueY;
        ValueZ = valueZ;
    }
}
