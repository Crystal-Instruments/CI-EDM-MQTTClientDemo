import threading
import time

from paho.mqtt import client as mqtt_client
from app_topics import *
import json


# This class defines the mqtt client interface that we will use to interact with EDM's broker.
class EDM_mqtt_client:
    def _loop_client(self):
        self.internal_client.loop_forever()

    def __init__(self, client_id, topic_prefix, debug=False, verbose=True, timeout=5,  auto_connect=False, brokerIP="127.0.0.1",
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

        self.LUT = {}

        self.topic_prefix = topic_prefix
        self.client_id = client_id

        self.internal_client = None
        self.connected = False
        self.status = ""
        self.timeout = timeout
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
            data_string = msg.payload.decode()
            try:
                data = json.loads(data_string)
                if isinstance(data, list):
                    data = data[0]
                self.LUT[msg.topic] = data
            except Exception as exception:
                self.LUT[msg.topic] = data_string
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

    def connect(self):
        '''
        Connect to the Spider
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Connect)

    def disconnect(self):
        '''
        Disconnect from the Spider
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Disconnect)

    def run(self):
        '''
        Run the test
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Run)

    def stop(self):
        '''
        Stop the current test
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Stop)

    def cont(self):
        '''
        Continue the current test
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Continue)

    def pause(self):
        '''
        Pause the current test
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, command_key.Pause)

    def proceed(self):
        '''
        Proceed with test after pretest
        '''
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, 'Proceed')

    def reset_average(self):
        '''
        Reset the APS averaging
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'ResetAverage')

    ###########################################################################
    ## Output Control
    ###########################################################################

    def output_toggle(self, onoffswitch):
        '''
        Toggle the output channel on/off
        Input can be 0 or 1 as an int or a string
        Can also input string 'on' or 'off' to be more explicit
        '''
        # Convert int to str and convert to lowercase if already str
        onoffswitch = str(onoffswitch).lower()

        if onoffswitch in ['on', '1', 'yes', 'true']:
            self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, 'OutputOn')

        elif onoffswitch in ['off', '0', 'no', 'false']:
            self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, 'OutputOff')

    def set_frequency(self, freq):
        '''
        Set frequency of output channel
        '''
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, 'SetFrequency;' + str(freq))

    def set_level(self, percent):
        '''
        Set level of output channel in percent
        '''
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, 'SetLevel;' + str(percent))

    def hold_sweep(self):
        '''
        Hold/pause the sweep in VCS
        '''
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, 'HoldSweep')

    def release_sweep(self):
        '''
        Release/continue the sweep in VCS
        '''
        self.publish(vcs_topics.TOPIC_VCS_TEST_COMMAND, 'ReleaseSweep')

    def set_abort_sensitivity(self, sens):
        '''
        Set the abort sensitivity
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'SetParameter;VCSGeneral_AbortSensitivity;' + str(sens))

    def set_ramp_rate(self, rate):
        '''
        Set the ramp rate
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'SetParameter;VCSGeneral_RampRate;' + str(rate))

    def set_kurtosis(self, onoffswitch):
        '''
        Enable or disable Kurtosis
        '''
        onoffswitch = str(onoffswitch).lower()

        if onoffswitch in ['on', '1', 'yes', 'true']:
            self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'SetParameter;KurParams_EnableKurt;True')

        elif onoffswitch in ['off', '0', 'no', 'false']:
            self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'SetParameter;KurParams_EnableKurt;False')

    def set_sampling_rate(self, rate):
        '''
        set the sampling rate
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'SetParameter;VCSGeneral_SamplingRate;' + str(rate))

    def generate_report(self):
        '''
        Generate a report for the current test
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'GenerateReport')

    ###########################################################################
    ## DSA output control
    ###########################################################################

    def output_sine(self, amplitude, frequency):
        '''
        Output control
        '''
        outstring = str(amplitude) + ";" + str(frequency) + ""
        self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, "SetOutputParameters;Sine;" + outstring)

    def output_DC(self, amplitude):
        '''
        Output control
        '''
        outstring = str(amplitude)
        self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, "SetOutputParameters;DC;" + outstring)

    def output_swept_sine(self, amplitude, lowfrequency, highfrequency, period):
        '''
        Output control
        '''
        outstring = str(amplitude) + ";" + str(lowfrequency) + ";" \
                    + str(highfrequency) + ";" + str(period)
        self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, "SetOutputParameters;SweptSine;" + outstring)

    def white_noise(self, RMS):
        '''
        Output control
        '''
        outstring = str(RMS) + ";"
        self.publish(dsa_topics.TOPIC_DSA_TEST_COMMAND, "SetOutputParameters;WhiteNoise;" + outstring)

    ###########################################################################
    ## Get Signal data
    ###########################################################################

    def get_APS_RMS(self, chan):
        '''
        Get the RMS value of the APS for channel number 'chan'
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'RequestSignalProperty;RMS;APS(Ch' + str(chan) + ')')

    def get_APS(self, chan):
        '''
        Get the APS for channel number 'chan'
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'RequestSignalData;APS(Ch' + str(chan) + ')')

    def get_channel_data(self, chan):
        '''
        Get the time stream data of channel number 'chan'
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'RequestSignalData;Ch' + str(chan))

    def get_2channel_data(self, chan, chan2):
        '''
        Get the time stream data of channel number 'chan'
        '''
        self.publish(app_topics.TOPIC_APP_TEST_COMMAND, 'RequestSignalData;Ch' + str(chan) + ';Ch' + str(chan2))