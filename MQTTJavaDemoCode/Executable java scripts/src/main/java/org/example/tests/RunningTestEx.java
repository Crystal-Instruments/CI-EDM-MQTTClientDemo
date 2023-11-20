package org.example.tests;

import com.fasterxml.jackson.core.type.TypeReference;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.eclipse.paho.client.mqttv3.MqttException;
import org.example.config.MqttConfig;
import org.example.messages.*;
import org.example.utils.MqttResponse;
import org.example.utils.XYChartConfig;
import org.json.JSONArray;
import org.json.JSONObject;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.ui.RefineryUtilities;


import java.io.File;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;

public class RunningTestEx {

    public static void runTest() throws MqttException, IOException, InterruptedException {
        XYChartConfig chart = new XYChartConfig("Chart Data",
                "Chart Data", new ArrayList<>());

        MqttConfig mqttConfig = new MqttConfig(false, "192.168.1.15");
        String prefix= mqttConfig.getPrefix();

        ThreadPoolExecutor executor = (ThreadPoolExecutor) Executors.newFixedThreadPool(2);

        Thread.sleep(2000);
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd HH-mm-ss");
        LocalDateTime now = LocalDateTime.now();
        String dateString = dtf.format(now);

        mqttConfig.connect();
        mqttConfig.run();

        Runnable runnable = ()->{
            int count =0;

            String testStatus = "";
            String softwareMode = "";
            String serialNumber = "";
            String deviceType = "";
            boolean initHm = mqttConfig.isInitHm();

            String savedDirectory = "";
            ArrayList<List<Double>> signalFrame = new ArrayList<>();
            boolean firstStop = true;
            boolean directoryMade = false;

            try {
                while (!testStatus.equals("Stopped")) {
                    mqttConfig.getChannelData(1);
                    Thread.sleep(10);
                    MqttResponse mqttResponse;
                    String topic;
                    String msg;

                    mqttResponse = mqttConfig.queue.take();

                    topic = mqttResponse.getTopic();

                    msg = new String(mqttResponse.getMessage().getPayload());
                    ObjectMapper mapper = new ObjectMapper();

                    if(!softwareMode.isEmpty() && !serialNumber.isEmpty() && !deviceType.isEmpty() && savedDirectory.isEmpty()){
                        savedDirectory = softwareMode+ "-" + deviceType + "-" + serialNumber +"-" + dateString;
                        System.out.println(savedDirectory);
                        if(!directoryMade) {
                            File f = new File("src\\main\\resources\\" + savedDirectory);
                            boolean created = f.mkdir();
                            if (created) System.out.println("Directory successfully created");
                            else System.out.println("Directory cannot be created or already exists");
                            directoryMade = true;
                        }
                    }

                    if (topic.equals(prefix.concat("/App/Test/Status"))) {
                        MqttTestStatus mqttTestStatus = mapper.readValue(msg, MqttTestStatus.class);

                        testStatus = mqttTestStatus.Status;
                        if(testStatus.equals("Stopped") && firstStop){
                            firstStop = false;
                            testStatus = "";
                        }
                        else if(testStatus.equals("Stopped")) testStatus = "Stopped";
                    }

                    if (topic.equals(prefix.concat("/App/Status"))) {
                        System.out.println(msg);
                        AppStatus appStatus = mapper.readValue(msg, AppStatus.class);
                        softwareMode = appStatus.SoftwareMode;

                    }

                    if (topic.equals(prefix.concat("/VCS/Test/Stage"))) {
                        mapper = new ObjectMapper();
                        VCSTestStage vcsTestStage = mapper.readValue(msg, VCSTestStage.class);
                        if (vcsTestStage.Stage.equals("Pre_DisplayFinished"))
                            mqttConfig.proceed();
                    }

                    if (topic.equals(prefix.concat("/App/System"))) {
                        JSONObject obj = new JSONObject(msg);
                        JSONArray arr = obj.getJSONArray("Modules");
                        String arrStr = arr.toString();
                        List<MqttDeviceModule> lists = mapper.readValue(arrStr, new TypeReference<List<MqttDeviceModule>>(){});
                        serialNumber = lists.get(0).SerialNumber;
                        deviceType = lists.get(0).DeviceType;
                    }

                    if(mqttConfig.signalDataHashMap.containsKey(prefix.concat("/App/Test/SignalData"))){ //(topic.equals(prefix.concat("/App/Test/SignalData"))){
                        if(!initHm) {
                            SignalData signalData = mqttConfig.signalDataHashMap.get(prefix.concat("/App/Test/SignalData"));
                            Signals signal = signalData.Signal;
                            //mqttConfig.setBlockSize();
//                            JSONArray jsonArray = new JSONArray(msg);
//
//                            JSONObject jsonObject = (JSONObject) jsonArray.get(0);
//
//                            Signals signal = mapper.readValue(jsonObject.getJSONObject("Signal").toString(), Signals.class);
                            mqttConfig.setBlockSize(signal.BlockSize);
                            mqttConfig.setSampleRate(signal.SamplingRate);
                            mqttConfig.setFreqRange((float) (signal.SamplingRate*0.44));
                            mqttConfig.setFreqResolution(signal.SamplingRate/ signal.BlockSize/2);
                            ArrayList<Float> freqs = new ArrayList<>();
                            for(int i =0; i< signal.BlockSize; ++i)freqs.add(i* mqttConfig.getFreqResolution());
                            mqttConfig.setFreqs(freqs);
                            mqttConfig.setInitHm(true);

                        }
//                        JSONArray jsonArray = new JSONArray(msg);
//                        JSONObject obj = (JSONObject) jsonArray.get(0);

                        SignalData signalData = mqttConfig.signalDataHashMap.get(prefix.concat("/App/Test/SignalData"));
                        Signals signal = signalData.Signal;

                       // Signals signal = mapper.readValue(obj.getJSONObject("Signal").toString(), Signals.class);
                        String signalName = signal.Name;
                        String signalUnitX = signal.UnitX;
                        String signalUnitY = signal.UnitY;

                        ArrayList<Double> xArray = signalData.ValueX;
                        ArrayList<Double> yArray = signalData.ValueY;
//                        JSONArray arr = obj.getJSONArray("ValueX");
//                        String arrStr = arr.toString();
//                        List<Double> xArray =  mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
//                        arr = obj.getJSONArray("ValueY");
//                        arrStr = arr.toString();
//                        List<Double> yArray = mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                        signalFrame.add(xArray);
                        signalFrame.add(yArray);

                        ArrayList<Double> plot = new ArrayList<>();
                        for(int i =0; i< signalFrame.get(0).size(); ++i){
                            plot.add(signalFrame.get(0).get(i) - signalFrame.get(0).get(0));
                        }
                        ArrayList<ArrayList<Double>> finalSignalFrame = new ArrayList<>();
                        finalSignalFrame.add(plot);
                        finalSignalFrame.add((ArrayList<Double>) signalFrame.get(1));

                        /*
                        Printing and saving to files commented out for now.
                         */
//                        String columnLabelString = "X Values || Y Values || Z Value";
//                        System.out.println();
//                        for(int i =0; i< columnLabelString.length()/4; ++i) System.out.print(" ");
//                        System.out.print("Signal Frame Data\n");
//                        for(int i =0; i<columnLabelString.length(); ++i) System.out.print("-");
//                        System.out.println(columnLabelString);
//
//                        int nSpace1 = 5;
//                        int nSpace2 = 11;
//                      //  int nSpace3 = 13;
//
//                        for(int i =0; i<signalFrame.get(0).size()/4; ++i){
//                            for(int j =0; j< nSpace1; ++j) System.out.print(signalFrame.get(0).get(i));
//                            for(int j =0; j< nSpace2; ++j) System.out.print(signalFrame.get(1).get(i));
//                            //for(int j =0; j< nSpace3; ++j) System.out.print(signalFrame.get(0).get(i));
//
//                        }
//                        //File file = new File(savedDirectory + "\\fullSignalFrame" + count);
//                        FileWriter fileWriter = new FileWriter("src\\main\\resources\\" +savedDirectory+ "\\fullSignalFrame" + count);
//                        fileWriter.write(signalFrame.toString());
//
//                        FileWriter fileWriter1 = new FileWriter("src\\main\\resources\\" +savedDirectory + "\\X"+count);
//                        fileWriter1.write(signalFrame.get(0).toString());
//
//                        FileWriter fileWriter2 = new FileWriter("src\\main\\resources\\" +savedDirectory + "\\Y"+count);
//                        fileWriter2.write(signalFrame.get(1).toString());

                        try {
                            Thread.sleep(100);
                        } catch (InterruptedException e) {
                            throw new RuntimeException(e);
                        }
                        JFreeChart updatedChart = ChartFactory.createXYLineChart(
                                "Signal frame data of " + signalName ,
                                signalUnitX ,
                                signalUnitY ,
                                chart.createDataset(finalSignalFrame) ,
                                PlotOrientation.VERTICAL ,
                                true , true , false);
                        chart.setXylineChart(updatedChart);
                        chart.resetEverything();
                        chart.pack( );
                        RefineryUtilities.centerFrameOnScreen(chart);
                        chart.setVisible( true );

                        ++count;
                        signalFrame = new ArrayList<>();
                    }
                }
            }
            catch (InterruptedException | IOException e) {
                throw new RuntimeException(e);
            }
        };
        executor.execute(runnable);
    }
}
