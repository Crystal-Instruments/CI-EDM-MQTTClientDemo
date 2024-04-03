#include "EDMMQTTClient.cpp"
#include <iostream>
#include <thread>
#include <string>
#include <algorithm>
#include "AppTopics.h"

using namespace std;

void StartThread(EDMMQTTClient *client) {
    client->run();
}

char asciiToLower(char in) {
    if (in <= 'Z' && in >= 'A')
        return in - ('Z' - 'z');
    return in;
}

int main() {
    setlocale(LC_ALL, "en_US.UTF-8");

    string host;
    int port;
    string username;
    string password;
    string topicPrefix;

    cout << "Please enter host: ";
    cin >> host;
    cout << "Please enter port: ";
    cin >> port;
    cout << "Please enter username: ";
    cin >> username;
    cout << "Please enter password: ";
    cin >> password;
    cout << "Please enter topic prefix: ";
    cin >> topicPrefix;

    EDMMQTTClient cli(host, port, "C++ MQTT Demo", topicPrefix, username, password);
    cli.connect();
    thread t1(StartThread, &cli);

    cout << "Waiting for connection to host " << host << ":" << port << endl;

    while (!cli.client.isConnected()) ;

    cout << "Connected!" << endl;
    
    // We need to subscribe to the signal data topic to get the 
    // signal data messages
    cli.subscribe(TOPIC_APP_TEST_COMPRESSED_SIGNALDATA);
    cli.subscribe(TOPIC_APP_TEST_SIGNALDATA);

    while (true) {
        string input = "";
        cout << "The commands you can perform are: Run (Runs Current Test), Stop (Stops Current Test), Get (Gets Signal Data), Publish (Publishes a Topic and Payload), Subscribe (Subscribes to a Topic), and Exit (Exits Program). Please type the action you want to perform." << endl;;
        cin >> input;
        transform(input.begin(), input.end(), input.begin(), asciiToLower);
        if (input == "exit") {
            break;
        } else if (input == "run") {
            // The commands that you can publish are in the AppTopics.h folder
            cli.publish(TOPIC_VCS_TEST_COMMAND, "Run");
        }
        else if (input == "stop") {
            cli.publish(TOPIC_VCS_TEST_COMMAND, "Stop");
        }
        else if (input == "get") {
            cli.publish(TOPIC_VCS_TEST_COMMAND, "RequestSignalData;APS(Ch1)");
        }
        else if (input == "publish") {
            string topic = "", payload = "";
            cout << "Please enter the publish topic: ";
            cin >> topic;
            cout << "Please enter the payload: ";
            cin >> payload;
            cli.publish(topic, payload);
        }
        else if (input == "subscribe") {
            string topic = "";
            cout << "Please enter the subscribe topic: ";
            cin >> topic;
            cli.subscribe(topic);
        }
        else {
            cout << "Command: " << input << " not available." << endl;
        }
    }
    t1.join();
    return 0;
}
