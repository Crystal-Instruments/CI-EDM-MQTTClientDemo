package org.example.gui.panels;

import org.apache.commons.io.FileUtils;
import org.example.gui.MainFrame;
import org.example.messages.MqttRunFolder;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

/**
 * File tab
 */
public class FilePanel  extends JPanel implements ActionListener {
    private JPanel upperPanel;
    private JButton getRunFolder;
    private JLabel runFolderInfo;
    private JPanel middlePanel;
    private JButton getFile;
    private JTextField directory;
    private JButton browseDir;

    private JTable jt;
    private JScrollPane sp;
    public FilePanel(){

        setBounds(10,10, 1300,1300);
        setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));

        upperPanel = new JPanel();
        upperPanel.setLayout(new BoxLayout(upperPanel,BoxLayout.LINE_AXIS));
        upperPanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        getRunFolder = new JButton("Get Run Folder");
        getRunFolder.addActionListener(this);
        upperPanel.add(getRunFolder);
        upperPanel.add(new JLabel("     "));
        runFolderInfo = new JLabel("<RunFolderInfo>");
        runFolderInfo.setMaximumSize(new Dimension(700, 30));
        upperPanel.add(runFolderInfo);

        add(upperPanel);

        middlePanel = new JPanel();
        middlePanel.setLayout(new BoxLayout(middlePanel,BoxLayout.LINE_AXIS));
        middlePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        getFile= new JButton("Get Selected File");
        getFile.addActionListener(this);
        middlePanel.add(getFile);
        middlePanel.add(new JLabel("     "));
        directory = new JTextField();
        directory.setMaximumSize(new Dimension(500, 30));
        middlePanel.add(directory);
        middlePanel.add(new JLabel("  "));
        browseDir = new JButton("Browse File Save Directory");
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
            JFileChooser j = new JFileChooser();
            j.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
            Integer opt = j.showSaveDialog(this);
            File file = j.getSelectedFile();
            directory.setText(file.getAbsolutePath());
            revalidate();
            repaint();
        }
        if(e.getSource() == getFile){
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

        if(e.getSource() == getRunFolder){
            MainFrame.mqttConfig.requestRunFolder();
            try {
                Thread.sleep(250);
            } catch (InterruptedException ex) {
                throw new RuntimeException(ex);
            }

            String str = MainFrame.mqttConfig.runFolder.RunName + "," + MainFrame.mqttConfig.runFolder.RunPath;
            runFolderInfo.setText(str);
            MqttRunFolder folder = MainFrame.mqttConfig.runFolder;
            int length = folder.RunFiles.size();
            String [] columns = {"File Name", "Remote Path"};
            String [][]data = new String[length][2];
            int i =0;
            for(String s: folder.RunFiles){
                data[i][0] =  s;
                String fullPath = folder.RunPath + "\\"+  s;
                data[i][1] = fullPath;
                ++i;
            }
            remove(sp);
            jt = new JTable(new DefaultTableModel(data, columns));
            sp = new JScrollPane(jt);
            sp.setBounds(10, 125, 1000, 600);
            add(sp);
            revalidate();
            repaint();
        }

    }
}
