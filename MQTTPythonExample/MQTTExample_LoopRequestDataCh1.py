"""
Copyright (C) 2022 by Crystal Instruments Corporation.
All rights reserved

MQTT Python Example - Running a Test and requesting a signal frame data
"""

import mqtt
import time
import numpy as np
import datetime
import os
import matplotlib.pyplot as plt

# Connect to MQTT Broker
mqttClient = mqtt.pubsub(brokerIP = "127.0.0.1")
mqttClient.subclient.loop_start()

# initial sleep is needed to get system status messages
time.sleep(2)

softwareMode = mqttClient.LUT['EDM/App/Status'].split("SoftwareMode")[1].split(",")[0][3:-1]
serialnumber = mqttClient.LUT['EDM/App/System'].split("SerialNumber")[1].split(",")[0][3:-1]
devicetype   = mqttClient.LUT['EDM/App/System'].split("DeviceType")[1].split(",")[0][3:-1]

testStatus = mqttClient.LUT['EDM/App/Test/Status'].split("Status")[1].split(",")[0][3:-1]

try:
    while(testStatus == "Running"):
        # Request signal data, such as Channel 1
        mqttClient.get_channel_data(1)
        # Wait for receiving and parsing message
        #  Change time to receive data in real time or occasional updates
        time.sleep(1) 

        testStatus = mqttClient.LUT['EDM/App/Test/Status'].split("Status")[1].split(",")[0][3:-1]

except KeyboardInterrupt:
    print('Keyboard Interrupt received -- exiting main loop')

# For any interruption from the python script, stop the test
mqttClient.stop()

try:
    mqttClient.subclient.loop_stop()
    print("MQTT loop stopped successfully")
except:
    print("Failed to stop subscriber loop")