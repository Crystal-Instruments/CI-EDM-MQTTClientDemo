package org.example.mqtt;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.eclipse.paho.client.mqttv3.*;
import org.eclipse.paho.client.mqttv3.persist.MemoryPersistence;
import org.example.exception.BrokerConnectionException;
import org.example.gui.MainFrame;
import org.example.messages.*;
import org.example.utils.ErrorPopup;
import org.example.utils.MqttResponse;
import org.json.JSONArray;
import org.json.JSONObject;

import javax.swing.*;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class MqttConfig {
    private String brokerIp;
    private String username;
    private String password;
    private String prefix;
    private final String pubGeneralTopic = "/App/Test/Command";
    private final String pubVCSTopic = "/VCS/Test/Command";
    private final String pubDSATopic = "/DSA/Test/Command";
    public BlockingQueue<MqttResponse> queue;
    public AppStatus appStatus;

    public MqttSystemStatus mqttSystemStatus;

    public MqttSystem mqttSystem;

    public MqttTestStatus mqttTestStatus;

    public MqttTest mqttTest;

    public MqttRandomTestStatus mqttRandomTestStatus;

    public List<MqttChannel> mqttChannelsList;

    public List<Signals> signalList;

    public List<MqttSignalProperty>signalPropList;

    public List<MqttSignalFrameData> signalFrameDataList = new ArrayList<>();

    public List<MqttTest> mqttTestList;

    public MqttShaker mqttShaker;

    public MqttReportFile report;
    public MqttRunFolder runFolder;
    public MqttLimitStatus mqttLimitStatus;
    public MqttVcsTestStage vcsTestStage;
    public MqttRecordStatus recordStatus;
    public MqttVcsControlFlag vcsControlFlag;

    public MqttDsaTestStatus dsaTestStatus;
    public MqttSineTestStatus sineTestStatus;
    public MqttShockTestStatus shockTestStatus;
    private String currStatus;
    MqttClient client;
    private boolean showChart = false;

    private Boolean connectToBroker;  // tells whether you're connected to broker

    private final Object lock = new Object();  //lock is used to update whether broker is connected or not.

    public Object getLock(){
        return lock;
    }


    /*
    Separate thread is used to process messages in blocking queue.
     */
    public MqttConfig(String brokerIp, String username, String password, String prefix) throws MqttException {
        this.brokerIp = brokerIp;
        this.prefix = prefix;
        this.username = username;
        this.password = password;
        queue = new LinkedBlockingQueue<>();
        this.client = this.connectMqtt(brokerIp, username, password, prefix);
        connectToBroker = true;
        this.subscribe();
        Runnable r = ()-> {
            try {
                processQueue();
            } catch (InterruptedException | JsonProcessingException e) {
                throw new RuntimeException(e);
            }
        };
        Thread t = new Thread(r);
        t.start();



    }
    public void processQueue() throws InterruptedException, JsonProcessingException {
        while(true){
            MqttResponse response = queue.take();
            String topic = response.getTopic();
            String msg = new String(response.getMessage().getPayload());
            ObjectMapper mapper = new ObjectMapper();
            synchronized (lock){
                if (!connectToBroker) {
                    break;
                }
            }
            //Mapper used to map json message to a class. Easier to get data such as status and signal data.
            if(topic.equals(prefix.concat("/App/Status"))){
                appStatus = mapper.readValue(msg, AppStatus.class);
                MainFrame.systemPanel.setAppInfo(appStatus.SoftwareMode, appStatus.Version);
            }
            else if(topic.equals(prefix.concat("/App/System/Status"))){
                mqttSystemStatus = mapper.readValue(msg, MqttSystemStatus.class);
                MainFrame.systemPanel.setSystemStatus(mqttSystemStatus.Name, mqttSystemStatus.Status);
            }
            else if(topic.equals(prefix.concat("/App/System"))) {
                JSONObject obj = new JSONObject(msg);
                JSONArray arr = obj.getJSONArray("Modules");
                String arrStr = arr.toString();
                List<MqttDeviceModule> lists = mapper.readValue(arrStr, new TypeReference<List<MqttDeviceModule>>(){});
                mqttSystem = new MqttSystem();
                mqttSystem.Name = obj.getString("Name");
                mqttSystem.Modules = lists;
                MainFrame.systemPanel.setModules(mqttSystem.Modules);

            }
            else if(topic.equals(prefix.concat("/App/Error"))){
                ErrorPopup.infoBox(msg, "Error");
            }

            else if(topic.equals(prefix.concat("/App/Test/List")))
                mqttTestList = mapper.readValue(msg,new TypeReference<List<MqttTest>>(){} );


            else if(topic.equals(prefix.concat("/App/Test/ReportFile"))){
                report = mapper.readValue(msg, MqttReportFile.class);
            }
            else if(topic.equals(prefix.concat("/App/Status")))
                appStatus = mapper.readValue(msg, AppStatus.class);

            /*
            If test is running, signal graph can start running if checkmarks are selected.
             */
            else if(topic.equals(prefix.concat("/App/Test/Status"))) {
                mqttTestStatus = mapper.readValue(msg, MqttTestStatus.class);
                if(mqttTestStatus.Status.equals("Running")){
                    currStatus =mqttTestStatus.Status;
                    if(!showChart) {
                        MainFrame.signalPanel.executeShowChart();
                        showChart = true;
                    }

                }
                else{
                    currStatus =mqttTestStatus.Status;
                    showChart = false;
                }
            }
            /*
            Status tab has tables updated here.
             */
            else if(topic.equals(prefix.concat("/App/Test/Status"))){
                mqttTestStatus = mapper.readValue(msg, MqttTestStatus.class);
                currStatus = mqttTestStatus.Status;
                String [] columns = {"", ""};
                if(mqttTest != null) {

                    String[][] data = {{"Name", mqttTest.Name}, {"Type", mqttTest.Type}, {"Status", mqttTestStatus.Status}, {"Run Folder", mqttTestStatus.RunFolder}, {"Measure Start At", mqttTestStatus.MeasureStartAt}};
                    JTable jt = new JTable(data, columns);
                    jt.setRowHeight(4, 50);
                    jt.setTableHeader(null);
                    JScrollPane sp = new JScrollPane(jt);
                    MainFrame.statussPanel.setTestInfo(jt,sp);

                }
                else{
                    String[][] data = {{"Name", mqttTestStatus.Name}, {"Type", "<Type>"}, {"Status", mqttTestStatus.Status}, {"Run Folder", mqttTestStatus.RunFolder}, {"Measure Start At", mqttTestStatus.MeasureStartAt}};
                    JTable jt = new JTable(data, columns);
                    jt.setRowHeight(4, 50);
                    jt.setTableHeader(null);
                    JScrollPane sp = new JScrollPane(jt);
                    MainFrame.statussPanel.setTestInfo(jt,sp);

                }
            }

            else if(topic.equals(prefix.concat("/App/Test"))){
                mqttTest = mapper.readValue(msg, MqttTest.class);
                String [] columns = {"", ""};
                String [][] data = {{"Name", mqttTest.Name}, {"Type", mqttTest.Type},{"Status", mqttTestStatus.Status}, {"Run Folder", mqttTestStatus.RunFolder}, {"Measure Start At", mqttTestStatus.MeasureStartAt}};
                JTable jt = new JTable(data, columns);
                jt.setRowHeight(4, 50);
                jt.setTableHeader(null);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.statussPanel.setTestInfo(jt,sp);

            }



            else if(topic.equals(prefix.concat("/App/Test/Channels"))){
                JSONArray arr = new JSONArray(msg);
                String arrStr = arr.toString();
                mqttChannelsList = mapper.readValue(arrStr, new TypeReference<List<MqttChannel>>(){});

            }

            else if(topic.equals(prefix.concat("/VCS/Test/Shaker"))){
                mqttShaker = mapper.readValue(msg,MqttShaker.class);

            }

            else if(topic.equals(prefix.concat("/App/Test/Signals"))){
                JSONArray arr = new JSONArray(msg);
                String arrStr = arr.toString();
                signalList = mapper.readValue(arrStr, new TypeReference<List<Signals>>() {});

            }
            /*
            Another status table updated here.
             */
            else if(topic.equals(prefix.concat("/VCS/Test/Stage"))){
                vcsTestStage = mapper.readValue(msg, MqttVcsTestStage.class);
                String [] columns = {"", ""};
                String [][]data=  {{"Name", vcsTestStage.Name}, {"Stage", vcsTestStage.Stage}};
                JTable jt = new JTable(data, columns);
                jt.setRowHeight(1, 70);
                jt.setTableHeader(null);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.statussPanel.setVcsTestStageValues(jt,sp);

            }
            else if(topic.equals(prefix.concat("/VCS/Test/ControlUpdated"))){
                vcsControlFlag = mapper.readValue(msg, MqttVcsControlFlag.class);
                String [] columns ={"", ""};
                String [] [] data ={{"Name", vcsControlFlag.Name}, {"Flag", vcsControlFlag.Flag}};
                JTable jt = new JTable(data, columns);
                jt.setRowHeight(1, 70);
                jt.setTableHeader(null);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.statussPanel.setVcsControlFlagValues(jt,sp);

            }
            else if(topic.equals(prefix.concat("/App/Test/RecordStatus"))){
                recordStatus = mapper.readValue(msg, MqttRecordStatus.class);
                String [] columns = {"", ""};
                String [][]data=  {{"Name", recordStatus.Name}, {"Status", recordStatus.Status}};
                JTable jt = new JTable(data, columns);
                jt.setRowHeight(1, 70);
                jt.setTableHeader(null);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.statussPanel.setRecordStatusValues(jt,sp);
            }
            else if(topic.equals(prefix.concat("/App/Test/RunFolder"))){
                JSONObject obj = new JSONObject(msg);
                JSONArray arr = obj.getJSONArray("RunFiles");
                String runName = obj.getString("RunName");
                String runPath = obj.getString("RunPath");
                String arrStr = arr.toString();
                List<String> runFiles = mapper.readValue(arrStr, new TypeReference<List<String>>(){});
                runFolder = new MqttRunFolder(runName, runPath, runFiles);

            }
            else if(topic.equals(prefix.concat("/App/Test/LimitStatus"))){
                mqttLimitStatus = mapper.readValue(msg, MqttLimitStatus.class);
                String [] columns = {"", ""};
                String [][] data = {{"Name", mqttLimitStatus.Name}, {"Status", mqttLimitStatus.Status}};
                JTable jt = new JTable(data, columns);
                jt.setRowHeight(1, 70);
                jt.setTableHeader(null);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.statussPanel.setLimitStatusValues(jt,sp);


            }
            /*
            Test detail status tab updated here.
             */
            else if(topic.equals(prefix.concat("/VCS/Test/RandomStatus"))){
                mqttRandomTestStatus = mapper.readValue(msg, MqttRandomTestStatus.class);
                String [] columns = {"Name", "Value"};
                String[][] data = {
                        {"Timestamp", mqttRandomTestStatus.Timestamp},
                        {"AccUnit", mqttRandomTestStatus.AccUnit},
                        {"VelUnit", mqttRandomTestStatus.VelUnit},
                        {"DisplUnit", mqttRandomTestStatus.DisplUnit},
                        {"EntryIndex", String.valueOf(mqttRandomTestStatus.EntryIndex)},
                        {"DrivePeak", String.valueOf(mqttRandomTestStatus.DrivePeak)},
                        {"TargetRMS", String.valueOf(mqttRandomTestStatus.TargetRMS)},
                        {"ControlRMS", String.valueOf(mqttRandomTestStatus.ControlRMS)},
                        {"Level", String.valueOf(mqttRandomTestStatus.Level)},
                        {"TotalTime", String.valueOf(mqttRandomTestStatus.TotalTime)},
                        {"RemainTime", String.valueOf(mqttRandomTestStatus.RemainTime)},
                        {"FullLevelTime", String.valueOf(mqttRandomTestStatus.FullLevelTime)},
                        {"VelPeak", String.valueOf(mqttRandomTestStatus.VelPeak)},
                        {"DisplPeakPeak", String.valueOf(mqttRandomTestStatus.DisplPeakPeak)},
                        {"Kurtosis", String.valueOf(mqttRandomTestStatus.Kurtosis)}

                };
                JTable jt = new JTable(data, columns);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.detailStatusPanel.displayTestStatus(jt, sp);

            }
            else if(topic.equals(prefix.concat("/VCS/Test/ShockStatus"))){
                shockTestStatus = mapper.readValue(msg, MqttShockTestStatus.class);
                String [] columns = {"Name", "Value"};
                String[][] data = {
                        {"Timestamp", shockTestStatus.Timestamp},
                        {"AccUnit", shockTestStatus.AccUnit},
                        {"VelUnit", shockTestStatus.VelUnit},
                        {"DisplUnit", shockTestStatus.DisplUnit},
                        {"EntryIndex", String.valueOf(shockTestStatus.EntryIndex)},
                        {"DrivePeak", String.valueOf(shockTestStatus.DrivePeak)},
                        {"TargetPeak", String.valueOf(shockTestStatus.TargetPeak)},
                        {"ControlPeak", String.valueOf(shockTestStatus.ControlPeak)},
                        {"RMS", String.valueOf(shockTestStatus.RMS)},
                        {"Level", String.valueOf(shockTestStatus.Level)},
                        {"TotalPulse", String.valueOf(shockTestStatus.TotalPulse)},
                        {"RemainPulse", String.valueOf(shockTestStatus.RemainPulse)},
                        {"FullLevelPulse", String.valueOf(shockTestStatus.FullLevelPulse)},
                        {"VelPeak", String.valueOf(shockTestStatus.VelPeak)},
                        {"DisplPeakPeak", String.valueOf(shockTestStatus.DisplPeakPeak)}
                };
                JTable jt = new JTable(data, columns);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.detailStatusPanel.displayTestStatus(jt, sp);

            }
            else if (topic.equals(prefix.concat("/VCS/Test/SineStatus"))){
                sineTestStatus = mapper.readValue(msg, MqttSineTestStatus.class);
                String [] columns = {"Name", "Value"};
                String[][] data = {
                        {"Timestamp", sineTestStatus .Timestamp},
                        {"AccUnit", sineTestStatus .AccUnit},
                        {"VelUnit", sineTestStatus .VelUnit},
                        {"DisplUnit", sineTestStatus .DisplUnit},
                        {"EntryIndex", String.valueOf(sineTestStatus .EntryIndex)},
                        {"DrivePeak", String.valueOf(sineTestStatus .DrivePeak)},
                        {"TargetPeak", String.valueOf(sineTestStatus .TargetPeak)},
                        {"ControlPeak", String.valueOf(sineTestStatus .ControlPeak)},
                        {"Level", String.valueOf(sineTestStatus .Level)},
                        {"TotalTime", String.valueOf(sineTestStatus .TotalTime)},
                        {"RemainTime", String.valueOf(sineTestStatus .RemainTime)},
                        {"FullLevelTime", String.valueOf(sineTestStatus .FullLevelTime)},
                        {"VelPeak", String.valueOf(sineTestStatus .VelPeak)},
                        {"DisplPeakPeak", String.valueOf(sineTestStatus .DisplPeakPeak)},
                        {"TotalCycle", String.valueOf(sineTestStatus.TotalCycle)},
                        {"ElapsedCycle", String.valueOf(sineTestStatus.ElapsedCycle)},
                        {"SampleRate", String.valueOf(sineTestStatus.SampleRate)},
                        {"Frequency", String.valueOf(sineTestStatus.Frequency)},
                        {"SweepRate", String.valueOf(sineTestStatus.SweepRate)},
                        {"SweepNum", String.valueOf(sineTestStatus.SweepNum)},
                        {"SweepDirection", String.valueOf(sineTestStatus.SweepDirection)},
                        {"SweepIndex", String.valueOf(sineTestStatus.SweepIndex)}

                };
                JTable jt = new JTable(data, columns);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.detailStatusPanel.displayTestStatus(jt, sp);

            }
            else if(topic.equals(prefix.concat("/DSA/Test/DSAStatus"))){
                dsaTestStatus = mapper.readValue(msg, MqttDsaTestStatus.class);
                String [] columns ={"Name", "Value"};
                String [][] data = {
                        {"Timestamp", dsaTestStatus.Timestamp},
                        {"AcceptedFrameNum", String.valueOf(dsaTestStatus.AcceptedFrameNum)},
                        {"TotalFrameNum", String.valueOf(dsaTestStatus.TotalFrameNum)},
                        {"AverageNum", String.valueOf(dsaTestStatus.AverageNum)},
                        {"OutputPeak", String.valueOf(dsaTestStatus.OutputPeak)},
                        {"DIOStatus", String.valueOf(dsaTestStatus.DIOStatus)},
                        {"DisplaySignalCount", String.valueOf(dsaTestStatus.DisplaySignalCount)},
                        {"RPM1", String.valueOf(dsaTestStatus.RPM1)},
                        {"RPM2", String.valueOf(dsaTestStatus.RPM2)}
                };
                JTable jt = new JTable(data, columns);
                JScrollPane sp = new JScrollPane(jt);
                MainFrame.detailStatusPanel.displayTestStatus(jt, sp);

            }

            else if(topic.equals(prefix.concat("/App/Test/SignalData"))){
                signalFrameDataList.clear();

                JSONArray jsonArray = new JSONArray(msg);
                for(int i =0; i<jsonArray.length();++i){

                    JSONObject obj = (JSONObject) jsonArray.get(i);
                    Signals signal = mapper.readValue(obj.getJSONObject("Signal").toString(), Signals.class);
                    System.out.println(signal.Name);
                    JSONArray arr = obj.getJSONArray("ValueX");
                    String arrStr = arr.toString();
                    List<Double> xArray =  mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    arr = obj.getJSONArray("ValueY");
                    arrStr = arr.toString();
                    List<Double> yArray = mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    arr = obj.getJSONArray("ValueZ");
                    arrStr = arr.toString();
                    List<Double> zArray = mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    MqttSignalFrameData signalData = new MqttSignalFrameData(signal, (ArrayList<Double>) xArray, (ArrayList<Double>) yArray, (ArrayList<Double>) zArray);
                    signalFrameDataList.add(signalData);
                }

            }
            else if(topic.equals(prefix.concat("/App/Test/SignalProperty"))) {
                JSONArray arr = new JSONArray(msg);
                String arrStr = arr.toString();
                signalPropList = mapper.readValue(arrStr, new TypeReference<List<MqttSignalProperty>>() {});


            }




        }
    }
    public void subscribe() throws MqttException{
        client.subscribe(prefix.concat("/#"));
    }
    public void publish(String pubTopic, String msg){
        try {
            client.publish(prefix.concat(pubTopic), new MqttMessage(msg.getBytes()));
        }
        catch(MqttException e){
            ErrorPopup.infoBox("Failed to publish to: "+ pubTopic, "Error");
            throw new BrokerConnectionException("Failed to publish to: "+ pubTopic, e);
        }
        catch(NullPointerException e){
            System.out.println("Not connected to broker yet");
            ErrorPopup.infoBox("Failed to publish to: "+ pubTopic, "Error");
        }

    }


    public String parsePassword(String pwd){
        StringBuilder str = new StringBuilder();
        for(int i =0; i< pwd.length(); ++i){
            if(pwd.charAt(i) != '[' && pwd.charAt(i) != ',' && pwd.charAt(i) != ']' && pwd.charAt(i) != ' ')
                str.append(pwd.charAt(i));
        }
        return new String(str).strip();
    }

    public Boolean getConnectToBroker(){
        return connectToBroker;
    }
    public void disconnectMqtt() throws MqttException {
        client.disconnect();
        synchronized (lock){
            System.out.println("change");
            connectToBroker = false;
        }

    }
    public MqttClient connectMqtt(String brokerIp, String username, String password, String prefix) throws MqttException {
        String broker = "tcp://".concat(brokerIp);
        MqttClient client = new MqttClient(broker, "hi", new MemoryPersistence());
        MqttConnectOptions options = new MqttConnectOptions();
        options.setUserName(username);
        options.setPassword(parsePassword(password).toCharArray());
        client.connect(options);
        connectToBroker = true;

        client.setCallback(new MqttCallback() {

            public void connectionLost(Throwable cause) {
                System.out.println("connectionLost: " + cause.getMessage());
                cause.printStackTrace();
            }

            public void messageArrived(String topic, MqttMessage message) throws Exception {
                MqttResponse mqttResponse = new MqttResponse(topic, message);
                String msg;
                queue.put(mqttResponse);
                topic = mqttResponse.getTopic();
                msg = new String(mqttResponse.getMessage().getPayload());
                System.out.println("topic: " + topic);
                System.out.println("Qos: " + mqttResponse.getMessage().getQos());
                System.out.println("Message content: " + msg);
            }

            public void deliveryComplete(IMqttDeliveryToken token) {
                // System.out.println("deliveryComplete---------" + token.isComplete());
            }

        });
        return client;


    }
    public void run(){
        /*
        Run the test
         */
        publish(pubGeneralTopic, "Run");
    }
    public void connect(){
        /*
        Connect to the Spider
         */
        publish(pubGeneralTopic, "Connect");

    }

    public void disconnect(){
        /*
        Disconnect from spider
         */
        publish(pubGeneralTopic, "Disconnect");
    }


    public void proceed(){
        /*
        Proceed with the current test
         */
        publish(pubGeneralTopic, "Proceed");
    }
    public void stop(){
        /*
        Stop the current test
         */
        publish(pubGeneralTopic, "Stop");
    }
    public void startRecord(){
        /*
        Start recording
         */
        publish(pubGeneralTopic, "StartRecord");
    }

    public void stopRecord(){
        /*
        Stop recording
         */
        publish(pubGeneralTopic, "StopRecord");
    }
    public void saveSignals(){
        publish(pubGeneralTopic, "SaveSignals");
    }

    public void cont(){
        /*
        Continue the current test
         */
        publish(pubGeneralTopic, "Continue");
    }

    public void pause(){
        /*
        Pause the current test
         */
        publish(pubGeneralTopic, "Pause");
    }

    public void getChannelData(String chan){
        /*
        Get the time stream data of channel number "chan"
         */
        System.out.println("RequestSignalData;"+ chan);
        publish(pubGeneralTopic, "RequestSignalData;"+ chan);
    }

    public void getSignalProperty(String prop, String chan){
        publish(pubGeneralTopic, "RequestSignalProperty;"+ prop + ";"+ chan + ";");
    }


    public void requestDetailStatus(){
        publish(pubGeneralTopic, "RequestDetailStatus");
    }


    /*
    VCS Commands
     */
    public void checkOnly(){ publish(pubVCSTopic, "CheckOnly");}
    public void proceedVCS(){
        /*
        Proceed with VCS
         */
        publish(pubVCSTopic, "Proceed");
    }
    public void saveHSignal(){ publish(pubVCSTopic, "SaveHSignal");}
    public void setLevel(Double percent){
        /*
        Set level of output channel in percent
         */
        publish(pubVCSTopic, "SetLevel;"+percent.toString());
    }
    public void showPretest(){
        publish(pubVCSTopic, "ShowPretest");
    }
    public void resetAverage(){
        publish(pubGeneralTopic, "ResetAverage");
    }
    public void nextEntry(){
        publish(pubVCSTopic, "NextEntry");
    }
    public void abortChecksOn(){
        publish(pubVCSTopic, "AbortChecksOn");
    }
    public void abortChecksOff(){
        publish(pubVCSTopic, "AbortChecksOff");
    }
    public void closedLoopControlOn(){
        publish(pubVCSTopic, "ClosedLoopControlOn");
    }
    public void closedLoopControlOff(){
        publish(pubVCSTopic, "ClosedLoopControlOff");
    }
    public void scheduleClockTimerOn(){
        publish(pubVCSTopic, "ScheduleClockTimerOn");
    }
    public void scheduleClockTimerOff(){
        publish(pubVCSTopic, "ScheduleCLockTimerOff");
    }
    public void rorBandsOn(String bands){
        publish(pubVCSTopic, "RoRBandsOn;"+ bands);
    }
    public void rorBandsOff(){
        publish(pubVCSTopic, "RoRBandsOff");
    }
    public void sorTonesOn(String tones){
        publish(pubVCSTopic, "SoRBandsOn;" + tones);
    }
    public void sorTonesOff(){
        publish(pubVCSTopic, "SoRBandsOff");
    }
    public void sorTonesHoldSweep(){
        publish(pubVCSTopic, "SoRTonesHoldSweep");
    }
    public void sorTonesReleaseSweep(){
        publish(pubVCSTopic, "SoRTonesReleaseSweep");
    }
    public void sorTonesSweepUp(){
        publish(pubVCSTopic, "SoRTonesSweepUp");
    }
    public void sorTonesSweepDown(){
        publish(pubVCSTopic, "SoRTonesSweepDown");
    }
    public void holdSweep(){
        publish(pubVCSTopic, "HoldSweep");
    }
    public void releaseSweep(){
        publish(pubVCSTopic, "ReleaseSweep");
    }
    public void sweepUp(){
        publish(pubVCSTopic, "SweepUp");
    }
    public void sweepDown(){
        publish(pubVCSTopic, "SweepDown");
    }
    public void levelUp(){
        publish(pubVCSTopic, "LevelUp");
    }
    public void levelDown(){
        publish(pubVCSTopic, "LevelDown");
    }
    public void setLevel(int level){
        publish(pubVCSTopic, "SetLevel;"+ level + ";");
    }
    public void restoreLevel(){
        publish(pubVCSTopic, "RestoreLevel");
    }
    public void increaseSpeed(){
        publish(pubVCSTopic, "IncreaseSpeed");
    }
    public void decreaseSpeed(){
        publish(pubVCSTopic, "DecreaseSpeed");
    }
    public void setFrequency(int freq){
        publish(pubVCSTopic, "SetFrequency;"+ freq + ";");
    }
    public void setPhase(int phase){
        publish(pubVCSTopic, "SetPhase;"+ phase+ ";");
    }
    public void inversePulseOn(){
        publish(pubVCSTopic, "InversePulseOn");
    }
    public void inversePulseOff(){
        publish(pubVCSTopic, "InversePulseOff");
    }
    public void singlePulseOn(){
        publish(pubVCSTopic, "SinglePulseOn");
    }
    public void singlePulseOff(){
        publish(pubVCSTopic, "SinglePulseOff");
    }
    public void outputSinglePulse(){
        publish(pubVCSTopic, "OutputSinglePulse");
    }

    /**
     *
     * DSA Commands
     *
     */
    public void triggerOn(){
        publish(pubDSATopic, "TriggerOn");
    }
    public void triggerOff(){
        publish(pubDSATopic, "TriggerOff");
    }
    public void outputOn(){
        publish(pubDSATopic, "OutputOn");
    }
    public void outputOff(){
        publish(pubDSATopic, "OutputOff");
    }
    public void limitOn(){
        publish(pubDSATopic, "LimitOn");
    }
    public void limitOff(){
        publish(pubDSATopic, "LimitOff");
    }
    public String getCurrStatus(){
        return currStatus;
    }

    /**
     * List/Create/Load/Delete Tests
     */
    public void listTest(){
        publish(pubGeneralTopic, "ListTest");
    }
    public void loadTest(String test){
        publish(pubGeneralTopic, "LoadTest;"+ test + ";");
    }
    public void deleteTest(String test){
        publish(pubGeneralTopic, "DeleteTest;" + test+ ";");
    }

    public void createTest(String test, String type){
        publish(pubGeneralTopic, "CreateTest;"+ test + ";"+ type +";");
    }

    /**
     * Report
     */
    public void generateReport(String template){
        publish(pubGeneralTopic, "GenerateReport;" + template+ ";");
    }
    /**
     * Run Folder
     */
    public void requestRunFolder(){
        publish(pubGeneralTopic, "RequestRunFolder");
    }

    /**
     * Advanced Commands
     */
    public void setChannelTable(String content){
        publish(pubGeneralTopic, "SetChannelTable;" + content);
    }

    public void setSchedule(String content){
        publish(pubGeneralTopic, "SetSchedule;"+ content);
    }

    public void setRandomProfile(String content){
        publish(pubVCSTopic, "SetRandomProfile;"+ content);
    }

    public void setSineProfile(String content){
        publish(pubVCSTopic, "SetSineProfile;"+ content);
    }
    public void setShockProfile(String content){
        publish(pubVCSTopic, "SetShockProfile;"+ content);
    }

    /**
     * DSA output control
     */
    public void setOutputIndex(Integer index){
        publish(pubDSATopic, "SetOutputIndex;" + index);
    }
    public void outputSine(Integer amplitude, Integer frequency, Integer offset){
        /*
        Output control
         */
        String outString = amplitude.toString()+";"+ frequency.toString()+ ";"+ offset.toString();
        publish(pubDSATopic,  "SetOutputParameters;Sine;"+ outString);

    }
    public void outputTriangle(Integer amplitude, Integer frequency){
        /*
        Output control
         */
        String outString = amplitude.toString()+";"+ frequency.toString();
        publish(pubDSATopic, "SetOutputParameters;Triangle;"+ outString);
    }

    public void outputSquare(Integer amplitude, Integer frequency){
        /*
        Output control
         */
        String outString = amplitude.toString()+";"+ frequency.toString();
        publish(pubDSATopic, "SetOutputParameters;Square;"+ outString);
    }
    public void whiteNoise(Double RMS){
        /*
        Output control
         */
        String outString = RMS.toString();
        publish(pubDSATopic, "SetOutputParameters;WhiteNoise;" + outString);

    }
    public void pinkNoise(Double RMS){
        /*
        Output control
         */
        String outString = RMS.toString();
        publish(pubDSATopic, "SetOutputParameters;PinkNoise;" + outString);

    }

    public void outputDC(Integer amplitude){
        /*
        Output control
         */
        String outString = amplitude.toString();
        publish(pubDSATopic,"SetOutputParameters;DC;" + outString);
    }

    public void outputChirp(Integer amplitude, Integer lowFrequency, Integer highFrequency, Double percent, Integer period){
        /*
        Output control
         */
        String outString = amplitude.toString() + ";" + lowFrequency.toString() + ";" +
                highFrequency.toString() + ";" + percent.toString() + ";" + period.toString();
        publish(pubDSATopic, "SetOutputParameters;Chirp;" + outString);
    }
    public void outputSweptSine(Integer amplitude, Integer lowFrequency, Integer highFrequency, Integer period){
        /*
        Output control
         */
        String outString = amplitude.toString() + ";" + lowFrequency.toString() + ";" +
                highFrequency.toString() + ";" + period.toString();
        publish(pubDSATopic, "SetOutputParameters;SweptSine;" + outString);
    }




}
