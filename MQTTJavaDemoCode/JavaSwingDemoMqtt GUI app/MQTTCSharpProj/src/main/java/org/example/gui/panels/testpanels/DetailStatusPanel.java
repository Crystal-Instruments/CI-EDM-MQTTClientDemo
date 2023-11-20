package org.example.gui.panels.testpanels;

import org.example.gui.MainFrame;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class DetailStatusPanel extends JPanel implements ActionListener {

    private JButton getDetailStatus;
    private JPanel panel;
    private JTable jt;
    private JScrollPane sp;


    public void displayTestStatus(JTable jt, JScrollPane sp){
        remove(this.sp);
        this.jt = jt;
        this.sp = sp;
        add(this.sp, BorderLayout.CENTER);


        revalidate();
        repaint();

    }

    public DetailStatusPanel(){
        setBounds(10,10, 1300, 1300);
        panel = new JPanel();
        setLayout(new BorderLayout());
        getDetailStatus = new JButton("Get Test Detail Status");
        getDetailStatus.setFont(new Font("Arial", Font.PLAIN, 15));
        getDetailStatus.setSize(300, 20);
        getDetailStatus.setLocation(10, 10);
        getDetailStatus.addActionListener(this);
        panel.add(getDetailStatus);
        add(panel, BorderLayout.PAGE_START);

        String[] columnNames = { "Name", "Value" };
        String[][] data = {  };
        jt = new JTable(data, columnNames);
        sp = new JScrollPane(jt);
        add(sp, BorderLayout.CENTER);

    }
    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == getDetailStatus) MainFrame.mqttConfig.requestDetailStatus();

    }
}
