package org.example.gui.panels.testpanels;

import org.example.Main;
import org.example.gui.MainFrame;
import org.example.messages.MqttTest;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Objects;

/**
 * List/Load/Create/Delete Tab
 */

public class TestOptionsPanel extends JPanel implements ActionListener {
    private JPanel upperPanel;

    private JButton listTest;
    private JButton loadTest;
    private JButton deleteTest;



    private JPanel middlePanel;

    private JTextField tNameField;
    private JButton createTest;

    private JComboBox<String>cb;


    private JTable jt;
    private JScrollPane sp;
    public TestOptionsPanel(){

        setLayout(new BorderLayout());

        upperPanel = new JPanel();
        upperPanel.setLayout(new BoxLayout(upperPanel,BoxLayout.LINE_AXIS));
        upperPanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        listTest = new JButton("List Test");
        listTest.addActionListener(this);
        loadTest = new JButton("Load Test");
        loadTest.addActionListener(this);
        deleteTest = new JButton("Delete Test");
        deleteTest.addActionListener(this);
        upperPanel.add(listTest);
        upperPanel.add(new JLabel("     "));
        upperPanel.add(loadTest);
        upperPanel.add(new JLabel("     "));
        upperPanel.add(deleteTest);

        add(upperPanel, BorderLayout.PAGE_START);

        middlePanel = new JPanel();
        middlePanel.setLayout(new BoxLayout(middlePanel,BoxLayout.PAGE_AXIS));
        middlePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        middlePanel.add(new JLabel("Test Name"));
        tNameField = new JTextField();
        tNameField.setMaximumSize(new Dimension(300, 30));
        middlePanel.add(tNameField);
        middlePanel.add(new JLabel("     "));
        middlePanel.add(new JLabel("Test Type"));
        String [] choices = {
                "VCS_Random",
                "VCS_Shock",  // Classic Shock
                "VCS_Sine",
                "VCS_TTH",    // Transient Time History
                "VCS_SRS",    // Shock Response Spectrum
                "VCS_SineOscillator",
                "VCS_TDR",
                "VCS_AcousticControl",
                "VCS_RORSOR",
                "VCS_RSTD",
                "VCS_SineReduction",
                "VCS_MultiSine",
                "VCS_ShockOnRandom",
                "VCS_SineBeatSeismic",
                "VCS_BFT",
                "VCS_EDR",
                "MIMO_Random",
                "MIMO_Sine",
                "MIMO_Shock",
                "MIMO_TWR",
                "MIMO_SRS",
                "MIMO_TTH",
                "MIMO_SOR",
                "MDOF_Random",
                "MDOF_Sine",
                "MDOF_TWR", };
        cb = new JComboBox<>(choices);
        cb.setMaximumSize(new Dimension(300, 30));
        middlePanel.add(cb);
        middlePanel.add(new JLabel("  "));
        createTest = new JButton("Create Test");
        createTest.addActionListener(this);
        middlePanel.add(createTest);
        add(middlePanel, BorderLayout.LINE_END);



        String [] columns = {"File Name", "Remote Path"};
        String [][]data = {};
        jt = new JTable(new DefaultTableModel(data, columns));
        sp = new JScrollPane(jt);

        add(sp, BorderLayout.CENTER);



    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == listTest){
            MainFrame.mqttConfig.listTest();
            try {
                Thread.sleep(250);
            } catch (InterruptedException ex) {
                throw new RuntimeException(ex);
            }
            String [][] data = new String [MainFrame.mqttConfig.mqttTestList.size()][2];
            int i =0;
            for(MqttTest test: MainFrame.mqttConfig.mqttTestList){

                data[i][0] = test.Name;
                data[i][1] = test.Type;
                ++i;


            }
            String [] columns = {"Name", "Type"};
            jt = new JTable(data, columns);
            remove(sp);
            sp = new JScrollPane(jt);
            sp.setBounds(10, 140, 850, 850);
            add(sp, BorderLayout.CENTER);

            revalidate();
            repaint();

        }
        if(e.getSource() == loadTest){
            MainFrame.mqttConfig.loadTest((String) jt.getValueAt(jt.getSelectedRow(), jt.getSelectedColumn()));

        }
        if(e.getSource() == deleteTest){
            MainFrame.mqttConfig.deleteTest((String) jt.getValueAt(jt.getSelectedRow(), jt.getSelectedColumn()));
        }
        if(e.getSource() == createTest){
            MainFrame.mqttConfig.createTest(tNameField.getText(), Objects.requireNonNull(cb.getSelectedItem()).toString());
        }

    }

}


