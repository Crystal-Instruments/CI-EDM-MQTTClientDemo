package org.example.gui.panels;


import org.example.messages.MqttDeviceModule;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

/**
 * System info tab
 */
public class SystemPanel extends JPanel implements ActionListener {
    private JPanel appInfoPanel;
    private JTable jt;
    private JScrollPane sp;
    private JPanel systemInfoPanel;

    private JPanel gridPanel;

    public void setAppInfo(String mode, String version){
        appInfoPanel.removeAll();
        appInfoPanel.add(new JLabel("Software Mode"));
        appInfoPanel.add(new JLabel(mode));
        appInfoPanel.add(new JLabel("Version"));
        appInfoPanel.add(new JLabel(version));
        revalidate();
        repaint();

    }
    public void setSystemStatus(String name, String status){
        gridPanel.removeAll();
        gridPanel.add(new JLabel("Name"));
        gridPanel.add(new JLabel(name));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel("Status"));
        gridPanel.add(new JLabel(status));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel(""));
        revalidate();
        repaint();

    }
    public void setModules(List<MqttDeviceModule> modules){
        String [] columns = {"Device Type", "Serial Number", "IP Address", "Hardware Version"};
        String [][]data = new String[modules.size()][4];
        int i =0;
        for(MqttDeviceModule m: modules){
            data[i][0] = m.DeviceType;
            data[i][1] = m.SerialNumber;
            data[i][2] = m.IPAdress;
            data[i][3] = m.Version;
            ++i;

        }
        systemInfoPanel.remove(sp);
        jt = new JTable(data, columns);
        sp = new JScrollPane(jt);
        systemInfoPanel.add(sp, BorderLayout.CENTER);
        revalidate();
        repaint();

    }

    public SystemPanel(){
        setBounds(10,10, 1300,1300);
        setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));
        appInfoPanel = new JPanel();
        appInfoPanel.setMaximumSize(new Dimension(300, 150));
        appInfoPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "App Information", TitledBorder.LEFT,
                TitledBorder.TOP));
        appInfoPanel.setLayout(new GridLayout(2,2,10,10));
        appInfoPanel.add(new JLabel("Software Mode"));
        appInfoPanel.add(new JLabel("<Mode>"));
        appInfoPanel.add(new JLabel("Version"));
        appInfoPanel.add(new JLabel("<Version>"));
        add(appInfoPanel);



        systemInfoPanel = new JPanel();
        systemInfoPanel.setLayout(new BorderLayout());
        systemInfoPanel.setMaximumSize(new Dimension(1000, 800));
        systemInfoPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "System Information", TitledBorder.LEFT,
                TitledBorder.TOP));
        gridPanel = new JPanel();
        gridPanel.setLayout(new GridLayout(2,4, 0,20));
        gridPanel.setMaximumSize(new Dimension(300, 150));
        gridPanel.add(new JLabel("Name"));
        gridPanel.add(new JLabel("<Name>"));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel("Status"));
        gridPanel.add(new JLabel("<Status>"));
        gridPanel.add(new JLabel(""));
        gridPanel.add(new JLabel(""));
        systemInfoPanel.add(gridPanel,BorderLayout.PAGE_START);

        String [] columns= {"Device Type", "Serial Number", "IP Address", "Hardware version"};
        String [][] data = {};
        jt = new JTable(data, columns);
        sp = new JScrollPane(jt);
        systemInfoPanel.add(sp, BorderLayout.CENTER);

        add(systemInfoPanel);

    }
    @Override
    public void actionPerformed(ActionEvent e) {

    }

}
