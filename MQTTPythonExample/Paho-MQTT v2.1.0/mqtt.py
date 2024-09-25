import threading
import time

from paho.mqtt import client as mqtt_client
from app_topics import *
import json


# This class defines the mqtt client interface that we will use to interact with EDM's broker.
class EDM_mqtt_client:
    def _loop_client(self):
        self.internal_client.loop_forever()

    def __init__(self, client_id, topic_prefix, debug=False, verbose=True, auto_connect=False, brokerIP="127.0.0.1",
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
        self.global_parameter_LUT = {}
        self.global_parameter_names = []
        self.freq_over_time = []
        self.full_level_over_time = []
        self.signal_data = []
        self.test_status_over_time = []
        self.drive_over_time = []
        self.topic_prefix = topic_prefix
        self.client_id = client_id
        self.internal_client = None
        self.connected = False
        self.status = ""
        self.timeout = 5
        self.verbose = verbose
        self.debug = debug

        self.subscribe_topics = [global_parameter_topics.TOPIC_GLOBAL_PARAMETER_RESPONSE,
                                 vcs_topics.TOPIC_VCS_TEST_SINE_STATUS,
                                 vcs_topics.TOPIC_VCS_TEST_RANDOM_STATUS,
                                 app_topics.TOPIC_APP_TEST_SIGNALDATA,
                                 app_topics.TOPIC_APP_TEST_STATUS]

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
            for topic in self.subscribe_topics:
                self.subscribe(topic)
            self.connected = True
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
            if msg.topic == self.add_topic_prefix(global_parameter_topics.TOPIC_GLOBAL_PARAMETER_RESPONSE):
                data = json.loads(msg.payload.decode())
                # If we do not have any of the global parameters yet, we should add them to our table
                if data['Item1'] == command_key.ListGlobalParameters:
                    self.global_parameter_names = data['Item2']
                else:
                    self.global_parameter_LUT[data['Item1']] = data['Item2']
            elif msg.topic == self.add_topic_prefix(
                    vcs_topics.TOPIC_VCS_TEST_SINE_STATUS) or msg.topic == self.add_topic_prefix(
                vcs_topics.TOPIC_VCS_TEST_RANDOM_STATUS):
                data = json.loads(msg.payload.decode())
                self.freq_over_time.append(data['Frequency'])
                self.full_level_over_time.append(data['FullLevelTime'])
                self.test_status_over_time.append(data)
            elif msg.topic == self.add_topic_prefix(app_topics.TOPIC_APP_TEST_SIGNALDATA):
                data = json.loads(msg.payload.decode())
                for signal in data:
                    self.signal_data.append(signal)
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

    def add_topic_prefix(self, value: str):
        if self.topic_prefix == "":
            return value

        return self.topic_prefix + '/' + value

    def reset_global_parameter(self, parameter: str):
        self.global_parameter_LUT[parameter] = None

    def request_global_parameter(self, parameter):
        self.reset_global_parameter(parameter)

        self.publish(global_parameter_topics.TOPIC_GLOBAL_PARAMETER_REQUEST, parameter)

        start_time = time.perf_counter()
        while self.global_parameter_LUT[parameter] is None:
            cur_time = time.perf_counter()
            if not self.debug and cur_time - start_time > self.timeout:
                raise Exception("Timeout: could not request global parameter")

        return self.global_parameter_LUT[parameter]

    def request_signal_data(self, channel):
        old_count = len(self.signal_data)
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, command_key.RequestSignalData + f";{channel}")

        start_time = time.perf_counter()
        while old_count == len(self.signal_data):
            cur_time = time.perf_counter()
            if not self.debug and cur_time - start_time > self.timeout:
                raise Exception("Timeout: could not request signal data")

        return self.signal_data

    def request_test_status(self):
        old_count = len(self.test_status_over_time)
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, command_key.RequestDetailStatus)

        start_time = time.perf_counter()
        # This ensures the test waits until we obtain the data we want
        while old_count == len(self.test_status_over_time):
            cur_time = time.perf_counter()
            if not self.debug and cur_time - start_time > self.timeout:
                raise Exception("Timeout: could not request test status")

        return self.test_status_over_time[-1]

    def run_test(self):
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, command_key.Run)

    def load_schedule(self, schedule_file):
        # This functionality may not be implemented yet
        with open(schedule_file, 'r') as schedule:
            schedule_as_string = ""
            lines = schedule.readlines()
            for line in lines:
                schedule_as_string += line
            self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, command_key.SetSchedule + f";{schedule_as_string}")
