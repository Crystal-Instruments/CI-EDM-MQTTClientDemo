package org.example.messages;


public class MqttDeviceModule {
    public String IPAdress;
    public String SerialNumber;
    public String DeviceType;

    @Override
    public String toString() {
        return "MqttDeviceModule{" +
                "IPAdress='" + IPAdress + '\'' +
                ", SerialNumber='" + SerialNumber + '\'' +
                ", DeviceType='" + DeviceType + '\'' +
                ", Version='" + Version + '\'' +
                '}';
    }

    public String Version;
    public MqttDeviceModule(){

    }
}
