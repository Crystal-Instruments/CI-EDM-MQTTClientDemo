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
mqttClient = mqtt.pubsub(brokerIP = "192.168.1.15")
mqttClient.subclient.loop_start()

# initial sleep is needed to get system status messages
time.sleep(2)

softwareMode = mqttClient.LUT['EDM/App/Status'].split("SoftwareMode")[1].split(",")[0][3:-1]
serialnumber = mqttClient.LUT['EDM/App/System'].split("SerialNumber")[1].split(",")[0][3:-1]
devicetype   = mqttClient.LUT['EDM/App/System'].split("DeviceType")[1].split(",")[0][3:-1]

testStatus = mqttClient.LUT['EDM/App/Test/Status'].split("Status")[1].split(",")[0][3:-1]

signalFrame = []
count = 0
plt.ion()

try:
    while(testStatus == "Running"):
        # Request signal data, such as Channel 1
        mqttClient.get_channel_data(1)
        # Wait for receiving and parsing message
        #  Change time to receive data in real time or occasional updates
        time.sleep(0.01) 
        # Refresh graph to view the current signal frame 
        # or comment it out to have a time history graph of the signal
        plt.clf()

        ## Parsing the received message ##
        signalName = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[0].split("Name")[1].split(",")[0][3:-1]
        signalUnitX = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[0].split("UnitX")[1].split(",")[0][3:-1]
        signalUnitY = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[0].split("UnitY")[1].split(",")[0][3:-1]

        Xvalues = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[1].split("ValueY")[0].split("ValueZ")[0][3:-3]
        X = Xvalues.split(",")
        X = np.fromiter(X, float)

        Yvalues = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[1].split("ValueY")[1].split("ValueZ")[0][3:-3]
        Y = Yvalues.split(",")
        Y = np.fromiter(Y, float)

        Zvalues = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[1].split("ValueY")[1].split("ValueZ")[1].split("XSequenceType")[0][3:-3]
        Z = Zvalues.split(",")
        Z = np.fromiter(Z, float)

        signalFrame.append(X)
        signalFrame.append(Y)
        # signalFrame.append(Z)

        thd = np.array(signalFrame)
        
        plt.plot(thd[0], thd[1], 'r', label=signalName)
        plt.title("Signal Frame Data of " + signalName)
        plt.xlabel(signalUnitX)
        plt.ylabel(signalUnitY)
        plt.draw()
        # plt.savefig(savedirectory + "/"+signalName+"-plot"+str(count)+".png")
        plt.pause(0.001)

        count += 1
        signalFrame = []

        testStatus = mqttClient.LUT['EDM/App/Test/Status'].split("Status")[1].split(",")[0][3:-1]

except KeyboardInterrupt:
    print('Keyboard Interrupt received -- exiting main loop')

# For any interruption from the python script, stop the test
# mqttClient.stop()

try:
    mqttClient.subclient.loop_stop()
    print("MQTT loop stopped successfully")
except:
    print("Failed to stop subscriber loop")