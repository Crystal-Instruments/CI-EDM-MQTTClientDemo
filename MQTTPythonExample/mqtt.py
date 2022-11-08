"""
Copyright (C) 2022 by Crystal Instruments Corporation.
All rights reserved

New version of mqtt to edm
Use a class and integrate publisher and subscriber

"""

from paho.mqtt import client as mqtt_client
import numpy as np

class pubsub():
    """
    Initialize method
    Set up variables, publisher, subscriber, topics, connect clients
    """
    def __init__(self, brokerIP="127.0.0.1", port=1883, username='Admin', password='123456'): 
        
        # Setup variables that are common to pub and sub
        self.broker = brokerIP
        self.port = port
        self.username = username
        self.password = password

        # Setup publisher
        self.pubgeneraltopic = "EDM/App/Test/Command"
        self.pubVCStopic = "EDM/VCS/Test/Command"
        self.pubDSAtopic = "EDM/DSA/Test/Command"
        self.pubclient_id = 'python publisher'
        
        # Setup subscriber
        # There can be multiple subscriber topics
        self.subtopics = ["EDM/App/Test/SignalData",
                          "EDM/VCS/Test/SineStatus",
                          "EDM/App/Message",
                          "EDM/DSA/Test/SignalData",
                          "EDM/DSA/Test/DSAStatus",
                          "EDM/App/System/Status",
                          "EDM/App/System",
                          "EDM/App/Status",
                          "EDM/App/Test/Status"]
        
        self.subclient_id = 'python subscriber'

        # Connect subscriber and publisher
        # Should this be handled in main script? maybe
        self.pubclient = self.connect_mqtt(self.pubclient_id)    
        self.subclient = self.connect_mqtt(self.subclient_id)
        self.subscribe(self.subtopics)
        
        self.data = 0
        # Look Up Table (LUT)
        # Lookup table / dictionary handles storing multi-topic data
        # Topic string is the key, data stored in value
        self.LUT = {}
        self.blocksize = 2048
        self.samplerate = 102400
        self.freqrange = self.samplerate * 0.44
        self.freqresolution = 2
        self.freqs = []
        self.initLUT = False
        self.amplitudes = np.zeros((self.blocksize))
                
        self.verbose = False
        
    """
    Connects MQTT broker/client
    """
    def connect_mqtt(self, client_id):
        '''
        Input client_id to have one fxn for both sub and pub
        '''
        def on_connect(client, userdata, flags, rc):
            if rc == 0:
                if self.verbose:
                    print("Connected to MQTT Broker!")
            else:
                print("Failed to connect, return code %d\n", rc)
        # Set Connecting Client ID
        client = mqtt_client.Client(client_id)
        client.username_pw_set(self.username, self.password)
        client.on_connect = on_connect
        client.connect(self.broker, self.port)
        return client
    
    """
    Publishes a topic to EDM broker
    """
    def publish(self, pubtopic, msg):
        #msg = f"messages: {msg_count}"
        result = self.pubclient.publish(pubtopic, msg)
        # result: [0, 1]
        status = result[0]
        if status == 0:
            if self.verbose:
                print(f"Sending '{msg}' to topic '{pubtopic}'")
        else:
            print(f"Failed to send message to topic {pubtopic}")
    
    """
    Handles receiving a message from EDM 
    """
    def on_message(self, client, userdata, msg):
        #print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        if self.verbose:
            print(f"Received message from '{msg.topic}' topic")
        self.data = msg.payload.decode()
        self.LUT.update({f"{msg.topic}" : self.data})
  
        if not self.initLUT:
            try:
                self.blocksize = int(self.LUT['EDM/App/Test/SignalData'].split("ValueX")[0].split("BlockSize")[1].split(",")[0][2:])
                self.samplerate = float(self.LUT['EDM/App/Test/SignalData'].split("ValueX")[0].split("SamplingRate")[1].split(",")[0][2:-1])
                self.freqrange = self.samplerate * 0.44
                self.freqresolution = self.samplerate / self.blocksize / 2
                self.freqs = [i*self.freqresolution for i in range(self.blocksize)]
                self.amplitudes = np.zeros((self.blocksize))
                self.initLUT = True
                if self.verbose:
                    print("LUT initialized successfully")
            except KeyError:
                if self.verbose:
                    print("Key does not exist yet")
    
    """
    Subscribe to EDM topics
    """
    def subscribe(self, topics):
        for topic in topics:
            self.subclient.subscribe(topic)
        self.subclient.on_message = self.on_message
        
        
    ###########################################################################
    ## EDM Functions
    ###########################################################################
    
    def connect(self):
        '''
        Connect to the Spider
        '''
        self.publish(self.pubgeneraltopic, 'Connect')
    
    def disconnect(self):
        '''
        Disconnect from the Spider
        '''
        self.publish(self.pubgeneraltopic, 'Disconnect')
    
    def run(self):
        '''
        Run the test
        '''
        self.publish(self.pubgeneraltopic, 'Run')
    
    def stop(self):
        '''
        Stop the current test
        '''
        self.publish(self.pubgeneraltopic, 'Stop')
    
    def cont(self):
        '''
        Continue the current test
        '''
        self.publish(self.pubgeneraltopic, 'Continue')
    
    def pause(self):
        '''
        Pause the current test
        '''
        self.publish(self.pubgeneraltopic, 'Pause')
    
    def proceed(self):
        '''
        Proceed with test after pretest
        '''
        self.publish(self.pubVCStopic, 'Proceed')

    def reset_average(self):
        '''
        Reset the APS averaging
        '''
        self.publish(self.pubgeneraltopic, 'ResetAverage')
    
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
            self.publish(self.pubDSAtopic, 'OutputOn')
            
        elif onoffswitch in ['off', '0', 'no', 'false']:
            self.publish(self.pubDSAtopic, 'OutputOff')
    
    
    def set_frequency(self, freq):
        '''
        Set frequency of output channel
        '''
        self.publish(self.pubVCStopic, 'SetFrequency;' + str(freq))
        
        
    def set_level(self, percent):
        '''
        Set level of output channel in percent
        '''
        self.publish(self.pubVCStopic, 'SetLevel;' + str(percent))
        
        
    def hold_sweep(self):
        '''
        Hold/pause the sweep in VCS
        '''
        self.publish(self.pubVCStopic, 'HoldSweep')
        
    
    def release_sweep(self):
        '''
        Release/continue the sweep in VCS
        '''
        self.publish(self.pubVCStopic, 'ReleaseSweep')
        
        
    def set_abort_sensitivity(self, sens):
        '''
        Set the abort sensitivity
        '''
        self.publish(self.pubgeneraltopic, 'SetParameter;VCSGeneral_AbortSensitivity;' + str(sens))
    
    def set_ramp_rate(self, rate):
        '''
        Set the ramp rate
        '''
        self.publish(self.pubgeneraltopic, 'SetParameter;VCSGeneral_RampRate;' + str(rate))
    
    
    def set_kurtosis(self, onoffswitch):
        '''
        Enable or disable Kurtosis
        '''
        onoffswitch = str(onoffswitch).lower()
        
        if onoffswitch in ['on', '1', 'yes', 'true']:
            self.publish(self.pubgeneraltopic, 'SetParameter;KurParams_EnableKurt;True')
            
        elif onoffswitch in ['off', '0', 'no', 'false']:
            self.publish(self.pubgeneraltopic, 'SetParameter;KurParams_EnableKurt;False')
    
        
    def set_sampling_rate(self, rate):
        '''
        set the sampling rate
        '''
        self.publish(self.pubgeneraltopic, 'SetParameter;VCSGeneral_SamplingRate;' + str(rate))
        
    
    def generate_report(self):
        '''
        Generate a report for the current test
        '''
        self.publish(self.pubgeneraltopic, 'GenerateReport')
    
    
    ###########################################################################
    ## DSA output control
    ###########################################################################

    def output_sine(self, amplitude, frequency):
        '''
        Output control
        '''
        outstring = str(amplitude) + ";" + str(frequency) + ""
        self.publish(self.pubDSAtopic, "SetOutputParameters;Sine;" + outstring)

    def output_DC(self, amplitude):
        '''
        Output control
        '''
        outstring = str(amplitude)
        self.publish(self.pubDSAtopic, "SetOutputParameters;DC;" + outstring)
    
    def output_swept_sine(self, amplitude, lowfrequency, highfrequency, period):
        '''
        Output control
        '''
        outstring = str(amplitude) + ";" + str(lowfrequency) + ";" \
                  + str(highfrequency) + ";" + str(period)
        self.publish(self.pubDSAtopic, "SetOutputParameters;SweptSine;" + outstring)
    
    def white_noise(self, RMS):
        '''
        Output control
        '''
        outstring = str(RMS) + ";"
        self.publish(self.pubDSAtopic, "SetOutputParameters;WhiteNoise;" + outstring)
    


    
    ###########################################################################
    ## Get Signal data
    ###########################################################################
    
    def get_APS_RMS(self, chan):
        '''
        Get the RMS value of the APS for channel number 'chan'
        '''
        self.publish(self.pubgeneraltopic, 'RequestSignalProperty;RMS;APS(Ch' + str(chan) + ')')
    

    def get_APS(self, chan):
        '''
        Get the APS for channel number 'chan'
        '''
        self.publish(self.pubgeneraltopic, 'RequestSignalData;APS(Ch' + str(chan) + ')')
    
    
    def get_channel_data(self, chan):
        '''
        Get the time stream data of channel number 'chan'
        '''
        self.publish(self.pubgeneraltopic, 'RequestSignalData;Ch' + str(chan))
    
        