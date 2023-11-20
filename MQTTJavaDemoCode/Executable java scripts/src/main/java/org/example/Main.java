package org.example;

import com.github.sh0nk.matplotlib4j.PythonExecutionException;
import org.eclipse.paho.client.mqttv3.MqttException;
import org.example.tests.RunningTestEx;
import org.example.tests.ThdTestEx;

import java.io.IOException;

public class Main {
    public static void main(String[] args) throws MqttException, IOException, InterruptedException, PythonExecutionException {
        RunningTestEx.runTest();
        //ThdTestEx.runTest();


    }
}