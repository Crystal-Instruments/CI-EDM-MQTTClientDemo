# EDM MQTT Protocol Client Demo

Crystal Instruments uses MQTT method to communicate to EDM and any other software applications running on the same network.

MQTT is an OASIS standard messaging protocol for the Internet of Things (IoT). It is designed as an extremely lightweight publish/subscribe messaging transport that is ideal for connecting remote devices with a small code footprint and minimal network bandwidth. 

By implementing MQTT in EDM, users can monitor status of environmental tests (vibration, temperature, humidity) run in EDM VCS and measurements taken in EDM DSA and even remotely run a test. 

Here is the EDM MQTT Publish/Subscribe Architecture. 

![](https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo/blob/main/images/CIEDMMQTTNetworkDiagram.png)

MQTT client can be

•	The MQTT Client in EDM (publisher) publishes test status and measurements to an MQTT broker

•	A software (subscriber) written by a user to subscribe to topic from an MQTT broker to get status and measurements from or send command to an EDM MQTT client

MQTT broker can be

•	The MQTT Broker in EDM communicates to MQTT clients (both publisher and subscriber)

•	A MQTT Broker hosted on the Internet by a third-party provider or on a LAN. 

EDM has built-in MQTT Client and MQTT Broker at the same time, available in EDM VCS, EDM DSA, and EDM THV. The built-in MQTT Client also supports the SparkplugTM specification, which can be enabled/disabled. 

Please refer to https://mqtt.org/ for MQTT technical content.

Please refer to https://sparkplug.eclipse.org/ for SparkplugTM specification.

In the following topics for the MQTT Broker and MQTT Client windows, these can be accessed via **Setup** and under **Extensions**. 

For more details on the MQTT in EDM, please refer to the **EDM MQTT Technical User Manual**.

<img src="https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo/blob/main/images/EDMMQTTBroker.png" alt="" width="600"/>
<img src="https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo/blob/main/images/EDMMQTTClient.png" alt="" width="600"/>
 
# Documentation

For more detailed information regarding the EDM MQTT Protocol Client, please refer the EDM MQTT Protocol Client Documentation that can be downloaded in this github repository and visit our website Programming Corner for helpful articles:

https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo/tree/main/Manuals

https://www.crystalinstruments.com/blog/2022/9/21/new-messaging-protocol-mqtt-client-and-mqtt-broker-for-edm-vcs-edm-dsa-and-edm-thv

https://www.crystalinstruments.com/programming-corner 
 
# EDM MQTT Protocol Client Demo Package Content

## Downloading and Installing

You can clone this repository or download the zip file via the green button.

```
git clone https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo.git
```

It is recommended to use a compatible version of Python for the **Paho MQTT** package.

The Python scripts also import **Matplotlib** and **Numpy**.

The LabVIEW example uses the MQTT package provided by **LabVIEW Open Source Project** and available to download via LabVIEW **VI Package Manager**.

## Demo Code

The EDM MQTT Protocol Client Demo are used in 3 coding languages:
- C#
- Python
- LabVIEW

The MQTT protocol can be used across many coding languages as long as there is proper support for it. As it is easier to learn and utilize the protocol with known EDM topics and commands listed in the manual.

For Python, it uses a package called Paho MQTT to utilize the MQTT protocol.

The below code block is how the EDM MQTT Python API script imports the Paho MQTT package:

```python
from paho.mqtt import client as mqtt_client
import numpy as np
```

The below code is how user level scripts imports the EDM MQTT Python API script and other Python packages:

```python
import mqtt
import time
import numpy as np
import datetime
import os
import matplotlib.pyplot as plt
```

For LabVIEW, it uses a MQTT package from LabVIEW Open Source Project for handling the MQTT protocol communication. Documentation for how to use the MQTT package in LabVIEW can be refered here:

https://github.com/LabVIEW-Open-Source/LV-MQTT-Broker/wiki

https://www.youtube.com/watch?v=Y-jrwyfD9DU

The LabVIEW demo block diagram is also available for reference.

## Manuals

Included with the demo code is a technical manual that can help users in understanding the various topics and commands used in EDM MQTT protocol.

There is a .pdf that provide an in-depth explanation and list of topics.

# License & Term Agreement

Linked below is the Crystal Instruments' End License Agreement for usage:

[Crystal Instruments End License Agreement](https://github.com/Crystal-Instruments/CI-EDM-MQTTClientDemo/blob/main/Crystal%20Instruments%20License.md)
