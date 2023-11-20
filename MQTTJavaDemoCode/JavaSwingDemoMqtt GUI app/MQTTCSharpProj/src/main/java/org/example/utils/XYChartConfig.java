package org.example.utils;

import org.example.messages.MqttSignalFrameData;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.chart.plot.XYPlot;
import org.jfree.chart.renderer.xy.XYLineAndShapeRenderer;
import org.jfree.data.xy.XYDataset;
import org.jfree.data.xy.XYSeries;
import org.jfree.data.xy.XYSeriesCollection;
import org.jfree.ui.ApplicationFrame;

import java.awt.*;
import java.util.ArrayList;

public class XYChartConfig extends ApplicationFrame{

    private JFreeChart xylineChart;

    public XYChartConfig(String applicationTitle, String chartTitle, ArrayList<MqttSignalFrameData> s) {
        super(applicationTitle);
        xylineChart = ChartFactory.createXYLineChart(
                chartTitle ,
                "Category" ,
                "Score" ,
                createDataset(s) ,
                PlotOrientation.VERTICAL ,
                true , true , false);

        ChartPanel chartPanel = new ChartPanel( xylineChart );
        chartPanel.setPreferredSize( new Dimension( 560 , 367 ) );
        final XYPlot plot = xylineChart.getXYPlot( );

        XYLineAndShapeRenderer renderer = new XYLineAndShapeRenderer( );
        renderer.setSeriesPaint( 0 , Color.RED );
        renderer.setSeriesPaint( 1 , Color.GREEN );
        renderer.setSeriesPaint( 2 , Color.YELLOW );
        renderer.setSeriesStroke( 0 , new BasicStroke( 4.0f ) );
        renderer.setSeriesStroke( 1 , new BasicStroke( 3.0f ) );
        renderer.setSeriesStroke( 2 , new BasicStroke( 2.0f ) );
        plot.setRenderer( renderer );
        setContentPane( chartPanel );
    }

    public XYDataset createDataset(ArrayList<MqttSignalFrameData> data) {
        final XYSeriesCollection dataset = new XYSeriesCollection();
        for(MqttSignalFrameData d: data){
            XYSeries dt = new XYSeries(d.Signal.Name);
            for(int i =0; i< d.ValueX.size(); ++i){
                dt.add(d.ValueX.get(i)-d.ValueZ.get(0), d.ValueY.get(i));
            }
            dataset.addSeries(dt);
        }

        return dataset;
    }

}
