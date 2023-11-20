package org.example.gui.panels.testpanels;

import org.example.gui.MainFrame;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Command buttons tab
 */
public class CommandPanel extends JPanel implements ActionListener {
    public JButton connect;
    public JButton disconnect;
    public JButton run;
    public JButton pause;
    public JButton cont;
    public JButton stop;

    public JButton startRecord;
    public JButton stopRecord;
    public JButton saveSignals;

    private JPanel generalPanel;
    private JPanel biggerGeneralPanel;

    private JPanel vcsTitle;

    private JPanel biggerVCSPanel;
    private JPanel vcsPanel;
    private JLabel lel;
    public JButton checkOnly;
    public JButton proceed;
    public JButton showPretest;
    public JButton saveHSignal;
    public JButton resetAverage;
    public JButton nextEntry;
    public JButton abortChecksOn;
    public JButton abortChecksOff;
    public JButton closedLoopControlOn;
    public JButton closedLoopControlOff;
    public JButton scheduleClockTimerOn;
    public JButton scheduleClockTimerOff;
    public JTextField rorBoardText;
    public JButton rorBandsOn;
    public JButton rorBandsOff;
    public JTextField sorBoardText;
    public JButton sorTonesOn;
    public JButton sorTonesOff;
    public JButton tonesHoldSweep;
    public JButton tonesReleaseSweep;
    public JButton tonesSweepUp;
    public JButton tonesSweepDown;
    public JButton holdSweep;
    public JButton releaseSweep;
    public JButton sweepUp;
    public JButton sweepDown;
    public JButton levelUp;
    public JButton levelDown;
    public JSpinner levelSetter;
    public JButton setLevel;
    public JButton restoreLevel;
    public JButton increaseSpeed;
    public JButton decreaseSpeed;
    public JSpinner freqSetter;
    public JButton setFrequency;
    public JSpinner phaseSetter;
    public JButton setPhase;
    public JButton inversePulseOn;
    public JButton inversePulseOff;
    public JButton singlePulseOn;
    public JButton singlePulseOff;
    public JButton outputSinglePulse;
    private JLabel dsa;

    private JPanel dsaTitle;

    private JPanel biggerDSAPanel;
    private JPanel dsaPanel;
    public JButton triggerOn;
    public JButton triggerOff;
    public JButton outputOn;
    public JButton outputOff;
    public JButton limitOn;
    public JButton limitOff;





    public CommandPanel(){

        setSize(1200, 1200);

        setLayout(new BoxLayout(this, BoxLayout.PAGE_AXIS));
        biggerGeneralPanel = new JPanel();
        biggerGeneralPanel.setLayout(new BorderLayout());

        generalPanel = new JPanel();
        generalPanel.setLayout(new GridLayout(4,4,20,20));
        generalPanel.setLocation(10,10);


        vcsPanel = new JPanel();
        vcsPanel.setLayout(new GridLayout(5, 5, 10, 20));


        dsaPanel = new JPanel();
        dsaPanel.setLayout(new GridLayout(3, 4, 10, 20));

        connect = new JButton("Connect");
        connect.setFont(new Font("Arial", Font.PLAIN, 10));
        connect.setSize(100, 20);
        connect.setLocation(10, 10);
        generalPanel.add(connect);

        run = new JButton("Run");
        run.setFont(new Font("Arial", Font.PLAIN, 10));
        run.setSize(100, 15);
        generalPanel.add(run);

        disconnect = new JButton("Disconnect");
        disconnect.setFont(new Font("Arial", Font.PLAIN, 10));
        disconnect.setSize(100, 15);

        generalPanel.add(disconnect);

        pause = new JButton("Pause");
        pause.setFont(new Font("Arial", Font.PLAIN, 10));
        pause.setSize(100,15);
        generalPanel.add(pause);

        cont = new JButton("Continue");
        cont.setFont(new Font("Arial", Font.PLAIN, 10));
        cont.setSize(100,15);
        generalPanel.add(cont);

        stop = new JButton("Stop");
        stop.setFont(new Font("Arial", Font.PLAIN, 10));
        stop.setSize(100,15);
        generalPanel.add(stop);

        startRecord = new JButton("Start Record");
        startRecord.setFont(new Font("Arial", Font.PLAIN, 10));
        startRecord.setSize(100,15);
        generalPanel.add(startRecord);

        stopRecord = new JButton("Stop Record");
        stopRecord.setFont(new Font("Arial", Font.PLAIN, 10));
        stopRecord.setSize(100,15);
        generalPanel.add(stopRecord);

        saveSignals = new JButton("Save Signals");
        saveSignals.setFont(new Font("Arial", Font.PLAIN, 10));
        saveSignals.setSize(100,15);
        generalPanel.add(saveSignals);

        biggerGeneralPanel.add(generalPanel, BorderLayout.CENTER);
        add(biggerGeneralPanel);


        biggerVCSPanel = new JPanel();
        biggerVCSPanel.setLayout(new BorderLayout());
        lel = new JLabel("VCS Commands");
        lel.setFont(new Font("Arial", Font.PLAIN, 18));
        biggerVCSPanel.add(lel, BorderLayout.PAGE_START);


        checkOnly = new JButton("Check Only");
        checkOnly.setFont(new Font("Arial", Font.PLAIN, 10));
        checkOnly.setSize(100,15);
        checkOnly.addActionListener(this);
        vcsPanel.add(checkOnly);


        proceed = new JButton("Proceed");
        proceed.setFont(new Font("Arial", Font.PLAIN, 10));
        proceed.setSize(100,15);
        proceed.addActionListener(this);
        vcsPanel.add(proceed);

        showPretest = new JButton("Show Pretest");
        showPretest.setFont(new Font("Arial", Font.PLAIN, 10));
        showPretest.setSize(100,15);
        showPretest.addActionListener(this);
        vcsPanel.add( showPretest);

        saveHSignal = new JButton("Save H Signal");
        saveHSignal.setFont(new Font("Arial", Font.PLAIN, 10));
        saveHSignal.setSize(100,15);
        saveHSignal.addActionListener(this);
        vcsPanel.add( saveHSignal);

        resetAverage = new JButton("Reset Average");
        resetAverage.setFont(new Font("Arial", Font.PLAIN, 10));
        resetAverage.setSize(100,15);
        resetAverage.addActionListener(this);
        vcsPanel.add( resetAverage);

        nextEntry = new JButton("Next Entry");
        nextEntry.setFont(new Font("Arial", Font.PLAIN, 10));
        nextEntry.setSize(100,15);
        nextEntry.addActionListener(this);
        vcsPanel.add(nextEntry);

        abortChecksOn = new JButton("Abort Checks On");
        abortChecksOn.setFont(new Font("Arial", Font.PLAIN, 10));
        abortChecksOn.setSize(100,15);
        abortChecksOn.addActionListener(this);
        vcsPanel.add(abortChecksOn);

        abortChecksOff = new JButton("Abort Checks Off");
        abortChecksOff.setFont(new Font("Arial", Font.PLAIN, 10));
        abortChecksOff.setSize(100,15);
        abortChecksOff.addActionListener(this);
        vcsPanel.add(abortChecksOff);

        closedLoopControlOn = new JButton("Closed Loop Control On");
        closedLoopControlOn.setFont(new Font("Arial", Font.PLAIN, 10));
        closedLoopControlOn.setSize(100,15);
        closedLoopControlOn.addActionListener(this);
        vcsPanel.add(closedLoopControlOn);

        closedLoopControlOff = new JButton("Closed Loop Control Off");
        closedLoopControlOff.setFont(new Font("Arial", Font.PLAIN, 10));
        closedLoopControlOff.setSize(100,15);
        closedLoopControlOff.addActionListener(this);
        vcsPanel.add(closedLoopControlOff);

        scheduleClockTimerOn = new JButton("Schedule Clock Timer On");
        scheduleClockTimerOn.setFont(new Font("Arial", Font.PLAIN, 10));
        scheduleClockTimerOn.setSize(100,15);
        scheduleClockTimerOn.addActionListener(this);
        vcsPanel.add(scheduleClockTimerOn);

        scheduleClockTimerOff = new JButton("Schedule Clock Timer Off");
        scheduleClockTimerOff.setFont(new Font("Arial", Font.PLAIN, 10));
        scheduleClockTimerOff.setSize(100,15);
        scheduleClockTimerOff.addActionListener(this);
        vcsPanel.add(scheduleClockTimerOff);

        rorBoardText = new JTextField("0;1;0;1");
        rorBoardText.setFont(new Font("Arial", Font.PLAIN, 10));
        rorBoardText.setSize(60,15);

        vcsPanel.add(rorBoardText);

        rorBandsOn = new JButton("RoR Bands On");
        rorBandsOn.setFont(new Font("Arial", Font.PLAIN, 10));
        rorBandsOn.setSize(100,15);
        rorBandsOn.addActionListener(this);
        vcsPanel.add(rorBandsOn);

        rorBandsOff = new JButton("RoR Bands Off");
        rorBandsOff.setFont(new Font("Arial", Font.PLAIN, 10));
        rorBandsOff.setSize(100,15);
        rorBandsOff.addActionListener(this);
        vcsPanel.add(rorBandsOff);

        sorBoardText = new JTextField("0;1;0;1");
        sorBoardText.setFont(new Font("Arial", Font.PLAIN, 10));
        sorBoardText.setSize(60,15);
        vcsPanel.add(sorBoardText);

        sorTonesOn = new JButton("SoR Tones On");
        sorTonesOn.setFont(new Font("Arial", Font.PLAIN, 10));
        sorTonesOn.setSize(100,15);
        sorTonesOn.addActionListener(this);
        vcsPanel.add(sorTonesOn);

        sorTonesOff = new JButton("Sor Tones Off");
        sorTonesOff.setFont(new Font("Arial", Font.PLAIN, 10));
        sorTonesOff.setSize(100,15);
        sorTonesOff.addActionListener(this);
        vcsPanel.add(sorTonesOff);

        tonesHoldSweep = new JButton("Tones Hold Sweep");
        tonesHoldSweep.setFont(new Font("Arial", Font.PLAIN, 10));
        tonesHoldSweep.setSize(100,15);
        tonesHoldSweep.addActionListener(this);
        vcsPanel.add( tonesHoldSweep);

        tonesReleaseSweep = new JButton("Tones Release Sweep");
        tonesReleaseSweep.setFont(new Font("Arial", Font.PLAIN, 10));
        tonesReleaseSweep.setSize(100,15);
        tonesReleaseSweep.addActionListener(this);
        vcsPanel.add(tonesReleaseSweep);

        tonesSweepUp = new JButton("Tones Sweep Up");
        tonesSweepUp.setFont(new Font("Arial", Font.PLAIN, 10));
        tonesSweepUp.setSize(100,15);
        tonesSweepUp.addActionListener(this);
        vcsPanel.add(tonesSweepUp);

        tonesSweepDown = new JButton("Tones Sweep Down");
        tonesSweepDown.setFont(new Font("Arial", Font.PLAIN, 10));
        tonesSweepDown.setSize(100,15);
        tonesSweepDown.addActionListener(this);
        vcsPanel.add(tonesSweepDown );

        holdSweep = new JButton(" Hold Sweep");
        holdSweep.setFont(new Font("Arial", Font.PLAIN, 10));
        holdSweep.setSize(100,15);
        holdSweep.addActionListener(this);
        vcsPanel.add(holdSweep);

        releaseSweep = new JButton("Release Sweep");
        releaseSweep.setFont(new Font("Arial", Font.PLAIN, 10));
        releaseSweep.setSize(100,15);
        releaseSweep.addActionListener(this);
        vcsPanel.add(releaseSweep);

        sweepUp = new JButton("Sweep Up");
        sweepUp.setFont(new Font("Arial", Font.PLAIN, 10));
        sweepUp.setSize(100,15);
        sweepUp.addActionListener(this);
        vcsPanel.add(sweepUp);

        sweepDown = new JButton("Sweep Down");
        sweepDown.setFont(new Font("Arial", Font.PLAIN, 10));
        sweepDown.setSize(100,15);
        sweepDown.addActionListener(this);
        vcsPanel.add(sweepDown);

        levelUp = new JButton("Level Up");
        levelUp.setFont(new Font("Arial", Font.PLAIN, 10));
        levelUp.setSize(100,15);
        levelUp.addActionListener(this);
        vcsPanel.add(levelUp);

        levelDown = new JButton("Level Down");
        levelDown.setFont(new Font("Arial", Font.PLAIN, 10));
        levelDown.setSize(100,15);
        levelDown.addActionListener(this);
        vcsPanel.add(levelDown);

        SpinnerModel sm = new SpinnerNumberModel(0,0, 100,0.01);
        levelSetter = new JSpinner(sm);
        vcsPanel.add(levelSetter);

        setLevel = new JButton("Set Level");
        setLevel.setFont(new Font("Arial", Font.PLAIN, 10));
        setLevel.setSize(100,15);
        setLevel.addActionListener(this);
        vcsPanel.add(setLevel);

        restoreLevel = new JButton("Restore Level");
        restoreLevel.setFont(new Font("Arial", Font.PLAIN, 10));
        restoreLevel.setSize(100,15);
        restoreLevel.addActionListener(this);
        vcsPanel.add(restoreLevel);

        increaseSpeed = new JButton("Increase Speed");
        increaseSpeed.setFont(new Font("Arial", Font.PLAIN, 10));
        increaseSpeed.setSize(100,15);
        increaseSpeed.addActionListener(this);
        vcsPanel.add(increaseSpeed);

        decreaseSpeed = new JButton("Decrease Speed");
        decreaseSpeed.setFont(new Font("Arial", Font.PLAIN, 10));
        decreaseSpeed.setSize(100,15);
        decreaseSpeed.addActionListener(this);
        vcsPanel.add(decreaseSpeed);

        SpinnerModel sm1 = new SpinnerNumberModel(0,0, 100,1);
        freqSetter = new JSpinner(sm1);
        vcsPanel.add(freqSetter);

        setFrequency = new JButton("Set Frequency");
        setFrequency.setFont(new Font("Arial", Font.PLAIN, 10));
        setFrequency.setSize(100,15);
        setFrequency.addActionListener(this);
        vcsPanel.add(setFrequency);

        SpinnerModel sm2 = new SpinnerNumberModel(0,0, 100,1);
        phaseSetter = new JSpinner(sm2);
        vcsPanel.add(phaseSetter);

        setPhase = new JButton("Set Phase");
        setPhase.setFont(new Font("Arial", Font.PLAIN, 10));
        setPhase.setSize(100,15);
        setPhase.addActionListener(this);
        vcsPanel.add(setPhase);

        inversePulseOn = new JButton("Inverse Pulse On");
        inversePulseOn.setFont(new Font("Arial", Font.PLAIN, 10));
        inversePulseOn.setSize(100,15);
        inversePulseOn.addActionListener(this);
        vcsPanel.add(inversePulseOn);

        inversePulseOff = new JButton("Inverse Pulse Off");
        inversePulseOff.setFont(new Font("Arial", Font.PLAIN, 10));
        inversePulseOff.setSize(100,15);
        inversePulseOff.addActionListener(this);
        vcsPanel.add(inversePulseOff);

        singlePulseOn = new JButton("Single Pulse On");
        singlePulseOn.setFont(new Font("Arial", Font.PLAIN, 10));
        singlePulseOn.setSize(100,15);
        singlePulseOn.addActionListener(this);
        vcsPanel.add(singlePulseOn);

        singlePulseOff = new JButton("Single Pulse Off");
        singlePulseOff.setFont(new Font("Arial", Font.PLAIN, 10));
        singlePulseOff.setSize(100,15);
        singlePulseOff.addActionListener(this);
        vcsPanel.add(singlePulseOff);

        outputSinglePulse = new JButton("Output Single Pulse");
        outputSinglePulse.setFont(new Font("Arial", Font.PLAIN, 10));
        outputSinglePulse.setSize(100,15);
        outputSinglePulse.addActionListener(this);
        vcsPanel.add( outputSinglePulse);

        biggerVCSPanel.add(vcsPanel, BorderLayout.CENTER);
        add(biggerVCSPanel);


        biggerDSAPanel = new JPanel();
        biggerDSAPanel.setLayout(new BorderLayout());
        dsa = new JLabel("DSA Commands");
        dsa.setFont(new Font("Arial", Font.PLAIN, 18));
        biggerDSAPanel.add(dsa, BorderLayout.PAGE_START);


        triggerOn = new JButton("Trigger On");
        triggerOn.setFont(new Font("Arial", Font.PLAIN, 10));
        triggerOn.setSize(100,15);
        triggerOn.addActionListener(this);
        dsaPanel.add(triggerOn);

        triggerOff = new JButton("Trigger Off");
        triggerOff.setFont(new Font("Arial", Font.PLAIN, 10));
        triggerOff.setSize(100,15);
        triggerOff.addActionListener(this);
        dsaPanel.add(triggerOff);
        dsaPanel.add(new JLabel(""));

        outputOn = new JButton("Output On");
        outputOn.setFont(new Font("Arial", Font.PLAIN, 10));
        outputOn.setSize(100,15);
        outputOn.addActionListener(this);
        dsaPanel.add(outputOn);

        outputOff = new JButton("Output Off");
        outputOff.setFont(new Font("Arial", Font.PLAIN, 10));
        outputOff.setSize(100,15);
        outputOff.addActionListener(this);
        dsaPanel.add(outputOff);
        dsaPanel.add(new JLabel(""));

        limitOn = new JButton("Limit On");
        limitOn.setFont(new Font("Arial", Font.PLAIN, 10));
        limitOn.setSize(100,15);
        limitOn.addActionListener(this);
        dsaPanel.add(limitOn);

        limitOff = new JButton("Limit Off");
        limitOff.setFont(new Font("Arial", Font.PLAIN, 10));
        limitOff.setSize(100,15);
        limitOff.addActionListener(this);
        dsaPanel.add(limitOff);
        dsaPanel.add(new JLabel(""));

        biggerDSAPanel.add(dsaPanel, BorderLayout.CENTER);
        add(biggerDSAPanel);


    }


    @Override
    public void actionPerformed(ActionEvent e) {
        if(e.getSource() == checkOnly) MainFrame.mqttConfig.checkOnly();
        if(e.getSource() == proceed) MainFrame.mqttConfig.proceedVCS();
        if(e.getSource() == showPretest) MainFrame.mqttConfig.showPretest();
        if(e.getSource() == saveHSignal) MainFrame.mqttConfig.saveSignals();
        if(e.getSource() == resetAverage) MainFrame.mqttConfig.resetAverage();
        if(e.getSource() == nextEntry) MainFrame.mqttConfig.nextEntry();
        if(e.getSource() == abortChecksOn) MainFrame.mqttConfig.abortChecksOn();
        if(e.getSource() == abortChecksOff) MainFrame.mqttConfig.abortChecksOff();
        if(e.getSource() == closedLoopControlOn) MainFrame.mqttConfig.closedLoopControlOn();
        if(e.getSource() == closedLoopControlOff) MainFrame.mqttConfig.closedLoopControlOff();
        if(e.getSource() == scheduleClockTimerOn) MainFrame.mqttConfig.scheduleClockTimerOn();
        if(e.getSource() == scheduleClockTimerOff) MainFrame.mqttConfig.scheduleClockTimerOff();
        if(e.getSource() == rorBandsOn) MainFrame.mqttConfig.rorBandsOn(rorBoardText.getText());
        if(e.getSource() == rorBandsOff) MainFrame.mqttConfig.rorBandsOff();
        if(e.getSource() == sorTonesOn) MainFrame.mqttConfig.sorTonesOn(sorBoardText.getText());
        if(e.getSource() == sorTonesOff) MainFrame.mqttConfig.sorTonesOff();
        if(e.getSource() == tonesHoldSweep) MainFrame.mqttConfig.sorTonesHoldSweep();
        if(e.getSource() == tonesReleaseSweep) MainFrame.mqttConfig.sorTonesReleaseSweep();
        if(e.getSource() == tonesSweepUp) MainFrame.mqttConfig.sorTonesSweepUp();
        if(e.getSource() == tonesSweepDown) MainFrame.mqttConfig.sorTonesSweepDown();
        if(e.getSource() == sweepUp) MainFrame.mqttConfig.sweepUp();
        if(e.getSource() == sweepDown) MainFrame.mqttConfig.sweepDown();
        if(e.getSource() == holdSweep) MainFrame.mqttConfig.holdSweep();
        if(e.getSource() == releaseSweep) MainFrame.mqttConfig.releaseSweep();
        if(e.getSource() == levelUp) MainFrame.mqttConfig.levelUp();
        if(e.getSource() == levelDown) MainFrame.mqttConfig.levelDown();
        if(e.getSource() == setLevel) MainFrame.mqttConfig.setLevel((Double) levelSetter.getValue());
        if(e.getSource() == restoreLevel) MainFrame.mqttConfig.restoreLevel();
        if(e.getSource() == increaseSpeed) MainFrame.mqttConfig.increaseSpeed();
        if(e.getSource() == decreaseSpeed) MainFrame.mqttConfig.decreaseSpeed();
        if(e.getSource() == setFrequency) MainFrame.mqttConfig.setFrequency((Integer) freqSetter.getValue());
        if(e.getSource() == setPhase) MainFrame.mqttConfig.setPhase((Integer) phaseSetter.getValue());
        if(e.getSource() == inversePulseOn) MainFrame.mqttConfig.inversePulseOn();
        if(e.getSource() == inversePulseOff) MainFrame.mqttConfig.inversePulseOff();
        if(e.getSource() == singlePulseOn) MainFrame.mqttConfig.singlePulseOn();
        if(e.getSource() == singlePulseOff) MainFrame.mqttConfig.singlePulseOff();
        if(e.getSource() == outputSinglePulse) MainFrame.mqttConfig.outputSinglePulse();

        /* DSA Commands */
        if(e.getSource() == triggerOn) MainFrame.mqttConfig.triggerOn();
        if(e.getSource() == triggerOff) MainFrame.mqttConfig.triggerOff();
        if(e.getSource() == outputOn) MainFrame.mqttConfig.outputOn();
        if(e.getSource() == outputOff) MainFrame.mqttConfig.outputOff();
        if(e.getSource() == limitOn) MainFrame.mqttConfig.limitOn();
        if(e.getSource() == limitOff) MainFrame.mqttConfig.limitOff();


    }
}
