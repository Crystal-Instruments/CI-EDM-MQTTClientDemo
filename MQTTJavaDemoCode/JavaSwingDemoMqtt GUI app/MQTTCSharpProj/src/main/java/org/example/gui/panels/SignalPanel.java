package org.example.gui.panels;


import org.example.gui.MainFrame;
import org.example.messages.MqttSignalFrameData;
import org.example.messages.MqttSignalProperty;

import org.example.messages.Signals;
import org.example.utils.XYChartConfig;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;

import javax.swing.*;
import javax.swing.table.AbstractTableModel;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

/**
 * Signal tab
 */
public class SignalPanel extends JPanel implements ActionListener {
    private JTable j;
    private JPanel upperPanel;
    private JTable secondJ;

    public JScrollPane sp;

    public JScrollPane signalPropSp;
    private boolean DEBUG = false;
    public JCheckBox[] check = new JCheckBox[6];
    JPanel bottomPanel;
    JPanel biggerBottomPanel;

    private ChartPanel cp;
    ThreadPoolExecutor executor = (ThreadPoolExecutor) Executors.newFixedThreadPool(2);



    private ConcurrentHashMap<String, MqttSignalFrameData> checkedSignals;

    private boolean signalsSet;

    public JButton getSignalProp;

    public JButton selectAll;
    public JButton selectInverse;


    private List<JCheckBox> signalPropCheck;


    XYChartConfig chart = new XYChartConfig("Chart Data",
            "Chart Data", new ArrayList<>());
    public SignalPanel(){
        signalsSet = false;
        signalPropCheck = new ArrayList<>();

        checkedSignals = new ConcurrentHashMap<>();
        setPreferredSize(new Dimension(900, 900));
        setLayout(new GridLayout(3,1));
        setBorder(BorderFactory.createLineBorder(Color.blue));
        Object [][]data = {
        };
        upperPanel = new JPanel();
        upperPanel.setLayout(new GridLayout(1,1));
        biggerBottomPanel = new JPanel();
        biggerBottomPanel.setLayout(new BorderLayout());

        j = new JTable(new MyTableModel(data));
        j.setBounds(30, 40, 500, 600);
        sp = new JScrollPane(j);
        upperPanel.add(sp);
        add(upperPanel);



        JFreeChart updatedChart = ChartFactory.createXYLineChart(
                "Signal frame data",
                "" ,
                "" ,
                chart.createDataset(new ArrayList<>()) ,
                PlotOrientation.VERTICAL ,
                true , true , false);
        cp = new ChartPanel(updatedChart);
        cp.setMouseWheelEnabled(true);
        cp.setDomainZoomable(true);
        cp.setRangeZoomable(false);
        add(cp);

        bottomPanel = new JPanel();
        bottomPanel.setLayout( new BoxLayout(bottomPanel, BoxLayout.LINE_AXIS));
        String []columns = {"Name", "RMS", "Peak", "PkPk", "Min", "Max", "Mean", "Unit"};
        String [][]d ={};

        secondJ = new JTable(d, columns);
        signalPropSp = new JScrollPane(secondJ);


        getSignalProp = new JButton("Get Signal Property");
        getSignalProp.setLayout(null);

        getSignalProp.setSize(30,30);

        getSignalProp.addActionListener(this);
        bottomPanel.add(getSignalProp);
        check[0] = new JCheckBox("RMS");
        check[1] = new JCheckBox("Peak");
        check[2] = new JCheckBox("PkPk");
        check[3] = new JCheckBox("Min");
        check[4] = new JCheckBox("Max");
        check[5] = new JCheckBox("Mean");
        for(int i = 0; i < 6; i++)
        {
            bottomPanel.add(check[i]);
            check[i].addActionListener(this);
        }

        selectAll = new JButton("Select All");

        selectInverse = new JButton("Select Inverse");

        selectInverse.addActionListener(this);
        selectAll.addActionListener(this);


        bottomPanel.add(selectInverse);
        bottomPanel.add(selectAll);




        biggerBottomPanel.add(bottomPanel, BorderLayout.PAGE_START);
        biggerBottomPanel.add(signalPropSp, BorderLayout.CENTER);
        add(biggerBottomPanel);
        setVisible(true);

    }

    public JFreeChart getChart(String xAxis, String yAxis, ArrayList<MqttSignalFrameData> dataset){
        return ChartFactory.createXYLineChart(
                "Signal frame data",
                xAxis ,
                yAxis ,
                chart.createDataset(dataset),
                PlotOrientation.VERTICAL ,
                true , true , false);

    }

    public void executeShowChart(){
        Runnable runnable = this::showChart;
        executor.execute(runnable);

    }

    /**
     * showChart() is used to repeatedly update signal graph while status of test is “Running”
     */
    public void showChart(){
        while(MainFrame.mqttConfig.getCurrStatus().equals("Running")) {
            String xAxis = " ", yAxis =" ";
            Iterator<ConcurrentHashMap.Entry<String, MqttSignalFrameData>>
                    itr = checkedSignals.entrySet().iterator();
            StringBuilder chan = new StringBuilder();
            while (itr.hasNext()) {
                ConcurrentHashMap.Entry<String, MqttSignalFrameData> entry
                        = itr.next();
                synchronized (MainFrame.mqttConfig.getLock()) {
                    if (MainFrame.mqttConfig.getConnectToBroker()) {
                        chan.append(entry.getKey());
                        chan.append(";");
                    }
                }
            }
            synchronized(MainFrame.mqttConfig.getLock()) {
                if (MainFrame.mqttConfig.getConnectToBroker()) {
                    if(chan.toString().length()>2 )//&& MainFrame.mqttConfig.mqttSystemStatus.Status.equals("Connected"))
                        MainFrame.mqttConfig.getChannelData(chan.toString());
                }
            }

            try {
                Thread.sleep(500);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            ArrayList<MqttSignalFrameData> signalDataList = (ArrayList<MqttSignalFrameData>) MainFrame.mqttConfig.signalFrameDataList;
            ArrayList<MqttSignalFrameData> frameData = new ArrayList<>(signalDataList);
            for(MqttSignalFrameData d: frameData){
                xAxis = d.Signal.UnitX;
                yAxis = d.Signal.UnitY;
            }


            if(chan.toString().length()< 2) frameData = new ArrayList<>();
            JFreeChart updatedChart = getChart(xAxis,yAxis, frameData);
            cp.setChart(updatedChart);
        }
    }
    public void setValues(){
        if(!signalsSet) {
            List<Signals> signalList = MainFrame.mqttConfig.signalList;
            if (!signalList.isEmpty()) {
                Object[][] data = new Object[signalList.size()][7];
                int i = 0;
                for (Signals s : signalList) {
                    data[i][0] = false;
                    data[i][1] = s.Name;
                    data[i][2] = s.Type;
                    data[i][3] = s.BlockSize;
                    data[i][4] = s.SamplingRate;
                    data[i][5] = s.UnitX;
                    data[i][6] = s.UnitY;
                    ++i;
                }
                MyTableModel tb = new MyTableModel(data);
                upperPanel.remove(sp);

                j = new JTable(tb);
                sp = new JScrollPane(j);
                upperPanel.add(sp);
                revalidate();
                repaint();
                cp.setVisible(true);
                signalsSet = true;

            }
        }

    }

    /**
     * Bottom function is mainly used to check update signal property values on table
     *
     */
    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == check[0]){
            if(check[0].isSelected()) signalPropCheck.add(check[0]);
            else signalPropCheck.remove(check[0]);
        }
        if(e.getSource() == check[1]){
            if(check[1].isSelected()) signalPropCheck.add(check[1]);
            else signalPropCheck.remove(check[1]);
        }
        if(e.getSource() == check[2]){
            if(check[2].isSelected()) signalPropCheck.add(check[2]);
            else signalPropCheck.remove(check[2]);
        }
        if(e.getSource() == check[3]){
            if(check[3].isSelected()) signalPropCheck.add(check[3]);
            else signalPropCheck.remove(check[3]);
        }
        if(e.getSource() == check[4]){
            if(check[4].isSelected()) signalPropCheck.add(check[4]);
            else signalPropCheck.remove(check[4]);
        }
        if(e.getSource() == check[5]){
            if(check[5].isSelected()) signalPropCheck.add(check[5]);
            else signalPropCheck.remove(check[5]);
        }
        if(e.getSource() == getSignalProp){
            ArrayList<String>checkedProps = new ArrayList<>();
            if(check[0].isSelected()) checkedProps.add("RMS");
            if(check[1].isSelected()) checkedProps.add("Peak");
            if(check[2].isSelected()) checkedProps.add("PkPk");
            if(check[3].isSelected()) checkedProps.add("Min");
            if(check[4].isSelected()) checkedProps.add("Max");
            if(check[5].isSelected()) checkedProps.add("Mean");

            String [] [] propData = new String[19][8];
            int index = 0;
            for (ConcurrentHashMap.Entry<String, MqttSignalFrameData> entry : checkedSignals.entrySet()) {
                String name = entry.getKey();
                String [] indPropData = new String [8];
                for(int i=1; i<8; ++i) indPropData[i] = " ";
                for (String s : checkedProps) {
                    System.out.println(s);

                    indPropData[0] = name;

                    MainFrame.mqttConfig.getSignalProperty(s, name);
                    try {
                        Thread.sleep(250);
                    } catch (InterruptedException ex) {
                        throw new RuntimeException(ex);
                    }
                    List<MqttSignalProperty> sgp = MainFrame.mqttConfig.signalPropList;
                    MqttSignalProperty prop = sgp.get(0);
                    if(s.equals("RMS")) indPropData[1] = String.valueOf(prop.Value);
                    if(s.equals("Peak")) indPropData[2]  = String.valueOf(prop.Value);
                    if(s.equals("PkPk")) indPropData[3] = String.valueOf(prop.Value);
                    if(s.equals("Min")) indPropData[4]  = String.valueOf(prop.Value);
                    if(s.equals("Max")) indPropData[5] = String.valueOf(prop.Value);
                    if(s.equals("Mean")) indPropData[6]  = String.valueOf(prop.Value);
                    indPropData[7] = prop.Unit;


                }
                propData[index++] = indPropData;
            }
            String []columns = {"Name", "RMS", "Peak", "PkPk", "Min", "Max", "Mean", "Unit"};



            secondJ = new JTable(propData, columns);

            biggerBottomPanel.remove(signalPropSp);
            signalPropSp = new JScrollPane(secondJ);
            //remove
            biggerBottomPanel.add(signalPropSp, BorderLayout.CENTER);
            biggerBottomPanel.revalidate();
            biggerBottomPanel.repaint();


        }
        if(e.getSource()== selectAll){
            signalPropCheck.clear();
            for(int i =0; i<6;++i){
                check[i].setSelected(true);
                signalPropCheck.add(check[i]);
            }
        }
        if(e.getSource() == selectInverse){
            for(int i =0; i<6; ++i) check[i].setSelected(!check[i].isSelected());
        }


    }

    /**
     * Table model allows gui to choose which signals to display on the graph
     */
    class MyTableModel extends AbstractTableModel{
        String [] columns = {" ","Name", "Type", "Block Size", "Sampling Rate", "Unit X", "Unit Y"};
        Object [][]data;
        public MyTableModel(Object[][] data){
            this.data = data;
        }
        public void setColumns(String[] columns) {
            this.columns = columns;
        }

        public void setData(Object[][] data) {
            this.data = data;
        }

        public int getColumnCount() {
            return columns.length;
        }

        public int getRowCount() {
            return data.length;
        }

        public String getColumnName(int col) {
            return columns[col];
        }

        public Object getValueAt(int row, int col) {
            return data[row][col];
        }

        public Class getColumnClass(int c) {
            return getValueAt(0, c).getClass();
        }
        public boolean isCellEditable(int row, int col) {
            //Note that the data/cell address is constant,
            //no matter where the cell appears onscreen.
            if (col > 0) {
                return false;
            } else {
                return true;
            }
        }


        public void setValueAt(Object value, int row, int col) {
            if((Boolean) value) {
                String name = (String) data[row][1];
                MainFrame.mqttConfig.getChannelData((String)data[row][1]);
                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
                ArrayList<MqttSignalFrameData> signalDataList = (ArrayList<MqttSignalFrameData>) MainFrame.mqttConfig.signalFrameDataList;
                for(MqttSignalFrameData m: signalDataList){
                        checkedSignals.put(name,m);
                }
                String xAxis = (String) data[row][5];
                String yAxis = (String)data[row][6];
                if(!MainFrame.mqttConfig.getCurrStatus().equals("Running")) {
                    Iterator<ConcurrentHashMap.Entry<String, MqttSignalFrameData>>
                            itr = checkedSignals.entrySet().iterator();
                    ArrayList<MqttSignalFrameData> frameData = new ArrayList<>();
                    while (itr.hasNext()) {
                        ConcurrentHashMap.Entry<String, MqttSignalFrameData> entry
                                = itr.next();
                        frameData.add(entry.getValue());
                    }
                    JFreeChart updatedChart = getChart(xAxis,yAxis, frameData);
                    cp.setChart(updatedChart);
                }

            }
            else {
                checkedSignals.remove((String) data[row][1]);
                String xAxis = "";
                String yAxis = "";
                if(!MainFrame.mqttConfig.getCurrStatus().equals("Running")) {
                    Iterator<ConcurrentHashMap.Entry<String, MqttSignalFrameData>>
                            itr = checkedSignals.entrySet().iterator();
                    ArrayList<MqttSignalFrameData> frameData = new ArrayList<>();
                    while (itr.hasNext()) {
                        ConcurrentHashMap.Entry<String, MqttSignalFrameData> entry
                                = itr.next();
                        frameData.add(entry.getValue());
                        xAxis = entry.getValue().Signal.UnitX;
                        yAxis = entry.getValue().Signal.UnitY;
                    }
                    JFreeChart updatedChart = getChart(xAxis,yAxis, frameData);
                    cp.setChart(updatedChart);
                }
            }



            if (DEBUG) {
                System.out.println("Setting value at " + row + "," + col
                        + " to " + value
                        + " (an instance of "
                        + value.getClass() + ")");
            }

            data[row][col] = value;
            fireTableCellUpdated(row, col);

            if (DEBUG) {
                System.out.println("New value of data:");
                printDebugData();
            }
        }

        private void printDebugData() {
            int numRows = getRowCount();
            int numCols = getColumnCount();

            for (int i=0; i < numRows; i++) {
                System.out.print("    row " + i + ":");
                for (int j=0; j < numCols; j++) {
                    System.out.print("  " + data[i][j]);
                }
                System.out.println();
            }
            System.out.println("--------------------------");
        }
    }

}



