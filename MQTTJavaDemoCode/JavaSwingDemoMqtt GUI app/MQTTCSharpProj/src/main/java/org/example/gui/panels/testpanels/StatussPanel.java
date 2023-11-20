package org.example.gui.panels.testpanels;

import org.example.gui.MainFrame;

import javax.swing.*;
import javax.swing.border.TitledBorder;
import java.awt.*;

/**
 * Status Tab in Test Tab
 */
public class StatussPanel extends JPanel {

    private JPanel testInfoPanel;
    private JTable testInfoJt;
    public JScrollPane testInfoSp;
    private JPanel limitStatusPanel;
    private JTable limitStatusJt;
    private JScrollPane limitStatusSp;
    private JPanel vcsTestStagePanel;
    private JTable testStageJt;
    private JScrollPane testStageSp;
    private JPanel vcsControlFlagPanel;
    private JTable controlFlagJt;
    private JScrollPane controlFlagSp;
    private JPanel recordStatusPanel;
    private JTable recordStatusJt;
    private JScrollPane recordStatusSp;




    /*
    Setters below are used to update the tables.
     */

    public void setTestInfo(JTable testInfoJt, JScrollPane testInfoSp){
        testInfoPanel.remove(this.testInfoSp);
        this.testInfoJt = testInfoJt;
        this.testInfoSp = testInfoSp;
        testInfoPanel.add(this.testInfoSp);
        revalidate();
        repaint();
    }
    public void setLimitStatusValues(JTable limitStatusJt, JScrollPane limitStatusSp){
        limitStatusPanel.remove(this.limitStatusSp);
        this.limitStatusJt = limitStatusJt;

        this.limitStatusSp = limitStatusSp;
        limitStatusPanel.add(this.limitStatusSp);
        revalidate();
        repaint();

    }
    public void setVcsTestStageValues(JTable jt, JScrollPane sp){
        vcsTestStagePanel.remove(testStageSp);
        testStageJt = jt;
        testStageSp = sp;
        vcsTestStagePanel.add(testStageSp);
        revalidate();
        repaint();

    }

    public void setVcsControlFlagValues(JTable jt, JScrollPane sp){
        vcsControlFlagPanel.remove(controlFlagSp);
        controlFlagSp = sp;
        controlFlagJt = jt;
        vcsControlFlagPanel.add(controlFlagSp);
        revalidate();
        repaint();
    }

    public void setRecordStatusValues(JTable jt, JScrollPane sp){
        recordStatusPanel.remove(recordStatusSp);
        recordStatusJt = jt;
        recordStatusSp = sp;
        recordStatusPanel.add(recordStatusSp);
        revalidate();
        repaint();

    }

    public StatussPanel(){
        setBounds(10,10, 1300,1300);
        setLayout(null);
        testInfoPanel = new JPanel();
        testInfoPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "Test Information", TitledBorder.LEFT,
                TitledBorder.TOP));
        testInfoPanel.setBounds(10,10, 500, 200);
        testInfoPanel.setLayout(new GridLayout(1, 1, 5, 5));
        String  [] columns = {"", ""};
        String [][]data = {{"Name", "<Name>"},{"Type","<Type>"},{"Status", "<Status>"}, {"Run Folder", "<Run Folder>"}, {"Measure Start At", "<Measure Start At>"}};
        testInfoJt = new JTable(data, columns);
        testInfoJt.setRowHeight(4, 50);
        testInfoJt.setTableHeader(null);
        testInfoSp = new JScrollPane(testInfoJt);
        testInfoPanel.add(testInfoSp);

        limitStatusPanel = new JPanel();
        limitStatusPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "Limit Status", TitledBorder.LEFT,
                TitledBorder.TOP));
        limitStatusPanel.setBounds(600, 10, 500, 200);
        limitStatusPanel.setLayout(new GridLayout(1, 1, 5, 5));
        String [] lsColumns = {"", ""};
        String [][] lsData = {{"Name", "<Name>"}, {"Status", "<Status>"}};
        limitStatusJt = new JTable(lsData, lsColumns);
        limitStatusJt.setRowHeight(1, 70);
        limitStatusJt.setTableHeader(null);
        limitStatusSp = new JScrollPane(limitStatusJt);
        limitStatusPanel.add(limitStatusSp);

        vcsTestStagePanel = new JPanel();
        vcsTestStagePanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "VCS Test Stage", TitledBorder.LEFT,
                TitledBorder.TOP));
        vcsTestStagePanel.setBounds(10, 250, 500, 125);
        vcsTestStagePanel.setLayout(new GridLayout(1, 1, 5, 5));
        String [] tsColumns = {"", ""};
        String [][] tsData = {{"Name", "<Name>"}, {"Stage", "<Stage>"}};
        testStageJt = new JTable(tsData, tsColumns);
        testStageJt.setRowHeight(1, 70);
        testStageJt.setTableHeader(null);
        testStageSp = new JScrollPane(testStageJt);
        vcsTestStagePanel.add(testStageSp);

        vcsControlFlagPanel= new JPanel();
        vcsControlFlagPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "VCS Control Flag", TitledBorder.LEFT,
                TitledBorder.TOP));
        vcsControlFlagPanel.setBounds(600, 250, 500, 125);
        vcsControlFlagPanel.setLayout(new GridLayout(1, 1, 5, 5));
        String [] cfColumns = {"", ""};
        String [][] cfData = {{"Name", "<Name>"}, {"Flag", "<Stage>"}};
        controlFlagJt = new JTable(cfData, cfColumns);
        controlFlagJt.setRowHeight(1, 70);
        controlFlagJt.setTableHeader(null);
        controlFlagSp = new JScrollPane(controlFlagJt);
        vcsControlFlagPanel.add(controlFlagSp);


        recordStatusPanel= new JPanel();
        recordStatusPanel.setBorder(BorderFactory.createTitledBorder(
                BorderFactory.createEtchedBorder(), "VCS Control Flag", TitledBorder.LEFT,
                TitledBorder.TOP));
        recordStatusPanel.setBounds(10, 400, 500, 125);
        recordStatusPanel.setLayout(new GridLayout(1, 1, 5, 5));
        String [] rsColumns = {"", ""};
        String [][] rsData = {{"Name", "<Name>"}, {"Flag", "<Stage>"}};
        recordStatusJt = new JTable(rsData, rsColumns);
        recordStatusJt.setRowHeight(1, 70);
        recordStatusJt.setTableHeader(null);
        recordStatusSp = new JScrollPane(recordStatusJt);
        recordStatusPanel.add(recordStatusSp);


        add(testInfoPanel);
        add(limitStatusPanel);
        add(vcsTestStagePanel);
        add(vcsControlFlagPanel);
        add(recordStatusPanel);

    }
}
