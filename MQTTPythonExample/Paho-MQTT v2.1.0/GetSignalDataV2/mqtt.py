import threading
import time

from paho.mqtt import client as mqtt_client
from app_topics import *
import json


# This class defines the mqtt client interface that we will use to interact with EDM's broker.
class EDM_mqtt_client:
    def _loop_client(self):
        self.internal_client.loop_forever()

    def __init__(self, client_id, topic_prefix, verbose=True, auto_connect=False, brokerIP="127.0.0.1",
                 port=1883,
                 username='Admin', password='123456'):
        """
        Initialize method
        Set up variables and client
        """
        # Setup variables that are common to client
        self.broker = brokerIP
        self.port = port
        self.username = username
        self.password = password
        self.topic_prefix = topic_prefix
        self.client_id = client_id
        self.verbose = verbose
        self.signal_data = {}
        self.signal_on_update = None
        self.user_on_connect = None
        self.internal_client = None
        self.connected = False

    def connect_mqtt(self):
        """
        Connects MQTT broker/client
        """
        # Set Connecting Client ID
        client = mqtt_client.Client(client_id=self.client_id,
                                    callback_api_version=mqtt_client.CallbackAPIVersion.VERSION2)
        client.username_pw_set(self.username, self.password)
        client.on_connect = self.on_connect
        client.on_message = self.on_message
        self.internal_client = client
        client.connect(self.broker, self.port)
        client_thread = threading.Thread(target=self._loop_client, args=(), daemon=True)
        client_thread.start()

    def add_topic_prefix(self, value: str):
        if self.topic_prefix == "":
            return value

        return self.topic_prefix + '/' + value

    def publish(self, pubtopic, msg):
        """
        Publishes a topic to EDM broker
        """
        # msg = f"messages: {msg_count}"
        result = self.internal_client.publish(self.add_topic_prefix(pubtopic), msg)
        # result: [0, 1]
        status = result[0]
        if status == 0:
            if self.verbose:
                print(f"Sending '{msg}' to topic '{pubtopic}'")
        else:
            print(f"Failed to send message to topic {pubtopic}")

    def on_connect(self, client, userdata, flags, rc, properties):
        """
        Informs the user about a successful or unsuccessful connection
        """
        if rc == 0:
            if self.verbose:
                print("Connected to MQTT Broker!")
            self.connected = True
            if self.user_on_connect is not None:
                self.user_on_connect()
        else:
            print("Failed to connect, return code %d\n", rc)

    def on_message(self, client, userdata, msg):
        """
        Handles receiving a message from EDM
        """
        # print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        if self.verbose:
            print(f"Received message from '{msg.topic}' topic")
        try:
            if msg.topic == self.add_topic_prefix(app_topics.TOPIC_APP_TEST_SIGNALDATA):
                data = json.loads(msg.payload.decode())
                for signal in data:
                    signal_name = signal['Signal']['Name']
                    self.signal_data[signal_name] = signal
                if self.signal_on_update is not None:
                    self.signal_on_update()
            elif msg.topic == self.add_topic_prefix(app_topics.TOPIC_APP_TEST_STATUS):
                data = json.loads(msg.payload.decode())
                self.status = data['Status']
        except Exception as exception:
            print(exception)

    def subscribe(self, topic):
        """
        Subscribe to EDM topics
        """
        self.internal_client.subscribe(self.add_topic_prefix(topic))

    def request_signal_data(self, channel):
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, f"{command_key.RequestSignalData};{channel}")

    def run_test(self):
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Run)
