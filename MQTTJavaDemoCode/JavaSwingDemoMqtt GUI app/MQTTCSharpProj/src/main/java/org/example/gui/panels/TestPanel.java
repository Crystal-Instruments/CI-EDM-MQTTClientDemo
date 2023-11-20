package org.example.gui.panels;

import org.example.gui.panels.testpanels.*;

import javax.swing.*;
import java.awt.*;

/**
 * Test Panel that contains other tabs hence the tabbed pane.
 */
public class TestPanel extends JPanel{
    public JTabbedPane pane;

    public TestPanel(){

        setPreferredSize(new Dimension(1400,1400));
        setLayout(new GridLayout(1,1));
        setLocation(10, 10);
        pane = new JTabbedPane();
        pane.setSize(1300, 1300);
        pane.add("Command", new CommandPanel());
        pane.add("Status", new StatussPanel());
        pane.add("Detail Status", new DetailStatusPanel());
        ChannelsPanel cp= new ChannelsPanel();
        pane.add("Channels", cp.sp);
        ShakerPanel pp = new ShakerPanel();
        pane.add("Shaker", pp.sp);
        pane.add("List/Create/Load/Delete", new TestOptionsPanel());
        pane.add("Advanced Commands", new AdvancedCommandsPanel());
        pane.add("Output", new OutputPanel());
        add(pane);
        setVisible(true);

    }
}
