package org.example.utils;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.data.xy.XYDataset;
import org.jfree.data.xy.XYSeries;
import org.jfree.ui.ApplicationFrame;
import org.jfree.ui.RefineryUtilities;
import org.jfree.chart.plot.XYPlot;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.xy.XYSeriesCollection;
import org.jfree.chart.renderer.xy.XYLineAndShapeRenderer;

import java.awt.*;
import java.util.ArrayList;

public class XYChartConfig extends ApplicationFrame{
    public void setXylineChart(JFreeChart xylineChart) {
        this.xylineChart = xylineChart;
    }

    private JFreeChart xylineChart;

    public void setXAxis(String label){
        //xylineChart.set
    }
    public XYChartConfig(String applicationTitle, String chartTitle, ArrayList<ArrayList<Double>> s) {
        super(applicationTitle);
        xylineChart = ChartFactory.createXYLineChart(
                chartTitle ,
                "Category" ,
                "Score" ,
                createDataset(s) ,
                PlotOrientation.VERTICAL ,
                true , true , false);

        ChartPanel chartPanel = new ChartPanel( xylineChart );
        chartPanel.setPreferredSize( new java.awt.Dimension( 560 , 367 ) );
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
    /*
    This is so a new window isn't created during every loop
     */
    public void resetEverything(){
        ChartPanel chartPanel = new ChartPanel( xylineChart );
        chartPanel.setPreferredSize( new java.awt.Dimension( 560 , 367 ) );
        final XYPlot plot = xylineChart.getXYPlot( );

        XYLineAndShapeRenderer renderer = new XYLineAndShapeRenderer( );
        renderer.setSeriesPaint( 0 , Color.BLUE );
        renderer.setSeriesPaint( 1 , Color.GREEN );
        renderer.setSeriesPaint( 2 , Color.YELLOW );
        renderer.setSeriesStroke( 0 , new BasicStroke( 2.0f ) );
        renderer.setSeriesStroke( 1 , new BasicStroke( 3.0f ) );
        renderer.setSeriesStroke( 2 , new BasicStroke( 2.0f ) );
        renderer.setSeriesShapesVisible(0, false);
        plot.setRenderer( renderer );
        setContentPane( chartPanel );

    }


    public XYDataset createDataset( ArrayList<ArrayList<Double>> s) {
        final XYSeries firefox = new XYSeries( "Dataset" );
        if(!s.isEmpty()) {
            for (int i = 0; i < s.get(0).size(); ++i) {
                firefox.add(s.get(0).get(i), s.get(1).get(i));
            }
        }


        final XYSeriesCollection dataset = new XYSeriesCollection( );
        dataset.addSeries( firefox );
//        dataset.addSeries( chrome );
//        dataset.addSeries( iexplorer );
        return dataset;
    }
}
