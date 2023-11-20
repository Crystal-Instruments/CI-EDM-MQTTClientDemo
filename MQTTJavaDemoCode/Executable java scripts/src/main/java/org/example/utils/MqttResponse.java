package org.example.utils;

import org.eclipse.paho.client.mqttv3.MqttMessage;

public class MqttResponse {
    private String topic;
    private MqttMessage message;

    public MqttResponse() {
    }

    public MqttResponse(String topic, MqttMessage message) {
        this.topic = topic;
        this.message = message;
    }

    @Override
    public String toString() {
        return "MqttResponse{" +
                "topic='" + topic + '\'' +
                ", message=" + message +
                '}';
    }

    public String getTopic() {
        return topic;
    }

    public void setTopic(String topic) {
        this.topic = topic;
    }

    public MqttMessage getMessage() {
        return message;
    }

    public void setMessage(MqttMessage message) {
        this.message = message;
    }
}
