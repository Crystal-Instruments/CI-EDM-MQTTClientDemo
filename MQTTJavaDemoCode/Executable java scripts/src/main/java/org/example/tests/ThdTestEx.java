package org.example.tests;
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.github.sh0nk.matplotlib4j.Plot;
import com.github.sh0nk.matplotlib4j.PythonExecutionException;
import org.eclipse.paho.client.mqttv3.MqttException;
import org.example.config.MqttConfig;
import org.example.messages.AppStatus;
import org.example.messages.MqttDeviceModule;
import org.example.messages.MqttTestStatus;
import org.example.messages.VCSTestStage;
import org.example.utils.MqttResponse;
import org.example.utils.XYChartConfig;
import org.jfree.chart.ChartFactory;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.File;
import java.io.IOException;
import java.lang.reflect.Array;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.concurrent.Executors;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.atomic.AtomicReference;
import java.util.stream.Stream;

public class ThdTestEx {
    public static double computeTHD(ArrayList<Float> x ){
        ArrayList<Float> y = new ArrayList<>();
        for (Float aFloat : x) y.add(aFloat - x.get(0));
        ArrayList<Float>g = new ArrayList<>();
        for(int i =0; i< y.size(); ++i) g.add((float) Math.pow(10,(Math.floor(y.get(i)/20))));
        int res = 0;
        for(int i =1; i<g.size(); ++i) res+= Math.pow(g.get(i), 2);
        //double r = Math.sqrt(res);
        return 20* Math.log10(Math.sqrt(res));

    }
    public static void runTest() throws MqttException, IOException, InterruptedException, PythonExecutionException {
        MqttConfig mqttConfig = new MqttConfig(false, "192.168.1.15");
        //MqttClient client = mqttConfig.getSubClient();

        String prefix = mqttConfig.getPrefix();



        Thread.sleep(2000);

        /*
        Define ranges for frequencies and amplitudes as list
         */
        List<Integer> freqs = Stream.of(1, 2, 3)
                .map(x -> x * 1000)
                .toList();
        List<Double> amps = Stream.of(1,2 ,3)
                .map(x -> (double) (x * 0.1))
                .toList();
        /*
        or define custom ranges
         */
        int freqStep = 250;
        int minFreq = 1000;
        int maxFreq = 10000;

        /*
        low frequencies need larger block size - also low frequency noise affects spec
         */
//        freqs = np.concatenate(([50,100,200], freqs))

        /*

Get date to use it for folder name
    */
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd HH-mm-ss");
        LocalDateTime now = LocalDateTime.now();
        String dateString = dtf.format(now);



        ThreadPoolExecutor executor = (ThreadPoolExecutor) Executors.newFixedThreadPool(3);
        String testStatus = "";
        AtomicReference<String> softwareMode = new AtomicReference<>("");
        AtomicReference<String> serialNumber = new AtomicReference<>("");
        AtomicReference<String> deviceType = new AtomicReference<>("");


        AtomicReference<String> savedDirectory = new AtomicReference<>("");



        Runnable getDirInfo = ()->{
            boolean directoryMade = false;
            try {
                while (!directoryMade) {
                    MqttResponse mqttResponse;
                    String topic;
                    String msg;

                    mqttResponse = mqttConfig.queue.take();

                    topic = mqttResponse.getTopic();

                    msg = new String(mqttResponse.getMessage().getPayload());
                    ObjectMapper mapper = new ObjectMapper();
                    if (!softwareMode.get().isEmpty() && !serialNumber.get().isEmpty() && !deviceType.get().isEmpty() && savedDirectory.get().isEmpty()) {
                        savedDirectory.set(softwareMode + "-" + deviceType + "-" + serialNumber + "-" + dateString);
                        System.out.println(savedDirectory.get());
                        if (!directoryMade) {
                            File f = new File("src\\main\\resources\\" + savedDirectory);
                            boolean created = f.mkdir();
                            if (created) System.out.println("Directory successfully created");
                            else System.out.println("Directory cannot be created or already exists");
                            directoryMade = true;
                        }
                    }
                    if (topic.equals(prefix.concat("/App/Status"))) {
                        System.out.println(msg);
                        AppStatus appStatus = mapper.readValue(msg, AppStatus.class);
                        softwareMode.set(appStatus.SoftwareMode);

                    }
                    if (topic.equals(prefix.concat("/App/System"))) {
                        JSONObject obj = new JSONObject(msg);
                        JSONArray arr = obj.getJSONArray("Modules");
                        String arrStr = arr.toString();
                        List<MqttDeviceModule> lists = mapper.readValue(arrStr, new TypeReference<List<MqttDeviceModule>>() {
                        });
                        serialNumber.set(lists.get(0).SerialNumber);
                        deviceType.set(lists.get(0).DeviceType);

                    }

                }
            } catch (InterruptedException | JsonProcessingException e) {
                throw new RuntimeException(e);
            }
        };
        executor.execute(getDirInfo);


            int count = 0;
//
//            String testStatus = "";
//            String softwareMode = "";
//            String serialNumber = "";
//            String deviceType = "";
//            //boolean initHm = mqttConfig.isInitHm();
//
//            String savedDirectory = "";
            boolean firstStop = true;
            boolean directoryMade = false;
            int timeToComplete = 15*freqs.size()* amps.size();
            if(timeToComplete >60){
                int tm = timeToComplete/3600;
                if(timeToComplete/60>60) System.out.println("Estimate of time required to complete: " + tm + " hours");
                int min = timeToComplete/60;
                System.out.println("Estimate of time required to complete: " + min + " minutes");

            }
            else System.out.println("Estimate of time required to complete: " + timeToComplete + " seconds");


            int numHarmonics = 25;
            String suffix = "";
            if(numHarmonics == 2){
                suffix = "nd";
            }else if(numHarmonics == 3){
                suffix = "rd";
            }else{
                suffix = "th";
            }
            Scanner myObj = new Scanner(System.in);
            System.out.println("Press enter to begin THD measurement up to "+ numHarmonics + suffix + " harmonic");
            String nextLine = myObj.nextLine();
            if(!nextLine.isEmpty())
                System.exit(0);

           // System.out.println("THD measurement for "+ deviceType + "-" + serialNumber + "has started");
            mqttConfig.connect();
            mqttConfig.run();

            try {
                Thread.sleep(2000);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            mqttConfig.outputToggle("on");
            ArrayList<ArrayList<Double>> thd = new ArrayList<>();



//            Runnable proceedTest = ()->{
              boolean found = false;
              try {
                  while (!found) {
                      MqttResponse mqttResponse;
                      String topic;
                      String msg;

                      mqttResponse = mqttConfig.queue.take();

                      topic = mqttResponse.getTopic();

                      msg = new String(mqttResponse.getMessage().getPayload());
                      ObjectMapper mapper = new ObjectMapper();
                      if (topic.equals(prefix.concat("/VCS/Test/Stage"))) {
                          VCSTestStage vcsTestStage = mapper.readValue(msg, VCSTestStage.class);
                          //System.out.println(vcsTestStage.toString());
                          if (vcsTestStage.Stage.equals("Pre_DisplayFinished")) {
                              System.out.println("donezo");
                              mqttConfig.proceedVCS();
                              found = true;
                          }
                      }

                  }
              } catch (InterruptedException | JsonProcessingException e) {
                  throw new RuntimeException(e);
              }
//            };
            /*
            comment this bottom part out if not VCS. this THD test is mostly for VCS though
             */


        //executor.execute(proceedTest);
       // Runnable runnable = ()-> {
//
//        JFrame f = new JFrame("ProgressBar");
//
//        // create a panel
//        JPanel p = new JPanel();
//
//        // create a progressbar
//        JProgressBar b = new JProgressBar();
//
//
//        // set initial value
//        int barValue = 0;
//        b.setValue(barValue);
//
//
//        b.setStringPainted(true);
//
//        // add progressbar
//        p.add(b);
//
//        // add panel
//        f.add(p);
//
//        // set the size of the frame
//        f.setSize(500, 500);
//        f.setVisible(true);
            try {
                    Thread.sleep(10);
                    MqttResponse mqttResponse;
                    String msg;


                    ObjectMapper mapper = new ObjectMapper();

                    for(Integer freq: freqs){

                        System.out.println();
                        for(Double amp: amps){
                            System.out.println(amp + " Volts at " + freq + " Hz");
                            mqttConfig.outputSine(amp, freq);
                            Thread.sleep(5000);
                            mqttConfig.resetAverage();
                            Thread.sleep(5000);
                            //After inner  loop has settled/paused, get APS
                            mqttConfig.getAPS(1); //Publisher message
                                //Need another sleep between  requesting message and receiving
                            Thread.sleep(5000);

                            mqttResponse = mqttConfig.signalDataQueue.take();

                            msg = new String(mqttResponse.getMessage().getPayload());


                            JSONArray jsonArray = new JSONArray(msg);
                            JSONObject obj = (JSONObject) jsonArray.get(0);

                            JSONArray arr = obj.getJSONArray("ValueY");
                            String arrStr = arr.toString();
                            List<Float> yArray = mapper.readValue(arrStr, new TypeReference<List<Float>>(){});

                            ArrayList<Float> harms = new ArrayList<>();
                            for(int harmonic = 0; harmonic < Math.min(numHarmonics, mqttConfig.getFreqRange()/freq); ++harmonic){
                                int i  = Math.round(freq/mqttConfig.getFreqResolution())*(harmonic+1);
                                Float x = yArray.get(i);
                                harms.add(x);
                            }
                            ArrayList<Double> db = new ArrayList<>();
                            db.add((double)freq);
                            db.add(amp);
                            db.add(computeTHD(harms));
                           // synchronized(thd) {
                                thd.add(db);
                            //}
                                //thd.add(Arrays.asList(freq, amp, computeTHD(harms)));





                            }

//                        b.setValue((++barValue/freqs.size())*100);
//                        int finalBarValue = (barValue/freqs.size())*100;
//                        Runnable progBar  = ()-> {
//                            SwingUtilities.invokeLater(new Runnable() {
//                                public void run() {
//                                    b.setValue(finalBarValue);
//                                }
//                            });
//                        };
//                        executor.execute(progBar);

                        }



                //}

            } catch (InterruptedException | JsonProcessingException e) {
                throw new RuntimeException(e);
            }

        //};

        //executor.execute(runnable);
        String columnLabelString = "Frequency (Hz) || Amplitude (Volts) || THD (db)";
        System.out.println();
        for(int i =0; i< columnLabelString.length()/4; ++i) System.out.print(" ");
        System.out.println("THD Measurement Results");
        for(int i =0; i< columnLabelString.length(); ++i) System.out.print(" ");
        System.out.println(columnLabelString);

        int nspace1 = 5;
        int nspace2 = 11;
        int nspace3 = 13;

        for(ArrayList<Double> a : thd){
            for(int i=0; i<nspace1; ++i)System.out.print(" ");
            System.out.print(a.get(0));
            String len = a.get(0).toString();
            for(int i =0; i< nspace2 + 3 - len.length(); ++i) System.out.print(" ");
            System.out.print(a.get(1));
            len = a.get(1).toString();
            for(int i =0; i< nspace3 + 1 - len.length(); ++i) System.out.print(" ");
            System.out.printf("%.2f",a.get(2));
            System.out.println();

        }
        XYChartConfig chart = new XYChartConfig("Chart Data",
                "Chart Data", new ArrayList<>());

        ArrayList<Double> freqsArr = new ArrayList<>();
        ArrayList<Double> dbthd = new ArrayList<>();
        ArrayList<Double> inputAmp = new ArrayList<>();
        Plot plt = Plot.create();
        int numAmps = amps.size();
        for(int i =0; i<numAmps; ++i){
            for(int j = i; j<thd.get(0).size(); j+=numAmps) freqsArr.add(thd.get(0).get(j));
            for(int j = i; j<thd.get(2).size(); j+=numAmps) dbthd.add(thd.get(2).get(j));
            for(int j = i; j<thd.get(1).size(); j+=numAmps) inputAmp.add(thd.get(1).get(j));
            plt.plot()
                    .add(freqsArr, dbthd, "r")
                    .linestyle("--");;
            plt.title("THD vs. Frequency and input amplitudes");
            plt.xlabel("Frequency (Hz)");
            plt.ylabel("THD (db)");
            //plt.savefig("src\\main\\resources\\" + savedDirectory+ "\\thdplot");
            plt.show();


        }
        plt.plot();
//        JFreeChart newChart = ChartFactory.createXYLineChart(
//                "THD vs. Frequency and input amplitudes" ,
//                "Frequency (Hz)",
//                "THD (db)" ,
//             //   chart.createDataset(finalSignalFrame) ,
//                PlotOrientation.VERTICAL ,
//                true , true , false);




    }

}
