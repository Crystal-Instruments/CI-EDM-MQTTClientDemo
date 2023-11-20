package org.example.gui.panels.testpanels;

import org.apache.commons.io.FileUtils;
import org.example.gui.MainFrame;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.io.IOException;

/**
 * Advanced Commands Tab
 */
public class AdvancedCommandsPanel  extends JPanel implements ActionListener {

    private JPanel chDirPanel;
    private JLabel setChannel;
    private JPanel channelPanel;
    private JTextField channelTableTf;
    private JButton channelBrowse;
    private JButton channelSet;

    private JPanel schDirPanel;
    private JPanel schedulePanel;
    private JTextField scheduleTf;
    private JButton scheduleBrowse;
    private JButton scheduleSet;

    private JPanel vcsDirPanel;

    private JPanel randomProfilePanel;
    private JTextField randomProfileTf;
    private JButton randomBrowse;
    private JButton randomSet;

    private JPanel sinePanel;
    private JTextField sineProfileTf;
    private JButton sineBrowse;
    private JButton sineSet;

    private JPanel shockPanel;
    private JTextField shockProfileTf;
    private JButton shockBrowse;
    private JButton shockSet;


    public AdvancedCommandsPanel(){
        setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));
        chDirPanel = new JPanel();
        chDirPanel.setLayout(new BoxLayout(chDirPanel, BoxLayout.LINE_AXIS));
        chDirPanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        chDirPanel.setBorder(BorderFactory.createEmptyBorder(20, 0, 10, 10));
        setChannel = new JLabel("   Set Channel Table Advanced Command(Select a CSV file which exported by EDM input " +
                "channel setup dialog)");

        chDirPanel.add(setChannel);
        add(chDirPanel);
        channelPanel = new JPanel();
        channelPanel.setLayout(new BoxLayout(channelPanel, BoxLayout.LINE_AXIS));
        channelPanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        channelPanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        channelPanel.add(new JLabel("Set Channel Table"));
        channelPanel.add(new JLabel("    "));
        channelTableTf = new JTextField();
        channelTableTf.setMaximumSize(new Dimension(750, 30));
        channelPanel.add(channelTableTf);
        channelPanel.add(new JLabel("    "));
        channelBrowse = new JButton("Browse");
        channelBrowse.addActionListener(this);
        channelPanel.add(channelBrowse);
        channelPanel.add(new JLabel("    "));
        channelSet = new JButton("Set");
        channelSet.addActionListener(this);
        channelPanel.add(channelSet);
        add(channelPanel);

        schDirPanel = new JPanel();
        schDirPanel.setLayout(new BoxLayout(schDirPanel, BoxLayout.LINE_AXIS));
        schDirPanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        schDirPanel.setBorder(BorderFactory.createEmptyBorder(20, 10, 10, 10));
        schDirPanel.add(new JLabel("Set Schedule Advanced Command(Select a Json file which exported by EDM Schedule s" +
                "etup dialog)"));

        add(schDirPanel);

        schedulePanel = new JPanel();
        schedulePanel.setLayout(new BoxLayout(schedulePanel, BoxLayout.LINE_AXIS));
        schedulePanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        schedulePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        schedulePanel.add(new JLabel("Set Schedule"));
        schedulePanel.add(new JLabel("             "));

        scheduleTf = new JTextField();
        scheduleTf.setMaximumSize(new Dimension(750, 30));
        schedulePanel.add(scheduleTf);
        schedulePanel.add(new JLabel("    "));
        scheduleBrowse = new JButton("Browse");
        scheduleBrowse.addActionListener(this);
        schedulePanel.add(scheduleBrowse);
        schedulePanel.add(new JLabel("    "));
        scheduleSet = new JButton("Set");
        scheduleSet.addActionListener(this);
        schedulePanel.add(scheduleSet);
        add(schedulePanel);

        vcsDirPanel = new JPanel();
        vcsDirPanel.setLayout(new BoxLayout(vcsDirPanel, BoxLayout.LINE_AXIS));
        vcsDirPanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        vcsDirPanel.setBorder(BorderFactory.createEmptyBorder(20, 10, 10, 10));
        vcsDirPanel.add(new JLabel("VCS Advanced Command(Select a CSV file which exported by VCS profile editor)"));

        add(vcsDirPanel);

        randomProfilePanel = new JPanel();
        randomProfilePanel.setLayout(new BoxLayout(randomProfilePanel, BoxLayout.LINE_AXIS));
        randomProfilePanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        randomProfilePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        randomProfilePanel.add(new JLabel("Set Random Profile"));
        randomProfilePanel.add(new JLabel("  "));

        randomProfileTf = new JTextField();
        randomProfileTf.setMaximumSize(new Dimension(750, 30));
        randomProfilePanel.add(randomProfileTf);
        randomProfilePanel.add(new JLabel("    "));
        randomBrowse = new JButton("Browse");
        randomBrowse.addActionListener(this);
        randomProfilePanel.add(randomBrowse);
        randomProfilePanel.add(new JLabel("    "));
        randomSet = new JButton("Set");
        randomSet.addActionListener(this);
        randomProfilePanel.add(randomSet);
        add(randomProfilePanel);

        sinePanel = new JPanel();
        sinePanel.setLayout(new BoxLayout(sinePanel, BoxLayout.LINE_AXIS));
        sinePanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        sinePanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        sinePanel.add(new JLabel("Set Sine Profile"));
        sinePanel.add(new JLabel("         "));

        sineProfileTf = new JTextField();
        sineProfileTf.setMaximumSize(new Dimension(750, 30));
        sinePanel.add(sineProfileTf);
        sinePanel.add(new JLabel("    "));
        sineBrowse = new JButton("Browse");
        sineBrowse.addActionListener(this);
        sinePanel.add(sineBrowse);
        sinePanel.add(new JLabel("    "));
        sineSet = new JButton("Set");
        sineSet.addActionListener(this);
        sinePanel.add(sineSet);
        add(sinePanel);


        shockPanel = new JPanel();
        shockPanel.setLayout(new BoxLayout(shockPanel, BoxLayout.LINE_AXIS));
        shockPanel.setAlignmentX(Component.LEFT_ALIGNMENT);
        shockPanel.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        shockPanel.add(new JLabel("Set Shock Profile"));
        shockPanel.add(new JLabel("      "));

        shockProfileTf = new JTextField();
        shockProfileTf.setMaximumSize(new Dimension(750, 30));
        shockPanel.add(shockProfileTf);
        shockPanel.add(new JLabel("    "));
        shockBrowse = new JButton("Browse");
        shockBrowse.addActionListener(this);
        shockPanel.add(shockBrowse);
        shockPanel.add(new JLabel("    "));
        shockSet = new JButton("Set");
        shockSet.addActionListener(this);
        shockPanel.add(shockSet);
        add(shockPanel);







    }


    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == channelBrowse){
            JFileChooser j = new JFileChooser();
            j.showSaveDialog(this);
            File file = j.getSelectedFile();
            channelTableTf.setText(file.getAbsolutePath());
            revalidate();
            repaint();
        }
        if(e.getSource() == scheduleBrowse){
            JFileChooser j = new JFileChooser();
            j.showSaveDialog(this);
            File file = j.getSelectedFile();
            scheduleTf.setText(file.getAbsolutePath());
            revalidate();
            repaint();
        }
        if(e.getSource() == randomBrowse){
            JFileChooser j = new JFileChooser();
            j.showSaveDialog(this);
            File file = j.getSelectedFile();
            randomProfileTf.setText(file.getAbsolutePath());
            revalidate();
            repaint();

        }
        if(e.getSource() == sineBrowse){
            JFileChooser j = new JFileChooser();
            j.showSaveDialog(this);
            File file = j.getSelectedFile();
            sineProfileTf.setText(file.getAbsolutePath());
            revalidate();
            repaint();

        }
        if(e.getSource() == shockBrowse){
            JFileChooser j = new JFileChooser();
            j.showSaveDialog(this);
            File file = j.getSelectedFile();
            shockProfileTf.setText(file.getAbsolutePath());
            revalidate();
            repaint();

        }
        if(e.getSource() == channelSet){
            try {
                String s = channelTableTf.getText();
                File file = new File(s);
                String str = FileUtils.readFileToString(file, "utf-8");
                MainFrame.mqttConfig.setChannelTable(str);

            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }

        }
        if(e.getSource() == scheduleSet){
            try {
                String s = scheduleTf.getText();
                File file = new File(s);
                String str = FileUtils.readFileToString(file, "utf-8");
                MainFrame.mqttConfig.setSchedule(str);

            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        }

        if(e.getSource() == randomSet){
            try {
                String s = randomProfileTf.getText();
                File file = new File(s);
                String str = FileUtils.readFileToString(file, "utf-8");
                MainFrame.mqttConfig.setRandomProfile(str);

            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        }
        if(e.getSource() == sineSet){
            try {
                String s = sineProfileTf.getText();
                File file = new File(s);
                String str = FileUtils.readFileToString(file, "utf-8");
                MainFrame.mqttConfig.setSineProfile(str);

            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        }
        if(e.getSource() == shockSet){
            try {
                String s = shockProfileTf.getText();
                File file = new File(s);
                String str = FileUtils.readFileToString(file, "utf-8");
                MainFrame.mqttConfig.setShockProfile(str);

            } catch (IOException ex) {
                throw new RuntimeException(ex);
            }
        }

    }
}
