package org.example.messages;

import java.util.List;

public class MqttRunFolder {
    public String RunName;
    public String RunPath;
    public List<String> RunFiles;
    public MqttRunFolder(){

    }

    public MqttRunFolder(String runName, String runPath, List<String> runFiles) {
        RunName = runName;
        RunPath = runPath;
        RunFiles = runFiles;
    }
}
