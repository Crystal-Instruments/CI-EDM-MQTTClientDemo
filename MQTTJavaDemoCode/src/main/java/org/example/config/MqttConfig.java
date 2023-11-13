package org.example.config;


import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.eclipse.paho.client.mqttv3.*;
import org.eclipse.paho.client.mqttv3.persist.MemoryPersistence;
import org.example.messages.*;
import org.example.utils.MqttResponse;
import org.json.JSONArray;
import org.json.JSONObject;


import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.net.InetAddress;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class MqttConfig {
    private final String brokerIP;
    private final String username;
    private final String password;

    private final String prefix;
    private final String pubGeneralTopic = "/App/Test/Command";
    private final String pubVCSTopic = "/VCS/Test/Command";
    private final String pubDSATopic = "/DSA/Test/Command";


    public BlockingQueue<MqttResponse> queue = new LinkedBlockingQueue<>();

    public BlockingQueue<MqttResponse> signalDataQueue = new LinkedBlockingQueue<>();
    private final MqttClient subClient;

    private final HashMap<String, Object> hm = new HashMap<>();

    public HashMap<String, SignalData> signalDataHashMap = new HashMap<>();

    private final MqttClient pubClient;

    private boolean initHm;
    private Long blockSize;
    private float sampleRate;
    private float freqRange;
    private float freqResolution;

    private ArrayList<Float> freqs;


    public float getFreqRange() {
        return freqRange;
    }

    public float getFreqResolution() {
        return freqResolution;
    }

    public boolean isInitHm() {
        return initHm;
    }

    public void setInitHm(boolean initHm) {
        this.initHm = initHm;
    }

    public MqttConfig(boolean initHm, String ipAddress) throws IOException, MqttException {
        InetAddress IP = InetAddress.getLocalHost();
        brokerIP = ipAddress;

        initHm = initHm;

        freqs = new ArrayList<>();

        File file = new File("src\\main\\resources\\config");

        BufferedReader br
                = new BufferedReader(new FileReader(file));

        // Declaring a string variable
        String st;
        // Condition holds true till
        // there is character in a string
        ArrayList<String> arr = new ArrayList<>();
        while ((st = br.readLine()) != null)

            // Print the string
            arr.add(st);

        username = arr.get(0).substring(10);
        password = arr.get(1).substring(10);
        prefix = arr.get(2).substring(8);
        String subClientId = "Java subscriber";
        subClient = this.connectMqtt(subClientId);
        String pubClientId = "Java publisher";
        pubClient = this.connectMqtt(pubClientId);

        String[] subTopics = new String[]{"/App/Test/SignalData",
                "/VCS/Test/Stage",
                "/VCS/Test/SineStatus",
                "/App/Message",
                "/DSA/Test/SignalData",
                "/DSA/Test/DSAStatus",
                "/App/System/Status",
                "/App/System",
                "/App/Status",
                "/App/Test/Status"};

        this.subscribe(subTopics);


    }
    public MqttClient getSubClient() {
        return subClient;
    }

    public MqttClient connectMqtt(String clientId) throws MqttException {
        String broker = "tcp://".concat(brokerIP);
        MqttClient client = new MqttClient(broker, clientId, new MemoryPersistence());
        MqttConnectOptions options = new MqttConnectOptions();
        options.setUserName(username);
        options.setPassword(password.toCharArray());
        client.connect(options);
        client.setCallback(new MqttCallback() {

            public void connectionLost(Throwable cause) {
                System.out.println("connectionLost: " + cause.getMessage());
            }

            public void messageArrived(String topic, MqttMessage message) throws Exception {
                MqttResponse mqttResponse = new MqttResponse(topic, message);
                String msg;
                queue.put(mqttResponse);
                topic = mqttResponse.getTopic();

                msg = new String(mqttResponse.getMessage().getPayload());
                if(topic.equals(prefix.concat("/App/Test/SignalData"))) {
                    signalDataQueue.put(mqttResponse);
                    JSONArray jsonArray = new JSONArray(msg);
                    JSONObject obj = (JSONObject) jsonArray.get(0);
                    ObjectMapper mapper = new ObjectMapper();

                    Signals signal = mapper.readValue(obj.getJSONObject("Signal").toString(), Signals.class);
                    JSONArray arr = obj.getJSONArray("ValueX");
                    String arrStr = arr.toString();
                    List<Double> xArray =  mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    arr = obj.getJSONArray("ValueY");
                    arrStr = arr.toString();
                    List<Double> yArray = mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    arr = obj.getJSONArray("ValueZ");
                    arrStr = arr.toString();
                    List<Double> zArray = mapper.readValue(arrStr, new TypeReference<List<Double>>(){});
                    SignalData signalData = new SignalData(signal, (ArrayList<Double>) xArray, (ArrayList<Double>) yArray, (ArrayList<Double>) zArray);
                    signalDataHashMap.put(topic, signalData);

                }
//                System.out.println("topic: " + topic);
//                System.out.println("Qos: " + mqttResponse.getMessage().getQos());
//                System.out.println("Message content: " + msg);

                //hm.put(topic, msg);
//                if(!initHm){
//                    if(hm.containsKey(prefix.concat("/App/Test/SignalData"))) {
//
//
//                        blockSize = Integer.parseInt(hm.get(prefix.concat("/App/Test/SignalData")).split("ValueX")[0].split("BlockSize")[1].split(",")[0].substring(2));
//                        String strSample = hm.get(prefix.concat("/App/Test/SignalData")).split("ValueX")[0].split("SamplingRate")[1].split(",")[0];
////
//                        sampleRate = Float.parseFloat(strSample.substring(2,strSample.length()-1));
//                        freqRange = (float) (sampleRate * 0.44);
//                        freqResolution = sampleRate /blockSize / 2;
//                        for(int i =0; i<blockSize; ++i) freqs.add(i * freqResolution);
//                        initHm = true;
//
//
//
//
//                    }
//
//
//                }




            }

            public void deliveryComplete(IMqttDeliveryToken token) {
               // System.out.println("deliveryComplete---------" + token.isComplete());
            }

        });



        return client;
    }

    public Long getBlockSize() {
        return blockSize;
    }

    public void setBlockSize(Long blockSize) {
        this.blockSize = blockSize;
    }

    public float getSampleRate() {
        return sampleRate;
    }

    public void setSampleRate(float sampleRate) {
        this.sampleRate = sampleRate;
    }

    public void setFreqRange(float freqRange) {
        this.freqRange = freqRange;
    }

    public void setFreqResolution(float freqResolution) {
        this.freqResolution = freqResolution;
    }

    public ArrayList<Float> getFreqs() {
        return freqs;
    }

    public void setFreqs(ArrayList<Float> freqs) {
        this.freqs = freqs;
    }

    public void subscribe(String [] topics) throws MqttException {
        for (String topic : topics) {
            subClient.subscribe(prefix.concat(topic));
        }

    }
    public void publish(String pubTopic, String msg){
        try {
            pubClient.publish(prefix.concat(pubTopic), new MqttMessage(msg.getBytes()));
        }
        catch(MqttException e){
            System.out.println("Failed to publish to: "+ pubTopic );
        }

    }



 /*
 EDM FUNCTIONS
  */
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

    public void run(){
        /*
        Run the test
         */
        publish(pubGeneralTopic, "Run");
    }

    public void stop(){
        /*
        Stop the current test
         */
        publish(pubGeneralTopic, "Stop");
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
    public void proceed(){
        /*
        Proceed with the current test
         */
        publish(pubGeneralTopic, "Proceed");
    }

    public void proceedVCS(){
        /*
        Proceed with VCS
         */
        publish(pubVCSTopic, "Proceed");
    }
    public void resetAverage(){
        /*
        Rest the APS averaging
         */
        publish(pubGeneralTopic, "ResetAverage");
    }


    /*
    Output Control

     */

    public void outputToggle(String onOffSwitch){
        /*
        Toggle the output channel on/off
         */
        if(onOffSwitch.equals("on") || onOffSwitch.equals("1") || onOffSwitch.equals("yes") || onOffSwitch.equals("true")) publish(pubDSATopic, "OutputOn");
        else if (onOffSwitch.equals("off") || onOffSwitch.equals("0") || onOffSwitch.equals("no") || onOffSwitch.equals("false")) publish(pubDSATopic, "OutputOff");
    }

    public void setFrequency(Float freq){
        /*
        Set frequency of output channel
         */
        publish(pubVCSTopic, "SetFrequency;"+ freq.toString());
    }

    public void setLevel(Float percent){
        /*
        Set level of output channel in percent
         */
        publish(pubVCSTopic, "SetLevel;"+percent.toString());
    }

    public void holdSweep(){
        /*
        Hold/pause the sweep in VCS
         */
        publish(pubVCSTopic, "HoldSweep");
    }

    public void releaseSweep(){
        /*
        Release/continue the sweep in VCS
         */
        publish(pubVCSTopic, "ReleaseSweep");
    }

    public void setAbortSensitivity(Float sens){
        /*
        Set the abort sensitivity
         */
        publish(pubGeneralTopic, "SetParameter;VCSGeneral_AbortSensitivity;" + sens.toString());
    }

    public void setRampRate(Float rate){
        /*
        Set the ramp rate
         */
        publish(pubGeneralTopic, "SetParameter;VCSGeneral_RampRate;" + rate.toString());
    }

    public void setKurtosis(String onOffSwitch){
        /*
        Enable or disable kurtosis
         */
        if(onOffSwitch.equals("on") || onOffSwitch.equals("1") || onOffSwitch.equals("yes") || onOffSwitch.equals("true")) publish(pubGeneralTopic, "SetParameter;KurParams_EnableKurt;True");
        else if (onOffSwitch.equals("off") || onOffSwitch.equals("0") || onOffSwitch.equals("no") || onOffSwitch.equals("false")) publish(pubGeneralTopic, "SetParameter;KurParams_EnableKurt;False");
    }

    public void setSamplingRate(Float rate){
        /*
        Set the sampling rate
         */
        publish(pubGeneralTopic, "SetParameter;VCSGeneral_SamplingRate;" + rate.toString());
    }

    public void generateReport(){
        /*
        Generate a report for the current test
         */
        publish(pubGeneralTopic, "GenerateReport");
    }

    /**
     * DSA Output Control
     */

    public void outputSine(Double amplitude, Integer frequency ){
        /*
        Output control
         */
        String outString = amplitude.toString()+";"+ frequency.toString();
        publish(pubDSATopic,  "SetOutputParameters;Sine;"+ outString);

    }

    public void outputDC(Integer amplitude){
        /*
        Output control
         */
        String outString = amplitude.toString();
        publish(pubDSATopic,"SetOutputParameters;DC;" + outString);
    }

    public void outputSweptSine(Integer amplitude, Integer lowFrequency, Integer highFrequency, Integer period){
        /*
        Output control
         */
        String outString = amplitude.toString() + ";" + lowFrequency.toString() + ";" +
                highFrequency.toString() + ";" + period.toString();
        publish(pubDSATopic, "SetOutputParameters;SweptSine;" + outString);
    }

    public void whiteNoise(Float RMS){
        /*
        Output control
         */
        String outString = RMS.toString() + ":";
        publish(pubDSATopic, "SetOutputParameters;WhiteNoise;" + outString);

    }


    /**
     * Get Signal Data
     */

    public void getApsRms(Integer chan){
        /*
        Get the RMS value of the APS  for channel number "chan"
         */
        publish(pubGeneralTopic, "RequestSignalProperty;RMS;APS(Ch"+ chan.toString()+ ")");
    }

    public void getAPS(Integer chan){
        /*
        Get the APS for channel number "chan"
         */
        publish(pubGeneralTopic, "RequestSignalData;APS(Ch" + chan.toString() + ")");

    }

    public void getChannelData(Integer chan){
        /*
        Get the time stream data of channel number "chan"
         */
        publish(pubGeneralTopic, "RequestSignalData;Ch"+ chan.toString());
    }


    /**
     * Getters
     */
    public HashMap<String, Object> getHm() {
        return hm;
    }

    public String getPrefix(){
        return prefix;
    }
}
