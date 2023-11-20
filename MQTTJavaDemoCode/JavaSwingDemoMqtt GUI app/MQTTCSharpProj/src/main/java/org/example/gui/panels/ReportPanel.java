package org.example.gui.panels;

import org.apache.commons.io.FileUtils;
import org.example.gui.MainFrame;
import org.example.messages.MqttReportFile;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.regex.Pattern;

/**
 * Report tab
 */
public class ReportPanel  extends JPanel implements ActionListener {

    private JPanel upperPanel;

    private JButton generateReport;
    private JComboBox<String> reportType;


    private JPanel middlePanel;
    private JButton getReport;
    private JTextField directory;
    private JButton browseDir;
    ThreadPoolExecutor executor =  (ThreadPoolExecutor) Executors.newFixedThreadPool(2);

    private JTable jt;
    private JScrollPane sp;
    public ReportPanel(){
        /*
        Setting up the panel here.
         */
        setBounds(10,10, 1300,1300);
        setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));

        upperPanel = new JPanel();
        upperPanel.setLayout(new BoxLayout(upperPanel,BoxLayout.LINE_AXIS));
        upperPanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        generateReport = new JButton("Generate Report");
        generateReport.addActionListener(this);
        upperPanel.add(generateReport);
        upperPanel.add(new JLabel("     "));
        String [] str = {
                "Active View",
                "Active Window",
                "All Test Configurations",
                "All View",
                "Channel Status and Run Log",
                "DefaultTemplate",
                "Extensions",
                "Global Settings",
                "Input Channels",
                "License",
                "Limit Channels",
                "Live Signal Report",
                "Miscellaneous",
                "Profile Schedule and Limits",
                "Report for All",
                "Software Screenshot",
                "Spider System Settings",
                "System Calibration",
                "Test Parameters",
                "Video Capture"

        };
        reportType = new JComboBox<>(str);
        reportType.setMaximumSize(new Dimension(500, 30));
        upperPanel.add(reportType);
        upperPanel.add(new JLabel("     "));
        upperPanel.add(new JLabel("<Input or Select Report Template>"));

        add(upperPanel);

        middlePanel = new JPanel();
        middlePanel.setLayout(new BoxLayout(middlePanel,BoxLayout.LINE_AXIS));
        middlePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        getReport = new JButton("Get Selected Report");
        getReport.addActionListener(this);
        middlePanel.add(getReport);
        middlePanel.add(new JLabel("     "));
        directory = new JTextField();
        directory.setMaximumSize(new Dimension(500, 30));
        middlePanel.add(directory);
        middlePanel.add(new JLabel("     "));
        browseDir = new JButton("Browse Report Save Directory");
        browseDir.addActionListener(this);
        middlePanel.add(browseDir);
        add(middlePanel);

        String [] columns = {"File Name", "Remote Path"};
        String [][]data = {};
        jt = new JTable(new DefaultTableModel(data, columns));
        sp = new JScrollPane(jt);
        add(sp);

    }
    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == browseDir){
            /*
            finding a directory to save the report in
             */
            JFileChooser j = new JFileChooser();
            j.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
            Integer opt = j.showSaveDialog(this);
            File file = j.getSelectedFile();
            directory.setText(file.getAbsolutePath());
            revalidate();
            repaint();
        }
        if(e.getSource() == generateReport){
            /*
            Generating report. Runnable is used since it takes some time for report to be generated.
             */
            Runnable runnable = ()-> {
                MainFrame.mqttConfig.generateReport((String) reportType.getSelectedItem());
                try {
                    Thread.sleep(5000);
                } catch (InterruptedException ex) {
                    throw new RuntimeException(ex);
                }
                MqttReportFile report = MainFrame.mqttConfig.report;
                String[] str = report.ReportName.split(Pattern.quote("\\"));
                String name = str[str.length - 1];
                DefaultTableModel model = (DefaultTableModel) jt.getModel();
                model.addRow(new String[]{name, report.ReportName});
                jt = new JTable(model);
                remove(sp);
                sp = new JScrollPane(jt);
                sp.setBounds(10, 125, 1000, 600);
                add(sp);
                revalidate();
                repaint();
            };
            executor.execute(runnable);

        }
        if(e.getSource() == getReport){
            /*
            Saves report to specified destination after browsing.
             */
            String dest = directory.getText();
            StringBuilder str = new StringBuilder(dest);
            String fileName = (String) jt.getValueAt(jt.getSelectedRow(), 0);
            str.append("\\");
            str.append(fileName);
            File destination = new File(str.toString());

            try {

                FileUtils.copyFile(new File((String)jt.getValueAt(jt.getSelectedRow(),1)), destination);
            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }

        }




    }
}
