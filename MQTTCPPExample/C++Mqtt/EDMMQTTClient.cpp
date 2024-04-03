#include "mqtt_client.h"
#include "mqtt_protocol.h"
#include "hexport.h"
#include <iostream>
#include <fstream>
#include <filesystem>
#include <algorithm>
#include "decompress.hpp"
#include "AppTopics.h"

#define HV_EXPORT  __declspec(dllimport)

class EDMMQTTClient
{
public:
	hv::MqttClient client;

    EDMMQTTClient(std::string host, int port, std::string id, std::string topicPrefix, std::string username, std::string password) {
		this->client.setID(id.c_str());
        this->host = host;
        this->port = port;
        this->username = username;
        this->password = password;
        this->topicPrefix = topicPrefix;

        log.open("log.txt");

		this->client.setAuth(username.c_str(), password.c_str());
        initClientAsyncMethods();
	}

    void connect() {
        this->client.connect(this->host.c_str(), this->port);
    }

    void subscribe(std::string topic) {
        std::string topicAndPrefix = topicPrefix + "/" + topic;
        this->client.subscribe(topicAndPrefix.c_str());
    }

    void publish(std::string topic, std::string payload) {
        std::string topicAndPrefix(topicPrefix + "/" + topic);
        this->client.publish(topicAndPrefix, payload);
    }

    void run() {
        this->client.run();
    }

private:
    std::string host;
    int port;
    std::string topicPrefix;
    std::ofstream log;
    std::string username;
    std::string password;
	void initClientAsyncMethods() {
        client.onConnect = [](hv::MqttClient* cli) {

        };

        client.onMessage = [this](hv::MqttClient* cli, mqtt_message_t* msg) {
            if (msg->topic == nullptr) return;
            std::string topicAndPayload(msg->topic);
            std::string topic = topicAndPayload.substr(0, msg->topic_len);
            std::string topicWithUnderscore(topic);
            std::replace(topicWithUnderscore.begin(), topicWithUnderscore.end(), '/', '_');
            std::string payload(msg->payload);
            std::time_t now = std::time(NULL);
            std::string fileName = topicWithUnderscore + "_" + std::to_string(now) + ".txt";
            if (topic == topicPrefix + "/" + TOPIC_APP_TEST_COMPRESSED_SIGNALDATA) {
                payload  = gzip::decompress(msg->payload, msg->payload_len);
            }
            
            std::ofstream outfile;
            outfile.open("data/" + fileName);

            if (outfile.is_open()) {
                this->log << "Created file for topic: " << topic << std::endl;
                outfile << "Topic: " << topic << std::endl;
                outfile << "Payload Length: " << msg->payload_len << std::endl;
                outfile << "Payload: " << payload << std::endl;
                outfile.close();
            } else {
                this->log << "Unable to create file: " << fileName << std::endl;
            }
        };

        client.onClose = [](hv::MqttClient* cli) {

        };
	}
};
