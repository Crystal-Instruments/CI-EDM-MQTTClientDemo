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
mqttClient = EDM_mqtt_client(client_id="python client", topic_prefix="EDM", brokerIP="192.168.1.15")
mqttClient.connect_mqtt()

while not mqttClient.connected:
    pass

mqttClient.run_test()

# Wait until the test is running
while mqttClient.status != 'Running':
    pass

# Turn on interactive plots
plt.ion()

while mqttClient.status != 'Stopped':
    # Get the most up-to-date signal data
    mqttClient.request_signal_data('Ch1')
    signal = mqttClient.signal_data[-1]
    plt.clf()
    X = signal['ValueX']
    Y = signal['ValueY']

    if len(X) != len(Y):
        while len(X) > len(Y):
            X.pop()

        while len(Y) > len(X):
            Y.pop()

    plt.plot(X, Y)
    plt.draw()
    plt.pause(.001)
    pass

