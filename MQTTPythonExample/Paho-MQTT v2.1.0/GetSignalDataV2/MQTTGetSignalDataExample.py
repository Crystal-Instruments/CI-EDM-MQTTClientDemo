import tkinter
from matplotlib.backends.backend_tkagg import (
    FigureCanvasTkAgg)
from matplotlib.figure import Figure
from mqtt import EDM_mqtt_client
from app_topics import app_topics

mqttClient = EDM_mqtt_client(client_id="python client", topic_prefix="EDM", brokerIP="192.168.1.15", verbose=False)

win = tkinter.Tk()
win.title("MQTT Demo")
win.minsize(500,500)

def configure_connection():
    graph_frame = tkinter.Frame(win, width=500, height=500)
    graph_frame.pack(fill=tkinter.BOTH, expand=1)

    fig = Figure()
    ax = fig.add_subplot(1, 1, 1)
    ax.set_xscale('log')
    ax.set_xlabel("Frequency")
    lines = ax.plot()

    canvas = FigureCanvasTkAgg(fig, master=graph_frame)
    canvas.draw()
    canvas.get_tk_widget().pack(fill=tkinter.BOTH, expand=1)

    mqttClient.subscribe(app_topics.TOPIC_APP_TEST_SIGNALDATA)
    mqttClient.request_signal_data("APS(Ch1);APS(Ch2)")

    def plot_signals():
        nonlocal ax, lines, canvas
        global mqttClient

        def make_array_lengths_equal(arr1, arr2):
            while len(arr1) > len(arr2):
                arr1.pop()

            while len(arr2) > len(arr1):
                arr2.pop()

        sig1 = mqttClient.signal_data.get('APS(Ch1)', None)
        sig2 = mqttClient.signal_data.get('APS(Ch2)', None)

        if sig1 is None or sig2 is None:
            return

        for line in lines:
            line.remove()

        sig1_X = sig1['ValueX']
        sig1_Y = sig1['ValueY']

        sig2_X = sig2['ValueX']
        sig2_Y = sig2['ValueY']

        make_array_lengths_equal(sig1_X, sig1_Y)
        make_array_lengths_equal(sig2_X, sig2_Y)

        lines = ax.plot(sig1_X, sig1_Y, color='blue')
        lines.extend(ax.plot(sig2_X, sig2_Y, color='orange'))

        canvas.draw()
        mqttClient.request_signal_data("APS(Ch1);APS(Ch2)")

    mqttClient.signal_on_update = plot_signals

# Connect to MQTT Broker
mqttClient.user_on_connect = configure_connection
mqttClient.connect_mqtt()
win.mainloop()