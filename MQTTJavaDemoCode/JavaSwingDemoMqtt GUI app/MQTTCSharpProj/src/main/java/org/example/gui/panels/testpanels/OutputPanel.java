package org.example.gui.panels.testpanels;

import org.example.Main;
import org.example.gui.MainFrame;

import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * DSA Output tab
 */
public class OutputPanel extends JPanel implements ActionListener {
    private JPanel upperPanel;

    private JPanel buttonPanelTop;
    private JPanel buttonPanelBottom;
    private JButton outputOn;
    private JButton outputOff;
    private JButton setOutputParameters;
    private JButton setOutputIndex;
    private JSpinner outputIndex;
    private JPanel middlePanel;

    private JPanel mainPanel;

    private JPanel sinePanel;
    private JCheckBox sine;

    private JSpinner sineAmp;
    private JSpinner sineFreq;
    private JSpinner sineOffset;


    private JPanel trianglePanel;

    private JCheckBox triangle;

    private JSpinner triangleAmp;
    private JSpinner triangleFreq;

    private JPanel squarePanel;

    private JCheckBox square;

    private JSpinner squareAmp;
    private JSpinner squareFreq;

    private JPanel whiteNoisePanel;

    private JCheckBox whiteNoise;
    private JSpinner whiteNoiseRMS;


    private JPanel bottomPanel;

    private JPanel pinkNoisePanel;
    private JCheckBox pinkNoise;
    private JSpinner pinkNoiseRMS;

    private JPanel dcPanel;
    private JCheckBox dc;
    private JSpinner dcAmp;
    private JPanel chirpPanel;
    private JCheckBox chirp;
    private JSpinner chirpAmp;
    private JSpinner chirpLowFreq;
    private JSpinner chirpHighFreq;
    private JSpinner chirpPercent;
    private JSpinner chirpPeriod;
    private JPanel sweptSinePanel;
    private JCheckBox sweptSine;
    private JSpinner sweptSineAmp;
    private JSpinner sweptSineLowFreq;
    private JSpinner sweptSineHighFreq;
    private JSpinner sweptSinePeriod;

    public OutputPanel(){
        Border blackline = BorderFactory.createLineBorder(Color.black);
        setLayout(new BorderLayout());
        upperPanel = new JPanel();
        upperPanel.setLayout( new BoxLayout(upperPanel, BoxLayout.LINE_AXIS));
        buttonPanelTop = new JPanel();
        buttonPanelTop.setLayout(new GridLayout(2,2 ,10,10));
        buttonPanelTop.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        outputOn = new JButton("Output On");
        outputOn.addActionListener(this);
        outputOn.setPreferredSize(new Dimension(400, 30));
        buttonPanelTop.add(outputOn);
        outputOff = new JButton("Output Off");
        outputOff.addActionListener(this);
        buttonPanelTop.add(outputOff);
        buttonPanelTop.add( new JLabel("   " ));
        setOutputParameters = new JButton("Set Output Parameters");
        setOutputParameters.addActionListener(this);
        buttonPanelTop.add(setOutputParameters);
        setOutputIndex = new JButton("Set Output Index");
        setOutputIndex.addActionListener(this);
        buttonPanelTop.add(setOutputIndex);
        buttonPanelBottom = new JPanel();
        buttonPanelBottom.setLayout(new BoxLayout(buttonPanelBottom, BoxLayout.PAGE_AXIS));
        buttonPanelBottom.setBorder(BorderFactory.createEmptyBorder(0, 10, 10, 10));
        buttonPanelBottom.add(new JLabel("(Output index starts from 0 to N-1)"));
        SpinnerModel sm = new SpinnerNumberModel(0,0, 16,1);
        outputIndex = new JSpinner(sm);
        outputIndex.setMaximumSize(new Dimension(500,30));
        buttonPanelBottom.add(outputIndex);
        buttonPanelTop.add(buttonPanelBottom);
        upperPanel.add(buttonPanelTop);

        add(upperPanel, BorderLayout.PAGE_START);


        middlePanel = new JPanel();
        mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.PAGE_AXIS));
        middlePanel.setLayout(new BoxLayout(middlePanel, BoxLayout.LINE_AXIS));


        sinePanel = new JPanel();
        sinePanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        sinePanel.setLayout(new GridLayout(10, 1, 20,5));
        sine = new JCheckBox("Sine");
        sine.addActionListener(this);
        sinePanel.add(sine);
        sinePanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        sineAmp = new JSpinner(sm);
        sinePanel.add(sineAmp);
        sinePanel.add(new JLabel("Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        sineFreq = new JSpinner(sm);
        sinePanel.add(sineFreq);
        sinePanel.add(new JLabel("Offset"));
        sm = new SpinnerNumberModel(0,0,  99999999,1);
        sineOffset = new JSpinner(sm);
        sinePanel.add(sineOffset);
        sinePanel.add(new JLabel(""));
        sinePanel.add(new JLabel(""));
        sinePanel.add(new JLabel(""));
        middlePanel.add(sinePanel);

        trianglePanel = new JPanel();
        trianglePanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        trianglePanel.setLayout(new GridLayout(10, 1, 20,5));
        triangle = new JCheckBox("Triangle");
        triangle.addActionListener(this);
        trianglePanel.add(triangle);
        trianglePanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        triangleAmp = new JSpinner(sm);
        trianglePanel.add(triangleAmp);
        trianglePanel.add(new JLabel("Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        triangleFreq = new JSpinner(sm);
        trianglePanel.add(triangleFreq);
        trianglePanel.add(new JLabel(""));
        trianglePanel.add(new JLabel(""));
        trianglePanel.add(new JLabel(""));
        trianglePanel.add(new JLabel(""));
        trianglePanel.add(new JLabel(""));
        middlePanel.add( trianglePanel);

        squarePanel = new JPanel();
        squarePanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        squarePanel.setLayout(new GridLayout(10, 1, 20,5));
        square = new JCheckBox("Square");
        square.addActionListener(this);
        squarePanel.add(square);
        squarePanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        squareAmp = new JSpinner(sm);
        squarePanel.add(squareAmp);
        squarePanel.add(new JLabel("Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        squareFreq = new JSpinner(sm);
        squarePanel.add(squareFreq);
        squarePanel.add(new JLabel(""));
        squarePanel.add(new JLabel(""));
        squarePanel.add(new JLabel(""));
        squarePanel.add(new JLabel(""));
        squarePanel.add(new JLabel(""));
        middlePanel.add(squarePanel);


        whiteNoisePanel = new JPanel();
        whiteNoisePanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        whiteNoisePanel.setLayout(new GridLayout(10, 1, 20,5));
        whiteNoise = new JCheckBox("White Noise");
        whiteNoise.addActionListener(this);
        whiteNoisePanel.add(whiteNoise);
        whiteNoisePanel.add(new JLabel("RMS"));
        sm = new SpinnerNumberModel(1.000,0,   99999999,0.001);
        whiteNoiseRMS = new JSpinner(sm);
        whiteNoisePanel.add(whiteNoiseRMS);
        whiteNoisePanel.add(new JLabel(""));
        whiteNoisePanel.add(new JLabel(""));
        whiteNoisePanel.add(new JLabel(""));
        whiteNoisePanel.add(new JLabel(""));
        whiteNoisePanel.add(new JLabel(""));
        middlePanel.add(whiteNoisePanel);

        mainPanel.add(middlePanel);

        bottomPanel = new JPanel();
        bottomPanel.setLayout(new BoxLayout(bottomPanel, BoxLayout.LINE_AXIS));

        pinkNoisePanel = new JPanel();
        pinkNoisePanel.setLayout(new GridLayout(10, 1, 20,5));
        pinkNoisePanel .setAlignmentX(Component.LEFT_ALIGNMENT);

        pinkNoisePanel .setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(0, 10, 10, 10)));
        pinkNoise = new JCheckBox("Pink Noise");
        pinkNoise.addActionListener(this);
        pinkNoisePanel .add(pinkNoise);
        pinkNoisePanel .add(new JLabel("RMS"));
        sm = new SpinnerNumberModel(1.000,0,   99999999,0.001);
        pinkNoiseRMS = new JSpinner(sm);
        pinkNoisePanel.add(pinkNoiseRMS);
        pinkNoisePanel.add(new JLabel(""));
        pinkNoisePanel.add(new JLabel(""));
        pinkNoisePanel.add(new JLabel(""));
        pinkNoisePanel.add(new JLabel(""));
        pinkNoisePanel.add(new JLabel(""));
        bottomPanel.add(pinkNoisePanel);

        dcPanel = new JPanel();
        dcPanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        dcPanel.setLayout(new GridLayout(10, 1, 20,5));
        dc= new JCheckBox("DC");
        dc.addActionListener(this);
        dcPanel.add(dc);
        dcPanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        dcAmp = new JSpinner(sm);
        dcPanel.add(dcAmp);
        dcPanel.add(new JLabel(""));
        dcPanel.add(new JLabel(""));
        dcPanel.add(new JLabel(""));
        dcPanel.add(new JLabel(""));
        dcPanel.add(new JLabel(""));
        bottomPanel.add(dcPanel);

        chirpPanel = new JPanel();
        chirpPanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        chirpPanel.setLayout(new GridLayout(11, 1, 20,5));
        chirp = new JCheckBox("Chirp");
        chirp.addActionListener(this);
        chirpPanel.add(chirp);
        chirpPanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        chirpAmp = new JSpinner(sm);
        chirpPanel.add(chirpAmp);
        chirpPanel.add(new JLabel("Low Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        chirpLowFreq = new JSpinner(sm);
        chirpPanel.add(chirpLowFreq);
        chirpPanel.add(new JLabel("High Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        chirpHighFreq = new JSpinner(sm);
        chirpPanel.add(chirpHighFreq);
        chirpPanel.add(new JLabel("Percent"));
        sm = new SpinnerNumberModel(0.001,0,  1,0.001);
        chirpPercent= new JSpinner(sm);
        chirpPanel.add(chirpPercent);
        chirpPanel.add(new JLabel("Period"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        chirpPeriod = new JSpinner(sm);
        chirpPanel.add(chirpPeriod);
        bottomPanel.add(chirpPanel);

        sweptSinePanel = new JPanel();
        sweptSinePanel.setBorder(BorderFactory.createCompoundBorder(blackline, new EmptyBorder(10, 10, 10, 10)));
        sweptSinePanel.setLayout(new GridLayout(11, 1, 20,5));
        sweptSine = new JCheckBox("Swept Sine");
        sweptSine.addActionListener(this);
        sweptSinePanel.add(sweptSine);
        sweptSinePanel.add(new JLabel("Amplitude"));
        sm = new SpinnerNumberModel(1,0,   99999999,1);
        sweptSineAmp = new JSpinner(sm);
        sweptSinePanel.add(sweptSineAmp);
        sweptSinePanel.add(new JLabel("Low Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        sweptSineLowFreq = new JSpinner(sm);
        sweptSinePanel.add(sweptSineLowFreq);
        sweptSinePanel.add(new JLabel("High Frequency"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        sweptSineHighFreq = new JSpinner(sm);
        sweptSinePanel.add(sweptSineHighFreq);
        sweptSinePanel.add(new JLabel("Period"));
        sm = new SpinnerNumberModel(1000,0,  99999999,1);
        sweptSinePeriod = new JSpinner(sm);
        sweptSinePanel.add(sweptSinePeriod);
        bottomPanel.add(sweptSinePanel);

        mainPanel.add(bottomPanel);
        add(mainPanel, BorderLayout.CENTER);



    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == outputOn) MainFrame.mqttConfig.outputOn();
        if(e.getSource() == outputOff) MainFrame.mqttConfig.outputOff();
        if(e.getSource() == sine){
            if(sine.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == triangle){
            if(triangle.isSelected()) {
                if (sine.isSelected()) sine.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == square){
            if(square.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == whiteNoise){
            if(whiteNoise.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == pinkNoise){
            if(pinkNoise.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == dc){
            if(dc.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == chirp){
            if(chirp.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
                if (sweptSine.isSelected()) sweptSine.setSelected(false);
            }
        }
        if(e.getSource() == sweptSine){
            if(sweptSine.isSelected()) {
                if (triangle.isSelected()) triangle.setSelected(false);
                if (square.isSelected()) square.setSelected(false);
                if (whiteNoise.isSelected()) whiteNoise.setSelected(false);
                if (pinkNoise.isSelected()) pinkNoise.setSelected(false);
                if (dc.isSelected()) dc.setSelected(false);
                if (chirp.isSelected()) chirp.setSelected(false);
                if (sine.isSelected()) sine.setSelected(false);
            }
        }
        if(e.getSource() == setOutputParameters){
            if(sine.isSelected()){
                Integer amp = (Integer) sineAmp.getValue();
                Integer freq = (Integer) sineFreq.getValue();
                Integer offset = (Integer) sineOffset.getValue();
                MainFrame.mqttConfig.outputSine(amp, freq, offset);
            }
            if(triangle.isSelected()){
                Integer amp = (Integer) triangleAmp.getValue();
                Integer freq = (Integer) triangleFreq.getValue();
                MainFrame.mqttConfig.outputTriangle(amp, freq);
            }
            if(square.isSelected()){
                Integer amp = (Integer) squareAmp.getValue();
                Integer freq = (Integer) squareFreq.getValue();
                MainFrame.mqttConfig.outputSquare(amp, freq);
            }
            if(whiteNoise.isSelected()){
                Double RMS = (Double) whiteNoiseRMS.getValue();
                MainFrame.mqttConfig.whiteNoise(RMS);
            }

            if(pinkNoise.isSelected()){
                Double RMS = (Double) whiteNoiseRMS.getValue();
                MainFrame.mqttConfig.pinkNoise(RMS);
            }
            if(dc.isSelected()){
                Integer amp = (Integer) dcAmp.getValue();

                MainFrame.mqttConfig.outputDC(amp);
            }
            if (chirp.isSelected()){
                Integer amp = (Integer) chirpAmp.getValue();
                Integer lowFreq = (Integer) chirpLowFreq.getValue();
                Integer highFreq = (Integer) chirpHighFreq.getValue();
                Double percent  = (Double) chirpPercent.getValue();
                Integer period = (Integer) chirpPeriod.getValue();
                MainFrame.mqttConfig.outputChirp(amp, lowFreq, highFreq, percent, period);


            }
            if (sweptSine.isSelected()){
                Integer amp = (Integer) sweptSineAmp.getValue();
                Integer lowFreq = (Integer) sweptSineLowFreq.getValue();
                Integer highFreq = (Integer) sweptSineHighFreq.getValue();
                Integer period = (Integer) sweptSinePeriod.getValue();
                MainFrame.mqttConfig.outputSweptSine(amp, lowFreq, highFreq, period);

            }
        }
        if(e.getSource() == setOutputIndex){
            int index = (int) outputIndex.getValue();
            MainFrame.mqttConfig.setOutputIndex(index);
        }



    }
}
