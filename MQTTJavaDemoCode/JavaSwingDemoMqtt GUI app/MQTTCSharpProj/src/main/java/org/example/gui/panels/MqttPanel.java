package org.example.gui.panels;


import javax.swing.*;
import java.awt.*;

/**
 * Used to connect to broker. No Broker port field because the port will always be 1883.
 */
public class MqttPanel extends JPanel {
    private JPanel upperPanel;
    private JTextField brokerIp;
    private JTextField topicPrefix;
    private JTextField username;
    private JPasswordField password;
    public  JButton connect;
    public  JButton disconnect;

    public MqttPanel(){
        setLayout(new GridLayout(2,2));
        upperPanel = new JPanel();
        upperPanel.setSize(600,750);
        upperPanel.setLayout(new GridLayout(6,2,30, 20));
        JLabel broke = new JLabel("Broker IP");
        upperPanel.add( broke);
        brokerIp = new JTextField("192.168.10.110");
        topicPrefix = new JTextField("EDM");
        username = new JTextField("Admin");
        password = new JPasswordField("123456");
        upperPanel.add(brokerIp);
        upperPanel.add(new JLabel("Topic Prefix"));
        upperPanel.add(topicPrefix);
        upperPanel.add(new JLabel("Username"));
        upperPanel.add(username);
        upperPanel.add(new JLabel("Password"));
        upperPanel.add(password);
        connect = new JButton("Connect");
        disconnect = new JButton("Disconnect");
        disconnect.setEnabled(false);
        upperPanel.add(connect);
        upperPanel.add(disconnect);

        add(upperPanel);
        add(new JPanel());
        add(new JPanel());
        add(new JPanel());




    }

    public JTextField getBrokerIp() {
        return brokerIp;
    }

    public JTextField getTopicPrefix() {
        return topicPrefix;
    }

    public JTextField getUsername() {
        return username;
    }

    public JPasswordField getPassword() {
        return password;
    }
}
