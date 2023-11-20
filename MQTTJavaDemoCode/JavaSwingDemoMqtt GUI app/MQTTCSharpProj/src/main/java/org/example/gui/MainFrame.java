package org.example.gui;

import org.eclipse.paho.client.mqttv3.MqttException;
import org.example.exception.BrokerConnectionException;
import org.example.gui.panels.*;
import org.example.gui.panels.testpanels.*;
import org.example.mqtt.MqttConfig;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.Arrays;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

/**
 * Entry point of the GUI.
 * Contains all the panels in the gui directory.
 * Revalidate()->repaint() is used to update GUI
 */
public class MainFrame extends JFrame implements ActionListener {
    private JPanel mainPanel;
    private MqttPanel mqttPanel;
    public static SystemPanel systemPanel;
    private CommandPanel commandPanel;
    public static StatussPanel statussPanel;
    public static DetailStatusPanel detailStatusPanel;

    private ChannelsPanel channelsPanel;

    private ShakerPanel shakerPanel;


    private JScrollPane shakerSP;
    private JScrollPane channelsSP;


    private TestPanel testPanel;

    private JTabbedPane tabbedPane;

    public static MqttConfig mqttConfig;

    public static SignalPanel signalPanel;

    private ReportPanel reportPanel;
    private FilePanel filePanel;

    private JPanel brokerStatusPanel;
    private JLabel status;
    private ThreadPoolExecutor  executor = (ThreadPoolExecutor) Executors.newFixedThreadPool(1);;

    public MainFrame(){
            mqttPanel = new MqttPanel();
            systemPanel = new SystemPanel();
            testPanel = new TestPanel();
            signalPanel = new SignalPanel();
            reportPanel = new ReportPanel();
            filePanel = new FilePanel();
            tabbedPane = new JTabbedPane();
            mqttPanel.connect.addActionListener(this);
            mqttPanel.disconnect.addActionListener(this);
            for (int i = 0; i < 6; ++i)
                signalPanel.check[i].addActionListener(this);
            signalPanel.getSignalProp.addActionListener(this);
            signalPanel.selectInverse.addActionListener(this);
            signalPanel.selectAll.addActionListener(this);
            commandPanel = (CommandPanel) testPanel.pane.getComponents()[0];
            commandPanel.connect.addActionListener(this);
            commandPanel.run.addActionListener(this);
            commandPanel.disconnect.addActionListener(this);
            commandPanel.pause.addActionListener(this);
            commandPanel.cont.addActionListener(this);
            commandPanel.stop.addActionListener(this);
            commandPanel.startRecord.addActionListener(this);
            commandPanel.stopRecord.addActionListener(this);
            commandPanel.saveSignals.addActionListener(this);
            statussPanel = (StatussPanel) testPanel.pane.getComponentAt(1);
            detailStatusPanel = (DetailStatusPanel) testPanel.pane.getComponentAt(2);

            channelsSP = (JScrollPane) testPanel.pane.getComponents()[3];
            channelsPanel
                    = new ChannelsPanel();

            shakerSP = (JScrollPane) testPanel.pane.getComponents()[4];
            shakerPanel = new ShakerPanel();

            setBounds(10, 10, 1500, 1500);
            tabbedPane.add(mqttPanel, "Mqtt");
            tabbedPane.add(systemPanel, "System");
            tabbedPane.add(testPanel, "Test");
            tabbedPane.add(reportPanel, "Report");
            tabbedPane.add(filePanel, "File");
            tabbedPane.add(signalPanel, "Signal");


            mainPanel = new JPanel();
            mainPanel.setLayout(new BorderLayout());
            mainPanel.add(tabbedPane, BorderLayout.CENTER);
            brokerStatusPanel = new JPanel();
            status = new JLabel("Disconnected");
            status.setForeground(Color.red);
            brokerStatusPanel.add(status);
            mainPanel.add(brokerStatusPanel, BorderLayout.PAGE_END);
            add(mainPanel);
            pack();
            setVisible(true);

    }

    @Override
    public void actionPerformed(ActionEvent e) {
        try {
            if (e.getSource() == mqttPanel.disconnect) {
                mqttPanel.disconnect.setEnabled(false);
                mqttPanel.connect.setEnabled(true);
                mqttConfig.disconnectMqtt();
                brokerStatusPanel.removeAll();
                status = new JLabel("Disconnected");
                status.setForeground(Color.red);
                brokerStatusPanel.add(status);
                revalidate();
                repaint();
            }
            /*
            After connecting, values in other panels have to be set which is why
            certain buttons from other classes are bound here.
             */
            if (e.getSource() == mqttPanel.connect) {
                mqttPanel.connect.setEnabled(false);
                mqttPanel.disconnect.setEnabled(true);
                String brokerIp = mqttPanel.getBrokerIp().getText();
                String username = mqttPanel.getUsername().getText();
                String password = Arrays.toString(mqttPanel.getPassword().getPassword());
                String prefix = mqttPanel.getTopicPrefix().getText();
                /*
                Connecting to broker here. Used thread in order to prevent gui from pausing
                after clicking connect.
                 */
                executor.execute(()->{
                    try {
                        mqttConfig = new MqttConfig(brokerIp, username, password, prefix);

                        brokerStatusPanel.removeAll();
                        status = new JLabel("Connected");
                        status.setForeground(Color.green);
                        brokerStatusPanel.add(status);
                        revalidate();
                        repaint();
                        Thread.sleep(1000);
                        channelsPanel.setValues();
                        channelsSP = channelsPanel.sp;
                        testPanel.pane.setComponentAt(3, channelsSP);

                        shakerPanel.setValues();
                        shakerSP = shakerPanel.sp;
                        testPanel.pane.setComponentAt(4, shakerSP);


                        signalPanel.setValues();
                    } catch (MqttException | InterruptedException ex) {
                        throw new RuntimeException(ex);
                    }
                });



            }
            if (e.getSource() == commandPanel.connect) {

                MainFrame.mqttConfig.connect();
            }

            if (e.getSource() == commandPanel.disconnect) mqttConfig.disconnect();

            if (e.getSource() == commandPanel.run) {
                mqttConfig.run();
            }
            if (e.getSource() == commandPanel.pause) mqttConfig.pause();

            if (e.getSource() == commandPanel.cont) mqttConfig.cont();

            if (e.getSource() == commandPanel.stop) mqttConfig.stop();

            if (e.getSource() == commandPanel.startRecord) mqttConfig.startRecord();

            if (e.getSource() == commandPanel.stopRecord) mqttConfig.stopRecord();
            if (e.getSource() == commandPanel.saveSignals) mqttConfig.saveSignals();

            if (e.getSource() == commandPanel.checkOnly) {
                MainFrame.mqttConfig.checkOnly();

            }

        } catch(BrokerConnectionException | NullPointerException ex){
            status = new JLabel("Disconnected - Not connected to broker. Unable to publish message");
            status.setForeground(Color.red);
            brokerStatusPanel.removeAll();
            brokerStatusPanel.add(status);
            revalidate();
            repaint();

        }catch (MqttException ex) {
            throw new RuntimeException(ex);
        }

    }
}
