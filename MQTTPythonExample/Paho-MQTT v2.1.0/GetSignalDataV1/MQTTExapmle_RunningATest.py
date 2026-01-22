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
from app_topics import *

# Connect to MQTT Broker
mqttClient = EDM_mqtt_client(client_id="python client", topic_prefix="EDM", brokerIP="192.168.1.15")
mqttClient.connect_mqtt()

while not mqttClient.connected:
    pass

mqttClient.run_test()

# Wait until the test is running
while mqttClient.status != 'Running':
    pass

mqttClient.publish(app_topics.TOPIC_APP_TEST_COMMAND, "RequestSignalData;APS(Ch1)")

while True:
    pass
