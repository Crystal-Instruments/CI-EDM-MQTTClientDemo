package org.example.gui.panels.testpanels;


import org.example.gui.MainFrame;
import org.example.messages.MqttShaker;
import javax.swing.*;

/**
 * Shaker Tab
 */

public class ShakerPanel{
    private JTable j;
    public JScrollPane sp;

    public ShakerPanel(){
        String[] columnNames = { "Name", "Value", "Description" };
        String[][] data = {  };
        j = new JTable(data,columnNames);
        j.setBounds(30, 40, 500, 600);
        sp = new JScrollPane(j);
    }
    public void setValues(){
        if(MainFrame.mqttConfig.mqttShaker != null) {
            MqttShaker shaker = MainFrame.mqttConfig.mqttShaker;
            String[] columnNames = { "Name", "Value", "Description" };
            String[][] data = {
                    { "RandomForceRMS", String.valueOf(shaker.RandomForceRMS), ""},
                    {"RandomMaxAcc", String.valueOf(shaker.RandomMaxAcc), "" },
                    {"SineForcePeak", String.valueOf(shaker.SineForcePeak), "" },
                    {"SineMaxAcc", String.valueOf(shaker.SineMaxAcc), "" },
                    {"ShockForcePeak", String.valueOf(shaker.ShockForcePeak), "" },
                    {"ShockMaxAcc", String.valueOf(shaker.ShockMaxAcc), "" },
                    {"MaxPosDispl", String.valueOf(shaker.MaxPosDispl), "" },
                    {"MaxNegDispl", String.valueOf(shaker.MaxNegDispl), "" },
                    {"Orientation", String.valueOf(shaker.Orientation), "" },
                    {"MaxVelocity", String.valueOf(shaker.MaxVelocity), "" },
                    {"MaxDriveVolt", String.valueOf(shaker.MaxDriveVolt), "" },
                    {"MinDriveFreq", String.valueOf(shaker.MinDriveFreq), "" },
                    {"MaxDriveFreq", String.valueOf(shaker.MaxDriveFreq), "" },
                    {"MeasurementNoisy", String.valueOf(shaker.MeasurementNoisy), "" },
                    {"ArmatureDiameter", String.valueOf(shaker.ArmatureDiameter), "" },
                    {"ArmatureMass", String.valueOf(shaker.ArmatureMass), "" },
                    {"FixtureMass", String.valueOf(shaker.FixtureMass), "" },
                    {"HeaderExpanderMass", String.valueOf(shaker.HeaderExpanderMass), "" },
                    {"SlipTableMass", String.valueOf(shaker.SlipTableMass), "" },
                    {"DriveBarMass", String.valueOf(shaker.DriveBarMass), "" },
                    {"ShakerMovingMass", String.valueOf(shaker.ShakerMovingMass), "" }

            };

            j = new JTable(data,columnNames);
            j.setBounds(30, 40, 500, 600);
            sp  = new JScrollPane(j);
        }
    }
}