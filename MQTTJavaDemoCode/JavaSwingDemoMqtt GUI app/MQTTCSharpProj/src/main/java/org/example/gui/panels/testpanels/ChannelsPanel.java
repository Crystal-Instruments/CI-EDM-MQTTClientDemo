package org.example.gui.panels.testpanels;

import org.example.gui.MainFrame;
import org.example.messages.MqttChannel;
import javax.swing.*;
import java.util.List;

public class ChannelsPanel {

    public JScrollPane sp;
    private JTable j;

    public ChannelsPanel(){
        String [] columnNames ={"Module", "Location ID", "Enable",
        "Quantity", "Unit", "Sensitivity", "Input Mode",
        "Input Range", "High Pass Frequency", "Integration", "Control Weighting" };

        String[][] data = {  };

        j = new JTable(data,columnNames);
        j.setBounds(30, 40, 500, 600);
        sp = new JScrollPane(j);

    }
    public void setValues(){
        String [] columnNames ={"Module", "Location ID", "Enable",

                "Quantity", "Unit", "Sensitivity", "Input Mode",
                "Input Range", "High Pass Frequency", "Integration", "Control Weighting" };
        List<MqttChannel> lists = MainFrame.mqttConfig.mqttChannelsList;

        String [][] data = new String[lists.size()][11];
        int index = 0;
        for(MqttChannel mc: lists){
            String [] dt = {mc.Module,mc.LocationId,String.valueOf(mc.Enable),mc.Quantity,mc.Unit, String.valueOf(mc.Sensitivity),
                    mc.InputMode, mc.InputRange, String.valueOf(mc.HighPassFrequency), mc.Integration, mc.ControlWeighting};

            data[index] = dt;
            ++index;
        }
        j = new JTable(data,columnNames);
        j.setBounds(30, 40, 500, 600);
        sp = new JScrollPane(j);


    }
}
