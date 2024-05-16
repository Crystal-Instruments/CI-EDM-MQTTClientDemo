"""
Copyright (C) 2022 by Crystal Instruments Corporation.
All rights reserved

Automated THD measurement with MQTT
"""

import mqtt
import time
import numpy as np
import datetime
import os
import matplotlib.pyplot as plt
from tqdm import tqdm

def computeTHD(x):
    '''
    simple function to compute THD from a list or array of amplitudes
    input must be in decibels
    '''
    y = np.array(x) - x[0] 
    g = 10**(y/20.0) 
    return 20*np.log10(np.sqrt(np.sum(g[1:]**2))) 

mqttClient = mqtt.pubsub(brokerIP = "192.168.3.15")
mqttClient.subclient.loop_start()
# initial sleep is needed to get system status messages
time.sleep(2)

# define ranges for frequencies and amplitudes as list
freqs = [freq*1000 for freq in range(1,4)]
amps  = [amp*0.1   for amp  in range(1,11)]
# or define custom ranges
freqstep = 250
minfreq  = 1000
maxfreq  = 10000
freqs    = np.arange(minfreq,maxfreq + freqstep,freqstep)
amps  = [8.92, 5, 2, 1]

# low frequencies need larger block size - also low frequency noise affects spec
#freqs = np.concatenate(([50,100,200], freqs))

# Get date to use it for folder name
now = datetime.datetime.now()
dt_string = now.strftime("%Y-%m-%d--%H-%M")

serialnumber = mqttClient.LUT['EDM/App/System'].split("SerialNumber")[1].split(",")[0][3:-1]
devicetype   = mqttClient.LUT['EDM/App/System'].split("DeviceType")[1].split(",")[0][3:-1]

savedirectory = "THD-" + devicetype + "-" + serialnumber + "-" + dt_string

# 'dir' is windows equivalent of 'ls' on linux, lists files in the directory
r = os.system("dir " + savedirectory)
# if the directory does not exist, r will be 1 - create it before continuing
if r == 1:
    os.system("mkdir " + savedirectory)


# Estimate time it will take based on sleeps (15 seconds) and num of freqs/amps
timetocomplete = 15*len(freqs)*len(amps)
if timetocomplete > 60:
    if timetocomplete/60 > 60:
        print("Estimate of time required to complete:", timetocomplete/3600, "hours")
    print("Estimate of time required to complete:", timetocomplete/60, "minutes")
else:
    print("Estimate of time required to complete:", timetocomplete, "seconds")


numharmonics = 25
suffix = ''
if numharmonics == 2:
    suffix += 'nd'
elif numharmonics == 3:
    suffix += 'rd'
else:
    suffix += 'th'

r = input("\nPress enter to begin THD measurement up to " + str(numharmonics) + suffix + " harmonic\n")
# any other key followed by enter will exit, or ctrl-c will exit
if r != '':
    exit()

print("THD measurement for " + devicetype + "-" + serialnumber + " has started\n")
# Connect and run a EDM test
mqttClient.connect()
mqttClient.run()
time.sleep(2)
mqttClient.output_toggle('on')
thd = []

try:
    for freq in tqdm(freqs):
        print() # make a new line after tqdm progress bar
        for amp in amps:
            print(str(amp), "Volts at", str(freq), "Hz")
            mqttClient.output_sine(amp,freq)
            time.sleep(5) 
            mqttClient.reset_average()
            time.sleep(5)
            # After inner loop has settled/paused, get APS
            mqttClient.get_APS(1) # Publisher message
            # Need another sleep between requesting message and receiving
            time.sleep(5)
    
            # parsing the received message
            Yvalues = mqttClient.LUT['EDM/App/Test/SignalData'].split("ValueX")[1].split("ValueY")[1].split("ValueZ")[0][3:-3]
            Y = Yvalues.split(",")
            harms = []
            # go up to numharmonics or less, depending on frequency
            for harmonic in range(min(int(mqttClient.freqrange / freq), numharmonics)):
                i = int(freq / mqttClient.freqresolution) * (harmonic + 1)
                x = float(Y[i])
                harms.append(x)
            thd.append( [freq, amp, computeTHD(harms)] )

except KeyboardInterrupt:
    print('Keyboard Interrupt received -- exiting main loop')

columnlabelstring = "Frequency (Hz) || Amplitude (Volts) || THD (db)"
print("\n" + " " * (len(columnlabelstring)//4) + "THD Measurement Results\n" + "-" * len(columnlabelstring))
print(columnlabelstring)


# nspace1 = len("Frequency (Hz)")//2 
# nspace2 = len("Amplitude (Volts) ")//2
# nspace3 = len("THD (db)")//2
# just do it like this for now
nspace1 = 5
nspace2 = 11
nspace3 = 13

for a in thd:
    # Formatting with spaces to print out nicely
    # +3 is for 3 symbols (100 Hz assumed to be minimum, +2 if 20 Hz)
    # +1 is for min symbols for volts
    print(" "*nspace1, a[0], " "*(nspace2 + 3 - len(str(a[0]))), a[1], " "*(nspace3 + 1 - len(str(a[1]))), "{:.2f}".format(a[2]))

## Save data to .npy files
thd = np.array(thd)
np.save(savedirectory + "/fullmatrix.npy", thd)
# Save individual slices too
np.save(savedirectory + "/frequencies.npy", thd[:,0])
np.save(savedirectory + "/amplitudes.npy", thd[:,1])
np.save(savedirectory + "/thd.npy", thd[:,2])

print("-" * len(columnlabelstring) + "\nSaved .npy files to", savedirectory)


# Generate plot 
# horizontal axis is frequency, vertical axis is thd
# multiple lines drawn for each input amplitude
plt.rcParams.update({'font.size': 22})
plt.figure(figsize=(12,8))
numamps = len(amps)
legend = []
for i in range(numamps):
    freqs    = thd[:,0][i::numamps]
    dbthd    = thd[:,2][i::numamps]
    inputamp = thd[:,1][i::numamps][0] 
    legend.append(str(inputamp) + " V")
    plt.plot(freqs, dbthd, linewidth=4)

plt.xlabel("Frequency (Hz)")
plt.ylabel("THD (db)")
plt.title("THD vs. Frequency and input amplitudes")
plt.legend(legend)
plt.savefig(savedirectory + "/thdplot.png")
plt.show()


try:
    mqttClient.subclient.loop_stop()
    print("MQTT loop stopped successfully")
except:
    print("Failed to stop subscriber loop")