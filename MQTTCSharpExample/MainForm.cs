using MQTTExample.Properties;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Newtonsoft.Json.Linq;

namespace MQTTCSharpExample
{
    public partial class MainForm : Form
    {
        EDMMQTTClient Client { get; } = new EDMMQTTClient();
        ClientModel Model { get; } = new ClientModel();
        TaskScheduler UIScheduler { get; set; }

        public MainForm()
        {
            InitializeComponent();
            UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            var ctrls = new Control[] { tlpConnection, flpConnection ,lvDetailStatus,lvChannelTable,lvSystem,lvShaker, lvParameters,lvReportFile,lvSignals,lvSystem,lvTests,lvTHStatus,lvSignalProperty,
                tableLayoutPanel1,tableLayoutPanel2,tableLayoutPanel3,tableLayoutPanel4,tableLayoutPanel5,tableLayoutPanel6,tableLayoutPanel7,tableLayoutPanel8,tableLayoutPanel9,
                tableLayoutPanel10,tableLayoutPanel11,tableLayoutPanel12,tableLayoutPanel13,tableLayoutPanel14,tableLayoutPanel15,tableLayoutPanel16,tableLayoutPanel17,rtbMessages,
                tabControlTest,tabControlDemo,tableLayoutPanel18,flowLayoutPanel1,flowLayoutPanel2,flowLayoutPanel3,flowLayoutPanel4,flowLayoutPanel5,flowLayoutPanel6,flowLayoutPanel7,flowLayoutPanel8,flowLayoutPanel9,
                tableLayoutPanel21,
            };
            ctrls.ToList().ForEach(c => c.EnableDoubleBuffer());

            LoadSettings();

            Client.ClientApplicationMessageReceived += OnClientApplicationMessageReceived;
            Client.ClientConnected += OnClientConnected;
            Client.ClientDisconnected += OnClientDisconnected;

//#if DEBUG
            lblParameterName.Visible = btnSetParameter.Visible = tbParameterValue.Visible = btnListParameter.Visible = true;
//#endif
        }
        void ShowSignals(List<MQTTSignalFrameData> app)
        {
            if (chart.IsDisposed || chart.Disposing || app?.Count == 0)
                return;

            try
            {
                chart.SuspendLayout();
                chart.GraphPane.CurveList.Clear();

                //var title = string.Join(";", app.Select(s => s.Signal.Name).ToArray());

                chart.GraphPane.Title.Text = $"Signal Display Demo - {app.First().Signal.Timestamp}";
                chart.GraphPane.Title.FontSpec.FontColor = Color.Black;
                chart.GraphPane.Title.FontSpec.IsBold = false;


                for (int i = 0; i < app.Count; i++)
                {
                    var sig = app[i];

                    if (sig.XLength > 0)
                    {
                        sig.ValueX = new double[sig.XLength];
                        sig.ValueX[0] = sig.XStart;
                        if (sig.XSequenceType == 0)
                        {
                            for (int j = 1; j < sig.XLength; j++)
                            {
                                sig.ValueX[j] = sig.ValueX[j - 1] + sig.XDelta;
                            }
                        }
                        else
                        {
                            for (int j = 1; j < sig.XLength; j++)
                            {
                                sig.ValueX[j] = sig.ValueX[j - 1] * sig.XDelta;
                            }
                        }
                    }

                    if (sig.ValueX == null || sig.ValueY == null)
                    {
                        chart.GraphPane.Title.Text = $"No signal data of - {sig.Signal.Name}";
                        chart.GraphPane.Title.FontSpec.FontColor = Color.Red;
                        chart.GraphPane.Title.FontSpec.IsBold = true;
                        chart.Invalidate();
                        return;
                    }

                    chart.GraphPane.XAxis.Title.Text = sig.Signal.UnitX;
                    chart.GraphPane.YAxis.Title.Text = sig.Signal.UnitY;

                    if (sig.Signal.Type == "Equidistant" || sig.Signal.Type == "NonEquidistant")
                    {
                        var firstVal = sig.ValueX[0];
                        //var scale = sig.Signal.UnitX == "ms" ? 1000.0 : 1.0;
                        sig.ValueX = sig.ValueX.Select(t => (t - firstVal)).ToArray();

                        chart.GraphPane.XAxis.Type = AxisType.Linear;
                        chart.GraphPane.YAxis.Type = AxisType.Linear;
                    }
                    else
                    {
                        chart.GraphPane.XAxis.Type = AxisType.Log;
                        chart.GraphPane.YAxis.Type = AxisType.Log;
                    }

                    var xData = sig.ValueX;
                    var yData = sig.ValueY;

                    if (xData != null && yData != null)
                    {
                        var color = Utility.COLORS[Math.Abs(sig.Signal.Name.GetHashCode()) % Utility.COLORS.Length];
                        bool isShockTest = lblTestType.Text.Contains("Shock");
                        if (Utility.NeedCutoffFreqData(sig.Signal.Type == "AutopowerSpectrum"))
                        {
                            double[][] signalData = new double[2][];
                            signalData[0] = xData;
                            signalData[1] = yData;
                            var ret = Utility.CutoffFreqData(signalData, isShockTest);
                            chart.GraphPane.AddCurve(sig.Signal.Name, ret[0], ret[1], color, SymbolType.None);
                        }
                        else if (isShockTest && sig.Signal.Type == "NonEquidistant")//shock block signal
                        {
                            if (sig.ValueZ?.Length > 1)
                            {
                                var zeroIndex = (int)sig.ValueZ[sig.ValueZ.Length - 1];
                                var zeroValue = xData[zeroIndex];
                                xData = xData.Select(x => x - zeroValue).ToArray();
                            }
                            chart.GraphPane.AddCurve(sig.Signal.Name, xData, yData, color, SymbolType.None);
                        }
                        else
                        {
                            chart.GraphPane.AddCurve(sig.Signal.Name, xData, yData, color, SymbolType.None);
                        }
                    }
                }


                chart.GraphPane.XAxis.Scale.MinAuto = true;
                chart.GraphPane.XAxis.Scale.MaxAuto = true;
                chart.GraphPane.YAxis.Scale.MinAuto = true;
                chart.GraphPane.YAxis.Scale.MaxAuto = true;
                chart.GraphPane.AxisChange();
                chart.Invalidate();

            }
            finally
            {
                chart.ResumeLayout(true);
            }
        }
        void LoadSettings()
        {
            LoadComboBoxSetting(cbxTLS, TLSOptions.Options, Settings.Default.TLS, OnTLSSelectedIndexChanged);
            LoadComboBoxSetting(cbxProtocol, ProtocolOptions.Options, Settings.Default.Protocol, OnProtocolSelectedIndexChanged);
            cbxCreateTestType.DataSource = Utility.VCSTestTypes;
            tbFileDir.Text = tbReportDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            tbClientID.Text = $"EDM-MQTT-Example-Client-{Guid.NewGuid().ToString().ToUpper()}";
            PeakValueHandler.TimeMatchOffset = (int)Settings.Default.TimestampMatchOffset;
          
        }
        void LoadComboBoxSetting(ComboBox cbx, string[] dataSource, string defaultVal, EventHandler h)
        {
            cbx.SelectedIndexChanged -= h;
            foreach (var tls in dataSource)
            {
                cbx.Items.Add(tls);
            }
            var index = cbx.FindString(defaultVal);
            if (index > -1)
                cbx.SelectedIndex = index;
            else
                cbx.SelectedIndex = 0;
            cbx.SelectedIndexChanged += h;
        }

        void UpdateClientModel()
        {
            Model.CleanSession = Settings.Default.IsClearSession;
            Model.ClientId = Settings.Default.ClientID;
            Model.CommunicationTimeout = (int)Settings.Default.CommunicationTimeout;
            Model.Host = Settings.Default.BrokerIP;
            Model.Port = (int)Settings.Default.BrokerPort;
            Model.KeepAliveInterval = (int)Settings.Default.KeepAliveTimeout;
            Model.User = Settings.Default.UserName;
            Model.Password = Settings.Default.Password;
            Model.Protocol = ProtocolOptions.ToProtocol(Settings.Default.Protocol);
            Model.SslProtocal = TLSOptions.ToProtocol(Settings.Default.TLS);
            Model.SoftwareMode = "MQTTClient";
        }
        void SaveTLSSettings()
        {
            Settings.Default.TLS = cbxTLS.SelectedItem.ToString();
            Settings.Default.Save();
        }

        void SaveProtocolSettings()
        {
            Settings.Default.Protocol = cbxProtocol.SelectedItem.ToString();
            Settings.Default.Save();
        }

        private async void AppendMessage(string msg,bool isError = false)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {

                    if (rtbMessages.Disposing || rtbMessages.IsDisposed)
                        return;

                    rtbMessages.SuspendLayout();
                    if (isError)
                    {
                        rtbMessages.AppendText(msg);
                        rtbMessages.Select(rtbMessages.TextLength - msg.Length, msg.Length);
                        rtbMessages.SelectionColor = Color.Red;
                    }
                    else
                    {
                        rtbMessages.AppendText(msg);
                    }

                    rtbMessages.AppendText(Environment.NewLine);
                    rtbMessages.ScrollToCaret();
                }
                finally
                {
                    rtbMessages.ResumeLayout();
                }

            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
        }

        private string GetOutputSettings()
        {
            if (cbOutputSine.Checked)
            {
                return $"Sine;{nudSineAmp.Value};{nudSineFreq.Value};{nudSineOffset.Value}";
            }
            else if (cbOutputTriangle.Checked)
            {
                return $"Triangle;{nudTriangleAmp.Value};{nudTriangleFreq.Value}";
            }
            else if (cbOutputSquare.Checked)
            {
                return $"Square;{nudSquareAmp.Value};{nudSquareFreq.Value}";
            }
            else if (cbOutputWhiteNoise.Checked)
            {
                return $"WhiteNoise;{nudWhiteNoiseRMS.Value}";
            }
            else if (cbOutputPinkNoise.Checked)
            {
                return $"PinkNoise;{nudPinkNoiseRMS.Value}";
            }
            else if (cbOutputDC.Checked)
            {
                return $"DC;{nudDCAmp.Value}";
            }
            else if (cbOutputChirp.Checked)
            {
                return $"Chirp;{nudChirpAmp.Value};{nudChirpLowFreq.Value};{nudChirpHighFreq.Value};{nudChirpPercent.Value};{nudChirpPeriod.Value}";
            }
            else //if(cbOutputSweptSine.Checked)
            {
                return $"SweptSine;{nudSweptSineAmp.Value};{nudSweptSineLowFreq.Value};{nudSweptSineHighFreq.Value};{nudSweptSinePeriod.Value}";
            }
        }

        private void ShowNotConnectedStatus()
        {
            tsStatus.Text = $"{DateTime.Now} - No connection to broker, unable to publish message";
            tsStatus.ForeColor= Color.Red;
        }

        private void ShowExceptionMessage(Exception ex)
        {
            tsStatus.Text = ex.ToString();
            tsStatus.ForeColor = Color.Red;
        }

        private void ClearNotConnectedStatus()
        {
            tsStatus.Text = string.Empty;
        }

        protected override void OnClosed(EventArgs e)
        {
            Settings.Default.Save();
            base.OnClosed(e);
        }
        private async void OnClientDisconnected(object sender, MQTTnet.Client.Disconnecting.MqttClientDisconnectedEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                btnDisconnect.Enabled = false;
                btnConnect.Enabled = true;
                tlpConnection.Enabled = true;

                tsConnectionStatus.Text = "Disconnected";
                tsConnectionStatus.ForeColor = Color.Red;
                ClearNotConnectedStatus();
                AppendMessage($"{DateTime.Now}-Client Disconnected {(sender as MqttClient)?.Options.ClientId}, {e.Reason}");

            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
        }

        private async void OnClientConnected(object sender, MQTTnet.Client.Connecting.MqttClientConnectedEventArgs e)
        {
            AppendMessage($"{DateTime.Now}-Client Connected {(sender as MqttClient)?.Options.ClientId}, {e.ConnectResult.ResultCode}");

            if (e.ConnectResult.ResultCode == MqttClientConnectResultCode.Success)
            {
                //Subscribe all TopicPrefix/# topics
                var builder = new MqttTopicFilterBuilder()
                     .WithTopic($"{Settings.Default.TopicPrefix}/#")
                     .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                     .WithRetainHandling(MQTTnet.Protocol.MqttRetainHandling.SendAtSubscribe);

                if (Model.Protocol == MQTTnet.Formatter.MqttProtocolVersion.V500)
                {
                    builder.WithNoLocal(true);
                }

                var topicFilter = builder.Build();

                var model = new SubscriptionOptionsModel
                {
                    Topic = topicFilter.Topic,
                    Level = topicFilter.QualityOfServiceLevel,
                    RetainHandling = topicFilter.RetainHandling,
                    NoLocal = topicFilter.NoLocal,
                    RetainAsPublished = topicFilter.RetainAsPublished
                };

                await Client.Subscribe(model);

                await Task.Factory.StartNew(() =>
                {
                    btnDisconnect.Enabled = true;
                    btnConnect.Enabled = false;
                    tlpConnection.Enabled = false;
                    tsConnectionStatus.Text = "Connected";
                    tsConnectionStatus.ForeColor= Color.Green;
                    ClearNotConnectedStatus();
                }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
            }
        }

        private async void OnClientApplicationMessageReceived(object sender, MQTTnet.MqttApplicationMessageReceivedEventArgs e)
        {

            if (e.ApplicationMessage.Topic.EndsWith(AppTopics.TOPIC_APP_MESSAGE) )
            {
                AppendMessage($"{DateTime.Now}-Application message received with topic {e.ApplicationMessage.Topic}, message is:{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            }
            else  if(e.ApplicationMessage.Topic.EndsWith(AppTopics.TOPIC_APP_ERROR))
            {
                AppendMessage($"{DateTime.Now}-Application error received with topic {e.ApplicationMessage.Topic}, error is:{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}",true);
            }
            else
            {
                AppendMessage($"{DateTime.Now}-Application data received with topic {e.ApplicationMessage.Topic}, payload size {e.ApplicationMessage.Payload?.Length} (bytes)");
            }


            await Task.Factory.StartNew(() =>
            {
                var msg = e.ApplicationMessage;
                if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_STATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTAppStatus>(msg.Payload);
                    lblName.Text = app.SoftwareMode;
                    lblVersion.Text = app.Version;
                    rbDSACommand.Checked = app.SoftwareMode.Contains("DSA") || app.SoftwareMode.Contains("TDA") || app.SoftwareMode.Contains("RCM");
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_SYSTEM_STATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTSystemStatus>(msg.Payload);
                    lblSystemName.Text = app.Name;
                    lblSystemStatus.Text = app.Status;
                }
                else if (msg.Topic.EndsWith(DSATopics.TOPIC_DSA_TEST_DSA_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTDSATestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_RANDOM_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTRandomTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_SINE_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTSineTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_SHOCK_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTShockTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_TWR_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTTWRTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(THVTopics.TOPIC_THV_TEST_TH_STATUS))
                {
                    var thvStatus = Utility.JsonDeserialize<MQTTTHStatus>(msg.Payload);


                    try
                    {
                        lvTHStatus.BeginUpdate();
                        lvTHStatus.Items.Clear();

                        var lvi = new ListViewItem(nameof(thvStatus.TotalTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TotalTime.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.RemainTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.RemainTime.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);


                        lvi = new ListViewItem(nameof(thvStatus.TargetTemperature));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TargetTemperature.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.ControlTemperature));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.ControlTemperature.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        foreach (var tp in thvStatus.LatestTemperatures)
                        {
                            lvi = new ListViewItem(tp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{tp.Temperature.ToString("f3")} ({tp.Unit})"));
                            lvTHStatus.Items.Add(lvi);
                        }

                        lvi = new ListViewItem(nameof(thvStatus.TargetHumdity));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TargetHumdity.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.ControlHumidity));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.ControlHumidity.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        foreach (var tp in thvStatus.LatestHumdities)
                        {
                            lvi = new ListViewItem(tp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{tp.Humdity.ToString("f3")} ({tp.Unit})"));
                            lvTHStatus.Items.Add(lvi);
                        }

                    }
                    finally
                    {
                        lvTHStatus.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(THVTopics.TOPIC_THV_TEST_VT_STATUS))
                {
                    var thvStatus = Utility.JsonDeserialize<MQTTVTStatus>(msg.Payload);


                    try
                    {
                        lvTHStatus.BeginUpdate();
                        lvTHStatus.Items.Clear();

                        var lvi = new ListViewItem(nameof(thvStatus.TotalTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TotalTime.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.RemainTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.RemainTime.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);


                        lvi = new ListViewItem(nameof(thvStatus.TargetTemperature));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TargetTemperature.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.ControlTemperature));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.ControlTemperature.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        foreach (var tp in thvStatus.LatestTemperatures)
                        {
                            lvi = new ListViewItem(tp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{tp.Temperature.ToString("f3")} ({tp.Unit})"));
                            lvTHStatus.Items.Add(lvi);
                        }

                        lvi = new ListViewItem(nameof(thvStatus.TargetVibration));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.TargetVibration.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(thvStatus.ControlVibration));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, thvStatus.ControlVibration.ToString("f3")));
                        lvTHStatus.Items.Add(lvi);

                        foreach (var tp in thvStatus.LatestVibrations)
                        {
                            lvi = new ListViewItem(tp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{tp.Vibration.ToString("f3")} ({tp.Unit})"));
                            lvTHStatus.Items.Add(lvi);
                        }

                    }
                    finally
                    {
                        lvTHStatus.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_SYSTEM))
                {
                    var app = Utility.JsonDeserialize<MQTTSystem>(msg.Payload);
                    lblSystemName.Text = app.Name;

                    try
                    {
                        lvSystem.BeginUpdate();
                        lvSystem.Items.Clear();
                        foreach (var m in app.Modules)
                        {
                            var lvi = new ListViewItem(m.DeviceType);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.SerialNumber));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.IPAdress));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Version));
                            lvSystem.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvSystem.EndUpdate();
                    }

                }
                else if(msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_SHAKER))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTShakerData>(msg.Payload),lvShaker);
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_CHANNELS))
                {
                    var app = Utility.JsonDeserialize<List<MQTTChannel>>(msg.Payload);

                    try
                    {
                        lvChannelTable.BeginUpdate();
                        lvChannelTable.Items.Clear();
                        foreach (var m in app)
                        {
                            var lvi = new ListViewItem(m.Module);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.LocationId));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Enable.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Quantity));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Unit));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Sensitivity.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.InputMode));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.InputRange));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.HighPassFrequency.ToString("f3")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Integration));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.ControlWeighting));
                            lvChannelTable.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvChannelTable.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_PARAMETERS))
                {
                    var app = Utility.JsonDeserialize<Dictionary<string, object>>(msg.Payload);

                    try
                    {
                        lvParameters.BeginUpdate();
                        lvParameters.Items.Clear();
                        foreach (var kp in app)
                        {
                            var lvi = new ListViewItem(kp.Key);
                            if(kp.Value != null)
                            {
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.Value.ToString()));
                            }
                            else
                            {
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "(null)"));
                            }

                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, GetParameterDescription(kp.Key)));

                            lvParameters.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvParameters.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_LIST))
                {
                    var app = Utility.JsonDeserialize<List<MQTTTest>>(msg.Payload);

                    try
                    {
                        lvTests.BeginUpdate();
                        lvTests.Items.Clear();
                        foreach (var kp in app)
                        {
                            var lvi = new ListViewItem(kp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.Type));
                            lvTests.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvTests.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_SIGNALS))
                {
                    var app = Utility.JsonDeserialize<List<MQTTSignal>>(msg.Payload);

                    try
                    {
                        lvSignals.ItemChecked -= OnSignalItemCheckChanged;
                        lvSignals.BeginUpdate();
                        lvSignals.Items.Clear();
                        lvSignalProperty.Items.Clear();
                        foreach (var kp in app)
                        {
                            var lvi = new ListViewItem(kp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.Type));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.BlockSize.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.SamplingRate.ToString("f2")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.UnitX));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.UnitY));
                            lvSignals.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvSignals.EndUpdate();
                        lvSignals.ItemChecked += OnSignalItemCheckChanged;
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_SIGNALPROPERTY))
                {
                    var app = Utility.JsonDeserialize<List<MQTTSignalProperty>>(msg.Payload);

                    try
                    {

                        lvSignalProperty.BeginUpdate();
                        foreach (var kp in app)
                        {
                            ListViewItem slvi = null;

                            foreach (ListViewItem lvi in lvSignalProperty.Items)
                            {
                                if (lvi.Text == kp.SignalName)
                                {
                                    slvi = lvi;
                                    break;
                                }
                            }

                            if (slvi != null)
                            {
                                if (kp.PropertyName == "RMS") slvi.SubItems[1].Text = kp.Value.ToString("f3");
                                else if (kp.PropertyName == "Peak") slvi.SubItems[2].Text = kp.Value.ToString("f3");
                                else if (kp.PropertyName == "PkPk") slvi.SubItems[3].Text = kp.Value.ToString("f3");
                                else if (kp.PropertyName == "Min") slvi.SubItems[4].Text = kp.Value.ToString("f3");
                                else if (kp.PropertyName == "Max") slvi.SubItems[5].Text = kp.Value.ToString("f3");
                                else if (kp.PropertyName == "Mean") slvi.SubItems[6].Text = kp.Value.ToString("f3");
                            }
                            else
                            {
                                slvi = new ListViewItem(kp.SignalName);
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "RMS" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Peak" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "PkPk" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Min" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Max" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Mean" ? kp.Value.ToString("f3") : "0.000"));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.Unit));
                                lvSignalProperty.Items.Add(slvi);
                            }
                        }

                        var removeItems = new List<ListViewItem>();
                        var names = app.Select(p => p.SignalName).ToList();
                        foreach (ListViewItem lvi in lvSignalProperty.Items)
                        {
                            if (!names.Contains(lvi.Text))
                                removeItems.Add(lvi);
                        }

                        foreach (ListViewItem lvi in removeItems)
                        {
                            lvSignalProperty.Items.Remove(lvi);
                        }
                    }
                    finally
                    {
                        lvSignalProperty.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST))
                {
                    var app = Utility.JsonDeserialize<MQTTTest>(msg.Payload);
                    lblTestName.Text = app.Name;
                    lblTestType.Text = app.Type;
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_STATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTTestStatus>(msg.Payload);
                    lblTestName.Text = app.Name;
                    lblRunFolder.Text = app.RunFolder;
                    lblTestStatus.Text = app.Status;
                    lblMeasureStartAt.Text = app.MeasureStartAt;
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_SIGNALDATA))
                {
                    var app = Utility.JsonDeserialize<List<MQTTSignalFrameData>>(msg.Payload);

                    ShowSignals(app);
                }
                else if(msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_COMPRESSED_SIGNALDATA))
                {
                    var app = Utility.JsonDeserialize<List<MQTTSignalFrameData>>(msg.Payload.DecompressByteArray());
                    ShowSignals(app);
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_RECORDSTATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTRecordStatus>(msg.Payload);

                    lblRecordStatus.Text = app.Status;
                    lblRecordName.Text = app.Name;
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_REPORTFILE))
                {
                    var app = Utility.JsonDeserialize<MQTTReportFile>(msg.Payload);
                    var path = Path.Combine(tbReportDir.Text, Path.GetFileName(app.ReportName));

                    if (app.ReportContent != null)
                    {
                        File.WriteAllBytes(path, app.ReportContent);
                    }

                    try
                    {
                        lvReportFile.BeginUpdate();

                        ListViewItem exItem = null;
                        foreach (ListViewItem item in lvReportFile.Items)
                        {
                            if (item.SubItems[1].Text == app.ReportName)
                            {
                                exItem = item;
                                break;
                            }
                        }

                        if (exItem != null)
                        {
                            exItem.BackColor = Color.Green;
                            exItem.ForeColor = Color.White;
                            lvReportFile.Invalidate();
                        }
                        else
                        {
                            var lvi = new ListViewItem(Path.GetFileName(app.ReportName));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, app.ReportName));
                            lvReportFile.Items.Add(lvi);
                        }

                        if (app.ReportContent != null)
                            MessageBox.Show(this, $"Report file has been obtained:{Environment.NewLine}{path}", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        lvReportFile.EndUpdate();
                    }

                }
                else if(msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_REPORTTEMPLATES))
                {
                    var app = Utility.JsonDeserialize<MQTTReportTemplates>(msg.Payload);
                    var preSelectedTemplate = string.Empty;
                    if (cbxReportTemplates.SelectedItem != null)
                    {
                        preSelectedTemplate = cbxReportTemplates.SelectedItem.ToString();
                    }
                    cbxReportTemplates.Items.Clear();
                    if(app.Templates?.Length > 0)
                    {
                        
                        foreach(var t in app.Templates)
                        {
                            cbxReportTemplates.Items.Add(t);
                        }

                        if(string.IsNullOrEmpty(preSelectedTemplate))
                        {
                            if (cbxReportTemplates.Items.Count > 0)
                            {
                                cbxReportTemplates.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            var idx = cbxReportTemplates.FindStringExact(preSelectedTemplate);
                            if (idx > -1) cbxReportTemplates.SelectedIndex = idx;
                        }
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_LIMITSTATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTLimitStatus>(msg.Payload);
                    lblLimitStatus.Text = app.Status;
                    lblLimitTest.Text = app.Name;
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_STAGE))
                {
                    var app = Utility.JsonDeserialize<MQTTVCSTestStage>(msg.Payload);

                    lblStage.Text = app.Stage;
                    lblStageTest.Text = app.Name;
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_CONTROL_UPDATED))
                {
                    var app = Utility.JsonDeserialize<MQTTVCSControlFlag>(msg.Payload);

                    lblControlFlag.Text = app.Flag;
                    lblControlFlagTest.Text = app.Name;
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_RUNFOLDER))
                {
                    var app = Utility.JsonDeserialize<MQTTRunFolder>(msg.Payload);
                    lblRunFolderInfo.Text = $"{app.RunName},{app.RunPath}";
                    try
                    {
                        lvFiles.Tag = app;
                        lvFiles.BeginUpdate();
                        lvFiles.Items.Clear();
                        foreach (var file in app.RunFiles)
                        {
                            ListViewItem lvi = new ListViewItem(file);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{app.RunPath}\\{file}"));
                            lvFiles.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvFiles.EndUpdate();
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_RECORDFILE))
                {
                    var app = Utility.JsonDeserialize<MQTTRecordFile>(msg.Payload);
                    var savePath = Path.Combine(tbFileDir.Text, app.FileName);

                    try
                    {
                        if (File.Exists(savePath))
                        {
                            File.Delete(savePath);
                        }

                        if (app.AtfxFileContent != null)
                        {
                            File.WriteAllBytes(savePath, app.AtfxFileContent);
                        }

                        for (var i = 0; i < app.DataFiles.Count; i++)
                        {
                            var dataFilePath = Path.Combine(tbFileDir.Text, Path.GetFileName(app.DataFiles[i]));

                            if (File.Exists(dataFilePath))
                            {
                                File.Delete(dataFilePath);
                            }

                            if (app.DataFileContents[i] != null)
                            {
                                File.WriteAllBytes(dataFilePath, app.DataFileContents[i]);
                            }
                        }


                        foreach (ListViewItem item in lvFiles.Items)
                        {
                            if (Path.GetFileName(item.SubItems[1].Text) == app.FileName)
                            {
                                item.BackColor = Color.Green;
                                item.ForeColor = Color.White;
                                lvFiles.Invalidate();
                                break;
                            }
                        }

                        MessageBox.Show(this, $"Record file has been obtained:{Environment.NewLine}{savePath}", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        ShowExceptionMessage(ex);
                        Trace.WriteLine(ex);
                    }
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_ADV_STATUS))
                {
                    var app = Utility.JsonDeserialize<MQTTAdvancedStatus>(msg.Payload);
                    ShowFreqVSPeakChart(app);
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_ERROR))
                {
                    MessageBox.Show(this, Encoding.UTF8.GetString(msg.Payload), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (msg.Topic.EndsWith(GlobalParameterTopics.TOPIC_GLOBAL_PARAMETER_RESPONSE))
                {
                    ShowGlobalParameters();
                }
               

            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);

            void ShowFreqVSPeakChart(MQTTAdvancedStatus app)
            {
                if (!ckbPFFV.Checked) return;

                PeakValueHandler.Add(app);

                if (app.Name == PeakValueHandler.PeakFrequency)
                {
                    if(float.TryParse(app.Value,out var freq))
                    {
                        tbPeakFreqValue.Text = $"{freq:f3}";
                    }
                    
                    lblPeakFreqUnit.Text = $"{PeakValueHandler.UnitX}";
                }
                else if(app.Name == PeakValueHandler.PeakValue)
                {
                    if (float.TryParse(app.Value, out var pk))
                    {
                        tbPeakValue.Text = $"{pk:f5}";
                    }
                    lblPeakValueUnit.Text = $"{PeakValueHandler.UnitY}";
                }
                

                var chart = this.zedGraphControl1;

                if (chart.IsDisposed || chart.Disposing || !PeakValueHandler.HasData)
                    return;

                try
                {
                 
                    chart.SuspendLayout();

                    //var title = string.Join(";", app.Select(s => s.Signal.Name).ToArray());

                    chart.GraphPane.Title.Text = $"Peak vs Frequency";
                    chart.GraphPane.Title.FontSpec.FontColor = Color.Black;
                    chart.GraphPane.Title.FontSpec.IsBold = false;


                    chart.GraphPane.XAxis.Title.Text = PeakValueHandler.UnitX;
                    chart.GraphPane.YAxis.Title.Text = PeakValueHandler.UnitY;
                    chart.GraphPane.XAxis.Type = AxisType.Log;
                    chart.GraphPane.YAxis.Type = AxisType.Linear;

                    chart.GraphPane.XAxis.MajorGrid.IsVisible = true;
                    chart.GraphPane.XAxis.MinorGrid.IsVisible = true;
                    chart.GraphPane.XAxis.Scale.Format = "f2";
                    chart.GraphPane.XAxis.Scale.IsUseTenPower = false;
                    chart.GraphPane.XAxis.Scale.MajorStepAuto = true;
                    chart.GraphPane.XAxis.Scale.MinorStepAuto = true;
                    chart.GraphPane.XAxis.Scale.Mag = 1;
                    chart.GraphPane.XAxis.MinorTic.IsAllTics= true;
                    chart.GraphPane.XAxis.MinorTic.IsInside = false;
                    chart.GraphPane.XAxis.MinorTic.IsOpposite = false;
                    chart.GraphPane.XAxis.MinorTic.IsOutside = true;

                    //chart.GraphPane.XAxis.MajorTic.IsAllTics = true;
                    //chart.GraphPane.XAxis.MinorTic.IsAllTics = true;



                    chart.GraphPane.YAxis.MajorGrid.IsVisible = true;
                    chart.GraphPane.YAxis.MinorGrid.IsVisible = true;

                    var data = PeakValueHandler.GetData(ckbAutoRefresh.Checked);

                    var xData = data[0];
                    var yData = data[1];

                    if (xData != null && yData != null && chart.GraphPane.CurveList.Count == 0)
                    {
                        chart.GraphPane.AddCurve("PeakVsFreq", xData, yData, Color.Blue, SymbolType.None);
                        
                        chart.GraphPane.XAxis.Scale.Min = 0;
                        chart.GraphPane.XAxis.Scale.Max = 5000;
                    }
                    else
                    {
                        var lineItem = chart.GraphPane.CurveList[0] as LineItem;
                        var ppl = lineItem.Points as PointPairList;

                        if (ppl.Count == xData.Length && ppl.Count == yData.Length)
                        {
                            for (int i = 0; i < xData.Length; i++)
                            {
                                ppl[i].X = xData[i];
                                ppl[i].Y = yData[i];
                            }
                        }
                        else
                        {
                            ppl.Clear();
                            ppl.Add(xData, yData);
                        }

                        //LineItem li = chart.GraphPane.
                    }

                    
                    //chart.GraphPane.XAxis.Scale.MaxAuto = true;
                    if(chart.GraphPane.ZoomStack.Count == 0)
                    {
                        chart.GraphPane.YAxis.Scale.MinAuto = true;
                        chart.GraphPane.YAxis.Scale.MaxAuto = true;
                        chart.GraphPane.AxisChange();
                    }
                   
                    chart.Invalidate();

                    if(ckbAutoRefresh.Checked)
                    {
                        try
                        {
                            dataGridViewFreqVsPeak.SuspendLayout();
                            dataGridViewFreqVsPeak.DataSource = PeakValueHandler.GetTable();
                        }
                        finally
                        {

                            dataGridViewFreqVsPeak.ResumeLayout();
                        }
                    }
                        

                }
                finally
                {
                    chart.ResumeLayout(true);
                }
            }

            void ShowNameAndValue(object ss, ListView lv = null)
            {
                var lvStatus = lv ?? lvDetailStatus;

                try
                {
                    lvStatus.BeginUpdate();
                    lvStatus.Items.Clear();


                    foreach (var fi in ss.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                    {
                        var lvi = new ListViewItem(fi.Name.TrimStart('n', 'f', 'd'));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, fi.GetValue(ss).ToString()));
                        lvStatus.Items.Add(lvi);
                    }
                }
                finally
                {
                    lvStatus.EndUpdate();
                }
            }

            void ShowGlobalParameters()
            {
                var msg = e.ApplicationMessage;

                var obj = Utility.JsonDeserialize(msg.Payload);

                if (obj is JObject jo)
                {
                    if (jo.TryGetValue("Item1", out var jtoken) && jtoken is JValue jv && jv.Value != null)
                    {

                        if (jv.Value.ToString() == CommandKey.ListGlobalParameters)
                        {
                            if (jo.TryGetValue("Item2", out var jtoken2) && jtoken2 is JArray ja)
                            {
                                try
                                {
                                    listViewGlobalParameters.BeginUpdate();
                                    listViewGlobalParameters.Items.Clear();

                                    foreach (dynamic item in ja)
                                    {
                                        var lvi = new ListViewItem(item.Value);
                                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, String.Empty));
                                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, String.Empty));
                                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, String.Empty));
                                        listViewGlobalParameters.Items.Add(lvi);
                                    }
                                }
                                finally
                                {
                                    listViewGlobalParameters.EndUpdate();
                                }
                            }
                        }
                        else if (jo.TryGetValue("Item2", out var jp) && jp != null)
                        {
                            var key = jv.Value.ToString();
                            var content = jp.ToString();
                            rtbGlobalParameter.Text = content;
                            dataGridView.DataSource = null;
                            propertyGrid.SelectedObject = null;

                            if (key.Contains(".Parameter."))
                            {
                                var p = Utility.JsonDeserialize<GParameter>(content);
                                propertyGrid.SelectedObject = p;
                            }
                            else if (key.Contains(".Signal."))
                            {
                                var s = Utility.JsonDeserialize<GSignal>(content);
                                propertyGrid.SelectedObject = s;


                                try
                                {
                                    var dt = new DataTable();

                                    //add table column
                                    foreach (var f in s.Data)
                                    {
                                        var dc = new DataColumn(string.IsNullOrWhiteSpace(f.Unit) ? "Z axis" : $"{f.Quantity} ({f.Unit})");
                                        dt.Columns.Add(dc);
                                    }


                                    if(s.Data.Count > 0)
                                    {
                                        //fill table rows
                                        int min = s.Data.Min(fd => fd.Values.Length);

                                        for (int i = 0; i < min; i++)
                                        {
                                            var dr = dt.NewRow();
                                            object[] items = new object[s.Data.Count];

                                            items[0] = s.Data[0].Values[i];
                                            items[1] = s.Data[1].Values[i];
                                            if (items.Length > 2 && i < s.Data[2].Values.Length)
                                                items[2] = s.Data[2].Values[i];

                                            dr.ItemArray = items;
                                            dt.Rows.Add(dr);
                                        }
                                    }                                    

                                    dataGridView.DataSource = dt;

                                }
                                catch (Exception ex)
                                {
                                    Trace.WriteLine(ex);
                                }
                            }
                            else if (key.Contains(".NumericalValue."))
                            {
                                var n = Utility.JsonDeserialize<GNumeric>(content);
                                propertyGrid.SelectedObject = n;

                            }
                            else if (key.Contains(".Table."))
                            {
                                var t = Utility.JsonDeserialize<GTable>(content);
                                propertyGrid.SelectedObject = t;

                                try
                                {
                                    var dt = new DataTable();

                                    //add table column
                                    foreach (var h in t.Headers)
                                    {
                                        var dc = new DataColumn(h.ToString());
                                        dt.Columns.Add(dc);
                                    }

                                    //fill table rows
                                    foreach (var r in t.Rows.Where(row=>row.Value != null))
                                    {
                                        var dr = dt.NewRow();
                                        dr.ItemArray = r.Value.ToArray();
                                        dt.Rows.Add(dr);
                                    }

                                    dataGridView.DataSource = dt;

                                }
                                catch (Exception ex)
                                {
                                    Trace.WriteLine(ex);
                                }

                            }
                        }
                    }
                }

            }
        }

        private string GetParameterDescription(string key)
        {
            //todo, add description here
            switch(key)
            {
                case "DSA_OverlapRatio": return "0-->No overlap, 1-->As high as possible, 2-->25%, 3-->50%, etc.";
                case "Average Type":
                case "Average Mode": return "0-->Linear, 1-->Exponential, 2-->Peak hold";
                case "Window Type": return "0-->Hanning, 1-->Hamming, 2-->Flattop, 3-->Uniform, etc.";
                case "DSA_SampleRate_ID": return "0-->102.4KHz, 1-->81.92KHz, 2-->64KHz, 3--> 51.2KHz, etc.";
                case "Block Size": return "256,512,1024,2048,4096,8192,16484,32768,65536";
                case "DSA_FFTAverageOnOffFlag": return "0-->ON, 1-->OFF";
                case "Octave Resolution": return "1-->1/1 oct, 3-->1/3 oct, 6-->1/6 oct, etc.";
                case "octave Type": return "1-->1/1,2-->1/3,3-->1/6,4-->1/12,5-->1/24,6-->1/48";
                case "Damping Ratio": return "0%~100%";
                case "DSA_LowPassCutoffFreq": return "0~Fa";
                default: return string.Empty;
            }
        }

        private void OnProtocolSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveProtocolSettings();
        }

        private void OnTLSSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTLSSettings();
        }

        private async void OnConnectClick(object sender, EventArgs e)
        {
            UpdateClientModel();
            await Client.Connect(Model);
        }

        private async void OnDisconnectClick(object sender, EventArgs e)
        {
            await Client.Disconnect();
        }

        private void OnParametersSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvParameters.SelectedItems)
            {
                lblParameterName.Text = item.Text;
                tbParameterValue.Text = item.SubItems[1].Text;
                break;
            }
        }

        private void OnBrowseReportDirClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    tbReportDir.Text = dlg.SelectedPath;
                }
            }
        }

        private void OnBrowseFileDirClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    tbFileDir.Text = dlg.SelectedPath;
                }
            }
        }


        private void OnExecuteCommand(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                var cmd = btn.Tag.ToString();

                var topic = rbDSACommand.Checked || tabPageOutput == tabControlTest.SelectedTab ? DSATopics.TOPIC_DSA_TEST_COMMAND : VCSTopics.TOPIC_VCS_TEST_COMMAND;

                if (btn == btnSetFrequency)
                {
                    PublishWithValue(nudFrequency.Value);
                }
                else if (btn == btnSetPhase)
                {
                    PublishWithValue(nudPhase.Value);
                }
                else if (btn == btnSetLevel)
                {
                    PublishWithValue(nudLevel.Value);
                }
                else if (btn == btnSetParameter)
                {
                    PublishWithValue($"{lblParameterName.Text};{tbParameterValue.Text}");
                }
                else if (btn == btnSetOutputIndex)
                {
                    PublishWithValue((int)nudOutputIndex.Value);
                }
                else if (btn == btnRoRBandsOn || btn == btnRoRBandsOff)
                {
                    PublishWithValue($"{Convert.ToInt32(rorBandFlag.Checked)};{tbRoRBands.Text}");
                }
                else if (btn == btnSORTonesOn || btn == btnSORTonesOff || btn == btnSORTonesHold || btn == btnSORTonesRelease || btn == btnSORTonesSweepDown || btn == btnSORTonesSweepUp)
                {
                    PublishWithValue($"{Convert.ToInt32(sorBandFlag.Checked)};{tbSoRTones.Text}");
                }
                else if (btn == btnCreatTest)
                {
                    PublishWithValue($"{tbCreateTestName.Text};{cbxCreateTestType.SelectedItem}");
                }
                else if (btn == btnDeleteTest || btn == btnLoadTest)
                {
                    if (lvTests.SelectedItems.Count > 0)
                    {
                        PublishWithValue($"{lvTests.SelectedItems[0].Text}");
                    }
                }
                else if (btn == btnGetRecordFile)
                {
                    if (lvFiles.SelectedItems.Count > 0)
                    {
                        PublishWithValue($"{lvFiles.SelectedItems[0].SubItems[1].Text}");
                    }
                }
                else if (btn == btnGetReport)
                {
                    if (lvReportFile.SelectedItems.Count > 0)
                    {
                        PublishWithValue($"{lvReportFile.SelectedItems[0].SubItems[1].Text}");
                    }
                }
                else if (btn == btnGenerateReport)
                {
                    PublishWithValue(cbxReportTemplates.Text);
                }
                else if (btn == btnSetOutputParameters)
                {
                    PublishWithValue(GetOutputSettings());
                }
                else
                {
                    PublishCommand();
                }


                async void PublishCommand()
                {
                    ClearNotConnectedStatus();
                    if (Client.IsConnected)
                    {
                        var options = new PublishOptionsModel()
                        {
                            Topic = $"{Settings.Default.TopicPrefix}/{topic}",
                            Retain = false,
                            Payload = Encoding.UTF8.GetBytes(cmd)
                        };
                        await Client.Publish(options);

                        AppendPublishLog(topic, cmd);
                    }
                    else 
                        ShowNotConnectedStatus();
                }


                async void PublishWithValue(object val)
                {
                    ClearNotConnectedStatus();
                    if (Client.IsConnected)
                    {
                        var options = new PublishOptionsModel()
                        {
                            Topic = $"{Settings.Default.TopicPrefix}/{topic}",
                            Retain = false,
                            Payload = Encoding.UTF8.GetBytes($"{cmd};{val}")
                        };
                        await Client.Publish(options);

                        AppendPublishLog(topic, $"{cmd};{val}");
                    }
                    else
                        ShowNotConnectedStatus();
                }
            }
        }



        private void OnSelectAll(object sender, EventArgs e)
        {
            cbRMS.Checked = cbPeak.Checked = cbPkPk.Checked = cbMin.Checked = cbMax.Checked = cbMean.Checked = true;
        }

        private void OnSelectInverse(object sender, EventArgs e)
        {
            cbRMS.Checked = !cbRMS.Checked;
            cbPeak.Checked = !cbPeak.Checked;
            cbPkPk.Checked = !cbPkPk.Checked;
            cbMin.Checked = !cbMin.Checked;
            cbMax.Checked = !cbMax.Checked;
            cbMean.Checked = !cbMean.Checked;
        }

        private void OnGetSignalProperty(object sender, EventArgs e)
        {
            var names = string.Empty;
            foreach (ListViewItem lvi in lvSignals.Items)
                if (lvi?.Checked == true)
                    names = $"{names};{lvi.Text}";

            if (cbRMS.Checked) GetSignalProperties(cbRMS);
            if (cbPeak.Checked) GetSignalProperties(cbPeak);
            if (cbPkPk.Checked) GetSignalProperties(cbPkPk);
            if (cbMin.Checked) GetSignalProperties(cbMin);
            if (cbMax.Checked) GetSignalProperties(cbMax);
            if (cbMean.Checked) GetSignalProperties(cbMean);

            async void GetSignalProperties(CheckBox cb)
            {
                var options = new PublishOptionsModel()
                {
                    Topic = $"{Settings.Default.TopicPrefix}/{AppTopics.TOPIC_APP_TEST_COMMAND}",
                    Retain = false,
                    Payload = Encoding.UTF8.GetBytes($"{CommandKey.RequestSignalProperty};{cb.Text}{names}")
                };
                await Client.Publish(options);
                AppendPublishLog(AppTopics.TOPIC_APP_TEST_COMMAND, $"{CommandKey.RequestSignalProperty};{cb.Text}{names}");
                await Task.Delay(100);
            }

        }

        private async void OnSignalItemCheckChanged(object sender, ItemCheckedEventArgs e)
        {
            var names = string.Empty;
            foreach (ListViewItem lvi in lvSignals.Items)
                if (lvi?.Checked == true)
                    names = $"{names};{lvi.Text}";

            ClearNotConnectedStatus();

            if (Client.IsConnected)
            {
                var options = new PublishOptionsModel()
                {
                    Topic = $"{Settings.Default.TopicPrefix}/{AppTopics.TOPIC_APP_TEST_COMMAND}",
                    Retain = false,
                    Payload = Encoding.UTF8.GetBytes($"{CommandKey.RequestSignalData}{names}")
                };
                await Client.Publish(options);

                AppendPublishLog(AppTopics.TOPIC_APP_TEST_COMMAND, $"{CommandKey.RequestSignalData}{names}");
            }
            else 
                ShowNotConnectedStatus();
        }


        private void OnReportFileMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var lvi = lvReportFile.GetItemAt(e.Location.X, e.Location.Y);
                if (lvi != null)
                {
                    var path = lvi.SubItems[1].Text;
                    if (File.Exists(path))
                    {
                        Utility.OpenFile(path);
                    }
                }
            }
        }

        private void OnRecordFileMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var lvi = lvFiles.GetItemAt(e.Location.X, e.Location.Y);
                if (lvi != null)
                {
                    var path = Path.Combine(tbFileDir.Text, lvi.Text);
                    if (File.Exists(path))
                    {
                        Utility.OpenFile(path);
                    }
                }
            }
        }

        private async void OnPublishMessage(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbMessage.Text))
            {
                ClearNotConnectedStatus();

                if (Client.IsConnected)
                {
                    var options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{AppTopics.TOPIC_APP_MESSAGE}",
                        Retain = false,
                        Payload = Encoding.UTF8.GetBytes(tbMessage.Text)
                    };
                    await Client.Publish(options);

                    AppendPublishLog(AppTopics.TOPIC_APP_MESSAGE, tbMessage.Text);
                }
                else
                    ShowNotConnectedStatus();
            }
        }

        private void OnClearMessages(object sender, EventArgs e)
        {
            rtbMessages.Clear();
        }

        private void AppendPublishLog(string topic, string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                AppendMessage($"{DateTime.Now}-Publish Topic {Settings.Default.TopicPrefix}/{topic} without payload");
            }
            else
            {
                AppendMessage($"{DateTime.Now}-Publish Topic {Settings.Default.TopicPrefix}/{topic} with payload:{payload}");
            }
        }

        private void OnOutputTypeCheckedChanged(object sender, EventArgs e)
        {
            var cbOutputs = new List<CheckBox>() { cbOutputSine, cbOutputTriangle, cbOutputSquare, cbOutputWhiteNoise, cbOutputPinkNoise, cbOutputDC, cbOutputChirp, cbOutputSweptSine };

            try
            {
                cbOutputs.ForEach(c => c.CheckedChanged -= OnOutputTypeCheckedChanged);
                cbOutputs.ForEach(c => c.Checked = sender == c);
            }
            finally
            {
                cbOutputs.ForEach(c => c.CheckedChanged += OnOutputTypeCheckedChanged);
            }
        }

        private void OnBrowseProfile(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                if(sender == btnBrowseSchedule)
                {
                    fileDialog.Filter = "Schedule json file|*.sch";
                }
                else
                {
                    fileDialog.Filter = "CSV Profile file|*.csv";
                }
                
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sender == btnBrowseRandomProfile)
                        tbRandomProfilePath.Text = fileDialog.FileName;
                    else if (sender == btnBrowseSineProfile)
                        tbSineProfilePath.Text = fileDialog.FileName;
                    else if (sender == btnBrowseShockProfile)
                        tbShockProfilePath.Text = fileDialog.FileName;
                    else if (sender == btnBrowseChannelTable)
                        tbChannelTablePath.Text = fileDialog.FileName;
                    else if (sender == btnBrowseSchedule)
                        tbSchedulePath.Text = fileDialog.FileName;
                }
            }
        }

        private async void OnAdvancedCommand(object sender, EventArgs e)
        {
            try
            {
                ClearNotConnectedStatus();
                string cmd = String.Empty, profile = String.Empty;
                if (sender == btnSetRandomProfile)
                {
                    cmd = CommandKey.SetRandomProfile;
                    profile = File.ReadAllText(tbRandomProfilePath.Text);
                }
                else if (sender == btnSetSineProfile)
                {
                    cmd = CommandKey.SetSineProfile;
                    profile = File.ReadAllText(tbSineProfilePath.Text);
                }
                else if (sender == btnSetShockProfile)
                {
                    cmd = CommandKey.SetShockProfile;
                    profile = File.ReadAllText(tbShockProfilePath.Text);
                }
                else if (sender == btnSetChannelTable)
                {
                    cmd = CommandKey.SetChannelTable;
                    profile = File.ReadAllText(tbChannelTablePath.Text);
                }
                else if(sender == btnSetSchedule)
                {
                    cmd = CommandKey.SetSchedule;
                    profile = File.ReadAllText(tbSchedulePath.Text);
                }

                if (Client.IsConnected && !string.IsNullOrWhiteSpace(cmd) && !string.IsNullOrWhiteSpace(profile))
                {
                    var options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{VCSTopics.TOPIC_VCS_TEST_COMMAND}",
                        Retain = false,
                        Payload = Encoding.UTF8.GetBytes($"{cmd};{profile}")
                    };
                    await Client.Publish(options);

                    AppendPublishLog(VCSTopics.TOPIC_VCS_TEST_COMMAND, $"{cmd}");
                }

                if (!Client.IsConnected)
                    ShowNotConnectedStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private async void OnListGlobalParameters(object sender, EventArgs e)
        {
            ClearNotConnectedStatus();
            if (Client.IsConnected)
            {
                var options = new PublishOptionsModel()
                {
                    Topic = $"{Settings.Default.TopicPrefix}/{GlobalParameterTopics.TOPIC_GLOBAL_PARAMETER_REQUEST}",
                    Retain = false,
                    Payload = Encoding.UTF8.GetBytes(CommandKey.ListGlobalParameters),
                };
                await Client.Publish(options);
                AppendPublishLog(options.Topic, String.Empty);
            }
            else
                ShowNotConnectedStatus();


        }

        private async void OnGetGlobalParameter(object sender, EventArgs e)
        {
            ClearNotConnectedStatus();
            var items = listViewGlobalParameters.SelectedItems;
            if (Client.IsConnected && items?.Count > 0)
            {
                var options = new PublishOptionsModel()
                {
                    Topic = $"{Settings.Default.TopicPrefix}/{GlobalParameterTopics.TOPIC_GLOBAL_PARAMETER_REQUEST}",
                    Retain = false,
                    Payload = Encoding.UTF8.GetBytes(items[0].Text),
                };
                await Client.Publish(options);
                AppendPublishLog(options.Topic, items[0].Text);
            }

            if(!Client.IsConnected)
                ShowNotConnectedStatus();
        }

        private void OnGlobalParametersSelectedIndexChanged(object sender, EventArgs e)
        {
            OnGetGlobalParameter(sender, e);
        }

        private void OnCopyJsonContent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbGlobalParameter.Text))
                return;

            Clipboard.SetText(rtbGlobalParameter.Text);
        }

        private async void OnPFFVCheckedChanged(object sender, EventArgs e)
        {
            if (!Client.IsConnected)
            {
                ShowNotConnectedStatus();
                ckbPFFV.Checked = false;
                return;
            }

            ClearNotConnectedStatus();

            string cmdFreq, cmdVal;
            if (ckbPFFV.Checked)
            {
                if (string.IsNullOrEmpty(tbPeakFreqSource.Text))
                {
                    return;
                }

                if(string.IsNullOrEmpty(tbPeakValueSource.Text))
                {
                    return;
                }

                PeakValueHandler.Clear();
                this.zedGraphControl1.GraphPane.CurveList.Clear();
                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Invalidate();

                cmdFreq = $"{CommandKey.RequestPeakFrequency};On;{tbPeakFreqSource.Text}";
                cmdVal = $"{CommandKey.RequestPeakValue};On;{tbPeakValueSource.Text}";               
            }
            else
            {
                cmdFreq = $"{CommandKey.RequestPeakFrequency};Off";
                cmdVal = $"{CommandKey.RequestPeakValue};Off";
                
            }

            var options = new PublishOptionsModel()
            {
                Topic = $"{Settings.Default.TopicPrefix}/{VCSTopics.TOPIC_VCS_TEST_COMMAND}",
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(cmdFreq)   
            };
            await Client.Publish(options);

            AppendPublishLog(VCSTopics.TOPIC_VCS_TEST_COMMAND, cmdFreq);


            options = new PublishOptionsModel()
            {
                Topic = $"{Settings.Default.TopicPrefix}/{VCSTopics.TOPIC_VCS_TEST_COMMAND}",
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(cmdVal)
            };
            await Client.Publish(options);

            AppendPublishLog(VCSTopics.TOPIC_VCS_TEST_COMMAND, cmdVal);
        }

        private void OnTimestampMatchOffsetValueChanged(object sender, EventArgs e)
        {
            PeakValueHandler.TimeMatchOffset = (int)nudTimestampMatchOffset.Value;
        }

        private void OnExportFreqVsPeakClick(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV files(*.csv)|*.csv";
                dlg.FileName = "PeakVsFreq";
                if (dlg.ShowDialog(this.TopLevelControl) == DialogResult.OK)
                {  
                    Utility.ExportCSV(dlg.FileName, this.dataGridViewFreqVsPeak, out _,
                         invariantCulture: true,excludeCol: ckbExcludedB.Checked?1:-1);
                }
            }
        }

        private void OnRefreshFreqVsPeakClick(object sender, EventArgs e)
        {
            try
            {
                dataGridViewFreqVsPeak.SuspendLayout();
                PeakValueHandler.GetData(true);
                dataGridViewFreqVsPeak.DataSource = PeakValueHandler.GetTable();
            }
            finally
            {

                dataGridViewFreqVsPeak.ResumeLayout();
            }
        }

        private void OnResetFreqVsPeakClick(object sender, EventArgs e)
        {
            PeakValueHandler.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
        }

    }



}
