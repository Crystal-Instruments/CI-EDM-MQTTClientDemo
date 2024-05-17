"""
Copyright (C) 2024 by Crystal Instruments Corporation.
All rights reserved

MQTT Python Example - Running a Test and requesting a signal frame data
"""

from mqtt import EDM_mqtt_client
import time
import numpy as np
import datetime
import os
import matplotlib.pyplot as plt

# Connect to MQTT Broker
mqttClient = EDM_mqtt_client(verbose=False, topic_prefix="EDM", client_id="python client", brokerIP="192.168.1.82")
mqttClient.connect_mqtt()
mqttClient.run()

r = input("\nPress enter once pre-test is done")
# any other key followed by enter will exit, or ctrl-c will exit
if r != '':
    exit()

# Start test after pre-test
mqttClient.proceed()

signalFrame = []
count = 0
plt.ion()

try:
    while mqttClient.LUT.get(mqttClient.topic_prefix + '/App/Test/Status', {'Status': 'Stopped'})['Status'] != "Running":
        pass

    while mqttClient.LUT.get(mqttClient.topic_prefix + '/App/Test/Status', {'Status': 'Stopped'})['Status'] == "Running":
        # Request signal data, such as Channel 1
        mqttClient.get_channel_data(1)
        # Wait for receiving and parsing message
        #  Change time to receive data in real time or occasional updates
        time.sleep(0.01)
        # Refresh graph to view the current signal frame
        # or comment it out to have a time history graph of the signal
        plt.clf()

        ## Parsing the received message ##
        signalName = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["Signal"]["Name"]
        signalUnitX = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["Signal"]["UnitX"]
        signalUnitY = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["Signal"]["UnitY"]
        Xvalues = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["ValueX"]
        X = np.fromiter(Xvalues, float)

        Yvalues = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["ValueY"]
        Y = np.fromiter(Yvalues, float)

        Zvalues = mqttClient.LUT[mqttClient.topic_prefix + '/App/Test/SignalData']["ValueZ"]
        Z = np.fromiter(Zvalues, float)

        signalFrame.append(X)
        signalFrame.append(Y)
        # signalFrame.append(Z)

        thd = np.array(signalFrame, dtype=object)
        if thd[0].shape != thd[1].shape:
            continue

        plt.plot(thd[0], thd[1], 'r', label=signalName)
        plt.title("Signal Frame Data of " + signalName)
        plt.xlabel(signalUnitX)
        plt.ylabel(signalUnitY)
        plt.draw()
        # plt.savefig(savedirectory + "/"+signalName+"-plot"+str(count)+".png")
        plt.pause(0.001)

        count += 1
        signalFrame = []
        time.sleep(.1)

except KeyboardInterrupt:
    print('Keyboard Interrupt received -- exiting main loop')