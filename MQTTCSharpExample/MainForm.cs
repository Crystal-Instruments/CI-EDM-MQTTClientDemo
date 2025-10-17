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
using MQTTCSharpExample.Properties;

namespace MQTTCSharpExample
{
    public partial class MainForm : Form
    {
        EDMMQTTClient Client { get; } = new EDMMQTTClient();
        ClientModel Model { get; } = new ClientModel();
        TaskScheduler UIScheduler { get; set; }

        const string COMMAND_PARAMETER_PREFIX = "_MCP_";
        const string TIME_FORMAT = "yyyy-MM-dd HH:mm:ss,fff";
        const string ZERO_STRING = "0.000";


#if DEBUG
        ManualResetEventSlim debugEvt;
#endif

        public MainForm()
        {
            InitializeComponent();
            UIScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            EnableContianerControlsDoubleBuffered();

            LoadSettings();

            Client.ClientApplicationMessageReceived += OnClientApplicationMessageReceived;
            Client.ClientConnected += OnClientConnected;
            Client.ClientDisconnected += OnClientDisconnected;

            tabControlDemo.Selecting += OnTabControlSelecting;
            tabControlDemo.Selected += OnTabControlSelected;

#if DEBUG            
            this.btnDebugStart.Click += new System.EventHandler(this.OnDebugStartClick);
            this.btnDebugStop.Click += new System.EventHandler(this.OnDebugStopClick);
#else 
            tabControlDemo.TabPages.Remove(tabPageDebug);
#endif
        }

#if DEBUG


       

        async void OnDebugStartClick(object sender, EventArgs e)
        {
            if (Client.IsConnected)
            {
                if (debugEvt == null)
                    debugEvt = new ManualResetEventSlim(false);
                else
                    debugEvt.Reset();

                var cmd1 = tbCmd1.Text;
                var cmd2 = tbCmd2.Text;

                if (string.IsNullOrEmpty(cmd1))
                    return;

                if (string.IsNullOrEmpty(cmd2))
                    return;

                if (!int.TryParse(tbInterval.Text, out var interval) || interval <= 0)
                    return;

                btnDebugStart.Enabled = false;
                btnDebugStop.Enabled = true;

                var payload1 = Encoding.UTF8.GetBytes(cmd1);
                var payload2 = Encoding.UTF8.GetBytes(cmd2);


                var aps = $"{CommandKey.RequestSignalProperty};RMS;{string.Join(";", Enumerable.Range(1, 8).Select(i => $"APS(Ch{i})")).TrimEnd(';')}";
                var block = $"{CommandKey.RequestSignalProperty};RMS;{string.Join(";", Enumerable.Range(1, 8).Select(i => $"Block(Ch{i})")).TrimEnd(';')}";

                var apss = Encoding.UTF8.GetBytes(aps);
                var blocks = Encoding.UTF8.GetBytes(block);


                while (!debugEvt.Wait(interval))
                {
                    var options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{DSATopics.TOPIC_DSA_TEST_COMMAND}",
                        Retain = false,
                        Payload = payload1
                    };
                    await Client.Publish(options);
                    await Task.Delay(10);

                    options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{DSATopics.TOPIC_DSA_TEST_COMMAND}",
                        Retain = false,
                        Payload = blocks
                    };
                    await Client.Publish(options);
                    await Task.Delay(10);
                    options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{DSATopics.TOPIC_DSA_TEST_COMMAND}",
                        Retain = false,
                        Payload = apss
                    };
                    await Client.Publish(options);
                    await Task.Delay(10);
                    options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{DSATopics.TOPIC_DSA_TEST_COMMAND}",
                        Retain = false,
                        Payload = payload2
                    };
                    await Client.Publish(options);
                    await Task.Delay(10);
                }
            }
        }

        void OnDebugStopClick(object sender, EventArgs e)
        {
            debugEvt?.Set();
            btnDebugStart.Enabled = true;
            btnDebugStop.Enabled = false;
        }




#endif

        #region Methods
        void EnableContianerControlsDoubleBuffered()
        {
            var ctrls = new Control[] { tlpConnection, flpConnection ,lvDetailStatus,lvChannelTable,lvSystem,lvShaker, lvParameters,lvReportFile,lvSignals,lvSystem,lvTests,lvTHStatus,lvVibStatus,lvSignalProperty,
                tableLayoutPanel1,tableLayoutPanel2,tableLayoutPanel3,tableLayoutPanel4,tableLayoutPanel5,tableLayoutPanel6,tableLayoutPanel7,tableLayoutPanel8,tableLayoutPanel9,
                tableLayoutPanel10,tableLayoutPanel11,tableLayoutPanel12,tableLayoutPanel13,tableLayoutPanel14,tableLayoutPanel15,tableLayoutPanel16,tableLayoutPanel17,rtbMessages,
                tabControlTest,tabControlDemo,tableLayoutPanel18,flowLayoutPanel1,flowLayoutPanel2,flowLayoutPanel3,flowLayoutPanel4,flowLayoutPanel5,flowLayoutPanel6,flowLayoutPanel7,flowLayoutPanel8,flowLayoutPanel9,
                tableLayoutPanel21,tableLayoutPanel22,tableLayoutPanel23,tableLayoutPanel24,tableLayoutPanel25,tableLayoutPanelProfile,tableLayoutPanelShockProfile,
                flowLayoutPanel15,flowLayoutPanel16
            };
            ctrls.ToList().ForEach(c => c.EnableDoubleBuffer());
        }

        void ShowSignals(List<MQTTSignalFrameData> app)
        {
            if (chart.IsDisposed || chart.Disposing || app?.Count == 0)
                return;

            try
            {
                chart.SuspendLayout();
                chart.GraphPane.CurveList.Clear();

                chart.GraphPane.Title.Text = $"Signal Display Demo - {app[0].Signal.Timestamp}";
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

            foreach (var ip in Utility.GetBroadcastNetworkInterfaces())
            {
                selectIPToolStripMenuItem.DropDownItems.Add($"{ip.Value.Address}-[{ip.Key.Name}]", null, onClick: (s, e) => { tbBrokerIP.Text = ip.Value.Address.ToString(); });
            }

            cbxAccUnit.SelectedIndex = cbxMainPulseType.SelectedIndex = cbxLimitType.SelectedIndex
                = cbxCompensationType.SelectedIndex = cbxCompensationPulseType.SelectedIndex = 0;

            cbxTriggerCondition.SelectedIndex = 0;
            cbxTriggerMode.SelectedIndex = 0;

        }
        private static void LoadComboBoxSetting(ComboBox cbx, string[] dataSource, string defaultVal, EventHandler h)
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

            Model.CACertificateFile = Settings.Default.CACertificateFile;
            Model.ClientCertificateFile = Settings.Default.ClientCertificateFile;
            Model.ClientCertificatePrivateKeyFile = Settings.Default.ClientCertificatePrivateKeyFile;
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

        async Task AppendMessage(string msg, bool isError = false)
        {
#if DEBUG
            if (debugEvt != null) return;
#endif

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
                    if(tabPageLog == tabControlDemo.SelectedTab)
                        rtbMessages.ScrollToCaret();
                }
                finally
                {
                    rtbMessages.ResumeLayout();
                }

            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
        }

        string GetOutputSettings()
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

        void ShowNotConnectedStatus()
        {
            tsStatus.Text = $"{DateTime.Now} - No connection to broker, unable to publish message";
            tsStatus.ForeColor = Color.Red;
        }

        void ShowExceptionMessage(Exception ex)
        {
            tsStatus.Text = ex.ToString();
            tsStatus.ForeColor = Color.Red;
        }

        void ClearNotConnectedStatus()
        {
            tsStatus.Text = string.Empty;
        }

        async Task AppendPublishLog(string topic, string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
              await  AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Publish Topic {Settings.Default.TopicPrefix}/{topic} without payload");
            }
            else
            {
              await  AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Publish Topic {Settings.Default.TopicPrefix}/{topic} with payload:{payload}");
            }
        }

        void BrowseFile(TextBox atb)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (atb == tbCACertificateFile || atb == tbClientCertificateFile)
                {
                    ofd.Filter = "Certificate file|*.crt|PEM file|*.pem";
                }
                else
                {
                    ofd.Filter = "Key file|*.key";
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    atb.Text = ofd.FileName;
                }
            }
        }

        MQTTRandomSimpleProfile? GetRandomSimpleProfile()
        {
            if (cbxAccUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the unit of acceleration");
                return null;
            }
            if (dgvRandomProfile.Rows.Count < 2)
            {
                MessageBox.Show("At least two entries are required");
                return null;
            }
            var profile = new MQTTRandomSimpleProfile
            {
                AccUnit = cbxAccUnit.SelectedItem.ToString(),
                Entries = new List<MQTTRandomProfileEntry>()
            };
            try
            {
                foreach (DataGridViewRow row in dgvRandomProfile.Rows)
                {
                    var entry = new MQTTRandomProfileEntry
                    {
                        Frequency = Convert.ToSingle(row.Cells[0].Value),
                        Profile = Convert.ToSingle(row.Cells[1].Value),
                        HighAbort = Convert.ToSingle(row.Cells[2].Value),
                        HighAlarm = Convert.ToSingle(row.Cells[3].Value),
                        LowAlarm = Convert.ToSingle(row.Cells[4].Value),
                        LowAbort = Convert.ToSingle(row.Cells[5].Value)
                    };
                    profile.Entries.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return profile;
        }

        MQTTSineSimpleProfile? GetSineSimpleProfile()
        {
            if (cbxAccUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the unit of acceleration");
                return null;
            }
            if (dgvSineProfile.Rows.Count < 2)
            {
                MessageBox.Show("At least two entries are required");
                return null;
            }
            var profile = new MQTTSineSimpleProfile
            {
                AccUnit = cbxAccUnit.SelectedItem.ToString(),
                Entries = new List<MQTTSineProfileEntry>()
            };
            try
            {
                foreach (DataGridViewRow row in dgvSineProfile.Rows)
                {
                    var entry = new MQTTSineProfileEntry
                    {
                        Frequency = Convert.ToSingle(row.Cells[0].Value),
                        Profile = Convert.ToSingle(row.Cells[1].Value),
                        SegmentType = Convert.ToInt32(row.Cells[2].Value),
                        HighAbort = Convert.ToSingle(row.Cells[3].Value),
                        HighAlarm = Convert.ToSingle(row.Cells[4].Value),
                        LowAlarm = Convert.ToSingle(row.Cells[5].Value),
                        LowAbort = Convert.ToSingle(row.Cells[6].Value)
                    };
                    profile.Entries.Add(entry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return profile;
        }

        MQTTShockSimpleProfile? GetShockSimpleProfile()
        {
            if (cbxAccUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the unit of acceleration");
                return null;
            }

            var profile = new MQTTShockSimpleProfile();

            try
            {
                profile.Amplitude = (float)nudAmplitude.Value;
                profile.PulseWidth = (float)nudPulseWidth.Value;
                profile.PrePulseHeight = (float)nudPrePulseHeight.Value;
                profile.PostPulseHeight = (float)nudPostPulseHeight.Value;

                profile.MainPulseType = getValue(cbxMainPulseType);
                profile.LimitType = getValue(cbxLimitType);
                profile.CompensationType = getValue(cbxCompensationType);
                profile.CompensationPulseType = getValue(cbxCompensationPulseType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return profile;

            int getValue(ComboBox cbx)
            {
                try
                {
                    var val = cbx.SelectedItem.ToString().Split('=')[1].Trim();
                    return int.Parse(val);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return 0;
                }

            }
        }



        MQTTTriggerSettings GetTriggerSetttings()
        {
            MQTTTriggerSettings ts = new MQTTTriggerSettings()
            {
                TriggerMode = cbxTriggerMode.SelectedIndex,
                TriggerSource = cbxTriggerSource.SelectedItem.ToString(),
                TriggerType = cbxTriggerCondition.SelectedIndex,
                HighLevel = (float)nudHighLevel.Value,
                LowLevel = (float)nudLowLevel.Value,
                DelayPoints = (int)nudDelayPoints.Value,
            };
            return ts;
        }

        MQTTShakerData GetShakerParameters()
        {
            MQTTShakerData shakerData = new MQTTShakerData();
            object obj = shakerData;
            var t = typeof(MQTTShakerData);

            foreach (ListViewItem lvi in lvShaker.Items)
            {
                var field = t.GetField(lvi.Text);
                if (field != null)
                {
                    try
                    {
                        var val = lvi.SubItems[1].Text;

                        if (double.TryParse(val, out var d))
                        {
                            field.SetValue(obj, d);
                        }
                        else if (bool.TryParse(val, out var b))
                        {
                            field.SetValue(obj, b);
                        }
                        else
                        {
                            field.SetValue(obj, val);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.ToString());
                    }
                }
            }
            shakerData = (MQTTShakerData)obj;
            return shakerData;
        }

        string GetReportNotes()
        {
            List<MQTTReportNote> notes = new List<MQTTReportNote>();

            foreach (var item in lvReportNotes.Items.OfType<ListViewItem>())
            {
                notes.Add(new MQTTReportNote() { Name = item.Text, Content = item.SubItems[1].Text });
            }

            return Utility.JsonSerializer(notes.ToArray());
        }
        #endregion

        #region Event Handlers

        async private void OnTabControlSelected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageSignal)
            {
                var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
                await Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(1000);
                    lvSignals.ItemChecked -= OnSignalItemCheckChanged;
                    lvSignals.ItemChecked += OnSignalItemCheckChanged;
                },CancellationToken.None, TaskCreationOptions.None, scheduler);
            }
        }

        private void OnTabControlSelecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPageSignal)
            {
                lvSignals.ItemChecked -= OnSignalItemCheckChanged;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Settings.Default.Save();
            base.OnClosed(e);
        }
        async void OnClientDisconnected(object sender, MQTTnet.Client.Disconnecting.MqttClientDisconnectedEventArgs e)
        {
            await Task.Factory.StartNew(async () =>
            {
                btnDisconnect.Enabled = false;
                selectIPToolStripMenuItem.Enabled = true;
                btnConnect.Enabled = true;
                tlpConnection.Enabled = true;

                tsConnectionStatus.Text = "Disconnected";
                tsConnectionStatus.ForeColor = Color.Red;
                ClearNotConnectedStatus();
                await AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Client Disconnected {(sender as MqttClient)?.Options.ClientId}, {e.Reason}");

            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
        }

        async void OnClientConnected(object sender, MQTTnet.Client.Connecting.MqttClientConnectedEventArgs e)
        {
            await AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Client Connected {(sender as MqttClient)?.Options.ClientId}, {e.ConnectResult.ResultCode}");

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
                    selectIPToolStripMenuItem.Enabled = false;
                    btnConnect.Enabled = false;
                    tlpConnection.Enabled = false;
                    tsConnectionStatus.Text = "Connected";
                    tsConnectionStatus.ForeColor = Color.Green;
                    ClearNotConnectedStatus();
                }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);
            }
        }

        async void OnClientApplicationMessageReceived(object sender, MQTTnet.MqttApplicationMessageReceivedEventArgs e)
        {

            if (e.ApplicationMessage.Topic.EndsWith(AppTopics.TOPIC_APP_MESSAGE))
            {
                await AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Application message received with topic {e.ApplicationMessage.Topic}, message is:{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            }
            else if (e.ApplicationMessage.Topic.EndsWith(AppTopics.TOPIC_APP_ERROR))
            {
                await AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Application error received with topic {e.ApplicationMessage.Topic}, error is:{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}", true);
            }
            else
            {
                await AppendMessage($"{DateTime.Now.ToString(TIME_FORMAT)}-Application data received with topic {e.ApplicationMessage.Topic}, payload size {e.ApplicationMessage.Payload?.Length} (bytes)");
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
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_SYSTEM_TIMESTATUS))
                {
                    var app = Utility.JsonDeserialize<List<MQTTDeviceTimeStatus>>(msg.Payload).FirstOrDefault();
                    if (app.Year > 0)
                    {
                        lblNTPTime.Visible = true;
                        lblNTPTime.Text = $"{app.Year}/{app.Month:d2}/{app.Day:d2} {app.Hour:d2}:{app.Minute:d2}:{app.Second:d2} {app.Millisecond:d3}ms,{app.Microsecond:d3}µs";
                    }
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
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_MIMO_RANDOM_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTMIMORandomTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_MIMO_SINE_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTMIMOSineTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_MIMO_SHOCK_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTMIMOShockTestStatus>(msg.Payload));
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_MIMO_TWR_STATUS))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTMIMOTWRTestStatus>(msg.Payload));
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

                        if (thvStatus.LatestTemperatures != null)
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
                        if (thvStatus.LatestHumdities != null)
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
                else if (msg.Topic.EndsWith(THVTopics.TOPIC_THV_TEST_VIB_STATUS))
                {
                    var vibStatus = Utility.JsonDeserialize<MQTTVibStatus>(msg.Payload);


                    try
                    {
                        lvVibStatus.BeginUpdate();
                        lvVibStatus.Items.Clear();

                        var lvi = new ListViewItem(nameof(vibStatus.TotalTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, vibStatus.TotalTime.ToString("f3")));
                        lvVibStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(vibStatus.RemainTime));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, vibStatus.RemainTime.ToString("f3")));
                        lvVibStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(vibStatus.TargetVibration));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, vibStatus.TargetVibration.ToString("f3")));
                        lvVibStatus.Items.Add(lvi);

                        lvi = new ListViewItem(nameof(vibStatus.ControlVibration));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, vibStatus.ControlVibration.ToString("f3")));
                        lvVibStatus.Items.Add(lvi);

                        if (vibStatus.LatestVibrations != null)
                            foreach (var tp in vibStatus.LatestVibrations)
                            {
                                lvi = new ListViewItem(tp.Name);
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, $"{tp.Vibration.ToString("f3")} ({tp.Unit})"));
                                lvVibStatus.Items.Add(lvi);
                            }

                    }
                    finally
                    {
                        lvVibStatus.EndUpdate();
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
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_SHAKER))
                {
                    ShowNameAndValue(Utility.JsonDeserialize<MQTTShakerData>(msg.Payload), lvShaker);
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
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_CHANNELSTATUS))
                {
                    var app = Utility.JsonDeserialize<List<MQTTChannelStatus>>(msg.Payload);

                    try
                    {
                        lvChannelStatus.BeginUpdate();
                        lvChannelStatus.Items.Clear();
                        foreach (var m in app)
                        {
                            var lvi = new ListViewItem(m.LocationId);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Min.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Max.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Peak.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.RMS.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.Average.ToString("f5")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.IsIEPE.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.IsOverload.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, m.IsStrainGageNotConnected.ToString()));
                            lvChannelStatus.Items.Add(lvi);
                        }
                    }
                    finally
                    {
                        lvChannelStatus.EndUpdate();
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
                            if (kp.Value != null)
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

                        string srcSelected = cbxTriggerSource.SelectedItem?.ToString();                       
                        cbxTriggerSource.Items.Clear();
                        foreach (var kp in app)
                        {
                            var lvi = new ListViewItem(kp.Name);
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.Type));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.BlockSize.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.SamplingRate.ToString("f2")));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.UnitX));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.UnitY));
                            lvSignals.Items.Add(lvi);
                            if (kp.Type == "Equidistant"
                            && !(kp.Name.StartsWith("RMS") || kp.Name.StartsWith("Peak")
                                || kp.Name.StartsWith("PkPk") || kp.Name.StartsWith("Mean")
                                || kp.Name.StartsWith("Min") || kp.Name.StartsWith("Max")))
                            {
                                cbxTriggerSource.Items.Add(kp.Name);
                            }
                        }

                        if (cbxTriggerSource.Items.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(srcSelected))
                            {
                                var idx = cbxTriggerSource.FindString(srcSelected);
                                if (idx == -1) idx = 0;
                                cbxTriggerSource.SelectedIndex = idx;
                            }
                            else
                            {
                                cbxTriggerSource.SelectedIndex = 0;
                            }
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
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "RMS" ? kp.Value.ToString("f3") : ZERO_STRING));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Peak" ? kp.Value.ToString("f3") : ZERO_STRING));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "PkPk" ? kp.Value.ToString("f3") : ZERO_STRING));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Min" ? kp.Value.ToString("f3") : ZERO_STRING));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Max" ? kp.Value.ToString("f3") : ZERO_STRING));
                                slvi.SubItems.Add(new ListViewItem.ListViewSubItem(slvi, kp.PropertyName == "Mean" ? kp.Value.ToString("f3") : ZERO_STRING));
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
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_SIGNALDATA) ||
                msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_SINGLESIGNALDATA))
                {
                    var app = Utility.JsonDeserialize<List<MQTTSignalFrameData>>(msg.Payload);

                    ShowSignals(app);
                }
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_COMPRESSED_SIGNALDATA) ||
                msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_COMPRESSED_SINGLESIGNALDATA))
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
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_REPORTNOTES))
                {
                    var app = Utility.JsonDeserialize<MQTTReportNote[]>(msg.Payload);


                    try
                    {
                        lvReportNotes.BeginUpdate();

                        try
                        {

                            lvReportNotes.BeginUpdate();
                            lvReportNotes.Items.Clear();
                            foreach (var kp in app)
                            {
                                var lvi = new ListViewItem(kp.Name);
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, kp.Content));
                                lvReportNotes.Items.Add(lvi);
                            }
                        }
                        finally
                        {
                            lvReportNotes.EndUpdate();
                        }

                    }
                    finally
                    {
                        lvReportNotes.EndUpdate();
                    }
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
                else if (msg.Topic.EndsWith(AppTopics.TOPIC_APP_TEST_REPORTTEMPLATES))
                {
                    var app = Utility.JsonDeserialize<MQTTReportTemplates>(msg.Payload);
                    var preSelectedTemplate = string.Empty;
                    if (cbxReportTemplates.SelectedItem != null)
                    {
                        preSelectedTemplate = cbxReportTemplates.SelectedItem.ToString();
                    }
                    cbxReportTemplates.Items.Clear();
                    if (app.Templates?.Length > 0)
                    {

                        foreach (var t in app.Templates)
                        {
                            cbxReportTemplates.Items.Add(t);
                        }

                        if (string.IsNullOrEmpty(preSelectedTemplate))
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
                        Trace.TraceError(ex.ToString());
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
                else if (msg.Topic.EndsWith(DSATopics.TOPIC_DSA_TEST_TRIGGER_SETTINGS))
                {
                    ShowTriggerSettings(e.ApplicationMessage);
                }
                else if (msg.Topic.EndsWith(DSATopics.TOPIC_DSA_TEST_TRIGGER_FRAME))
                {
                    ShowTriggerFrame(e.ApplicationMessage);
                }
                else if (msg.Topic.EndsWith(VCSTopics.TOPIC_VCS_TEST_MASS))
                {
                    var app = Utility.JsonDeserialize<MQTTMassParameters>(msg.Payload);
                    nudUUTMass.Value = (decimal)app.UUTMass;
                    nudFixtureMass.Value = (decimal)app.FixtureMass;
                }


            }, CancellationToken.None, TaskCreationOptions.PreferFairness, UIScheduler);

            void ShowTriggerFrame(MqttApplicationMessage msg)
            {
                var triggerChart = zgcTrigger;
                if (triggerChart.IsDisposed || triggerChart.Disposing)
                    return;

                var sig = Utility.JsonDeserialize<MQTTSignalFrameData>(msg.Payload);


                try
                {
                    triggerChart.SuspendLayout();
                    triggerChart.GraphPane.CurveList.Clear();


                    triggerChart.GraphPane.Title.Text = $"Signal Triggered - {sig.Signal.Timestamp}";
                    triggerChart.GraphPane.Title.FontSpec.FontColor = Color.Black;
                    triggerChart.GraphPane.Title.FontSpec.IsBold = false;



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
                        triggerChart.GraphPane.Title.Text = $"No signal data of - {sig.Signal.Name}";
                        triggerChart.GraphPane.Title.FontSpec.FontColor = Color.Red;
                        triggerChart.GraphPane.Title.FontSpec.IsBold = true;
                        triggerChart.Invalidate();
                        return;
                    }

                    triggerChart.GraphPane.XAxis.Title.Text = sig.Signal.UnitX;
                    triggerChart.GraphPane.YAxis.Title.Text = sig.Signal.UnitY;

                    var firstVal = sig.ValueX[0];
                    sig.ValueX = sig.ValueX.Select(t => (t - firstVal)).ToArray();

                    triggerChart.GraphPane.XAxis.Type = AxisType.Linear;
                    triggerChart.GraphPane.YAxis.Type = AxisType.Linear;

                    var xData = sig.ValueX;
                    var yData = sig.ValueY;

                    if (xData != null && yData != null)
                    {
                        var color = Utility.COLORS[Math.Abs(sig.Signal.Name.GetHashCode()) % Utility.COLORS.Length];
                        triggerChart.GraphPane.AddCurve(sig.Signal.Name, xData, yData, color, SymbolType.None);
                    }

                    triggerChart.GraphPane.XAxis.Scale.MinAuto = true;
                    triggerChart.GraphPane.XAxis.Scale.MaxAuto = true;
                    triggerChart.GraphPane.YAxis.Scale.MinAuto = true;
                    triggerChart.GraphPane.YAxis.Scale.MaxAuto = true;
                    triggerChart.GraphPane.AxisChange();
                    triggerChart.Invalidate();

                }
                finally
                {
                    triggerChart.ResumeLayout(true);
                }
            }

            void ShowTriggerSettings(MqttApplicationMessage msg)
            {
                var app = Utility.JsonDeserialize<MQTTTriggerSettings>(msg.Payload);
                cbxTriggerCondition.SelectedIndex = app.TriggerType;
                cbxTriggerMode.SelectedIndex = app.TriggerMode;
                if (!string.IsNullOrEmpty(app.TriggerSource))
                {
                    var index = cbxTriggerSource.FindStringExact(app.TriggerSource);
                    if (index > -1)
                    {
                        cbxTriggerSource.SelectedIndex = index;
                    }
                }
                nudHighLevel.Value = (decimal)app.HighLevel;
                nudLowLevel.Value = (decimal)app.LowLevel;
                nudDelayPoints.Value = app.DelayPoints;
            }

            void ShowFreqVSPeakChart(MQTTAdvancedStatus app)
            {
                if (!ckbPFFV.Checked) return;

                PeakValueHandler.Add(app);

                if (app.Name == PeakValueHandler.PeakFrequency)
                {
                    if (float.TryParse(app.Value, out var freq))
                    {
                        tbPeakFreqValue.Text = $"{freq:f3}";
                    }

                    lblPeakFreqUnit.Text = $"{PeakValueHandler.UnitX}";
                }
                else if (app.Name == PeakValueHandler.PeakValue)
                {
                    if (float.TryParse(app.Value, out var pk))
                    {
                        tbPeakValue.Text = $"{pk:f5}";
                    }
                    lblPeakValueUnit.Text = $"{PeakValueHandler.UnitY}";
                }


                var freqVsPeakChart = this.zedGraphControl1;

                if (freqVsPeakChart.IsDisposed || freqVsPeakChart.Disposing || !PeakValueHandler.HasData)
                    return;

                try
                {

                    freqVsPeakChart.SuspendLayout();


                    freqVsPeakChart.GraphPane.Title.Text = $"Peak vs Frequency";
                    freqVsPeakChart.GraphPane.Title.FontSpec.FontColor = Color.Black;
                    freqVsPeakChart.GraphPane.Title.FontSpec.IsBold = false;


                    freqVsPeakChart.GraphPane.XAxis.Title.Text = PeakValueHandler.UnitX;
                    freqVsPeakChart.GraphPane.YAxis.Title.Text = PeakValueHandler.UnitY;
                    freqVsPeakChart.GraphPane.XAxis.Type = AxisType.Log;
                    freqVsPeakChart.GraphPane.YAxis.Type = AxisType.Linear;

                    freqVsPeakChart.GraphPane.XAxis.MajorGrid.IsVisible = true;
                    freqVsPeakChart.GraphPane.XAxis.MinorGrid.IsVisible = true;
                    freqVsPeakChart.GraphPane.XAxis.Scale.Format = "f2";
                    freqVsPeakChart.GraphPane.XAxis.Scale.IsUseTenPower = false;
                    freqVsPeakChart.GraphPane.XAxis.Scale.MajorStepAuto = true;
                    freqVsPeakChart.GraphPane.XAxis.Scale.MinorStepAuto = true;
                    freqVsPeakChart.GraphPane.XAxis.Scale.Mag = 1;
                    freqVsPeakChart.GraphPane.XAxis.MinorTic.IsAllTics = true;
                    freqVsPeakChart.GraphPane.XAxis.MinorTic.IsInside = false;
                    freqVsPeakChart.GraphPane.XAxis.MinorTic.IsOpposite = false;
                    freqVsPeakChart.GraphPane.XAxis.MinorTic.IsOutside = true;


                    freqVsPeakChart.GraphPane.YAxis.MajorGrid.IsVisible = true;
                    freqVsPeakChart.GraphPane.YAxis.MinorGrid.IsVisible = true;

                    var data = PeakValueHandler.GetData(ckbAutoRefresh.Checked);

                    var xData = data[0];
                    var yData = data[1];

                    if (xData != null && yData != null && freqVsPeakChart.GraphPane.CurveList.Count == 0)
                    {
                        freqVsPeakChart.GraphPane.AddCurve("PeakVsFreq", xData, yData, Color.Blue, SymbolType.None);

                        freqVsPeakChart.GraphPane.XAxis.Scale.Min = 0;
                        freqVsPeakChart.GraphPane.XAxis.Scale.Max = 5000;
                    }
                    else
                    {
                        var lineItem = freqVsPeakChart.GraphPane.CurveList[0] as LineItem;
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

                    if (freqVsPeakChart.GraphPane.ZoomStack.Count == 0)
                    {
                        freqVsPeakChart.GraphPane.YAxis.Scale.MinAuto = true;
                        freqVsPeakChart.GraphPane.YAxis.Scale.MaxAuto = true;
                        freqVsPeakChart.GraphPane.AxisChange();
                    }

                    freqVsPeakChart.Invalidate();

                    if (ckbAutoRefresh.Checked)
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
                    freqVsPeakChart.ResumeLayout(true);
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
                        var val = fi.GetValue(ss);

                        if (val is double[] array && array.Length > 0)
                        {
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, string.Join(", ", array).TrimEnd()));
                        }
                        else
                        {
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, val.ToString()));
                        }

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

                if (obj is JObject jo && jo.TryGetValue("Item1", out var jtoken) && jtoken is JValue jv && jv.Value != null)
                {


                    if (jv.Value.ToString() == CommandKey.ListGlobalParameters && jo.TryGetValue("Item2", out var jtoken2) && jtoken2 is JArray ja)
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


                                if (s.Data.Count > 0)
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
                                Trace.TraceError(ex.ToString());
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
                                foreach (var r in t.Rows.Where(row => row.Value != null))
                                {
                                    var dr = dt.NewRow();
                                    dr.ItemArray = r.Value.ToArray();
                                    dt.Rows.Add(dr);
                                }

                                dataGridView.DataSource = dt;

                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError(ex.ToString());
                            }

                        }
                    }
                }

            }
        }

        static string GetParameterDescription(string key)
        {   
            switch (key)
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

        void OnProtocolSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveProtocolSettings();
        }

        void OnTLSSelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTLSSettings();
        }

        async void OnConnectClick(object sender, EventArgs e)
        {
            UpdateClientModel();
            await Client.Connect(Model);
        }

        async void OnDisconnectClick(object sender, EventArgs e)
        {
            await Client.Disconnect();
        }

        void OnParametersSelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lvParameters.SelectedItems.OfType<ListViewItem>().FirstOrDefault();
            if(item != null)
            {
                lblParameterName.Text = item.Text;
                tbParameterValue.Text = item.SubItems[1].Text;
            }
        }

        void OnBrowseReportDirClick(object sender, EventArgs e)
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

        void OnBrowseFileDirClick(object sender, EventArgs e)
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

        void OnExecuteCommand(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag != null)
            {
                var cmd = btn.Tag.ToString();
                string topic;
                if (rbDSACommand.Checked)
                {
                    topic = rbPlainTextCommand.Checked ? DSATopics.TOPIC_DSA_TEST_COMMAND : DSATopics.TOPIC_DSA_TEST_COMMANDEX;
                }
                else
                {
                    topic = rbPlainTextCommand.Checked ? VCSTopics.TOPIC_VCS_TEST_COMMAND : VCSTopics.TOPIC_VCS_TEST_COMMANDEX;
                }

                if (tabPageOutput == tabControlTest.SelectedTab)
                {
                    topic = rbPlainTextCommand.Checked ? DSATopics.TOPIC_DSA_TEST_COMMAND : DSATopics.TOPIC_DSA_TEST_COMMANDEX;
                }

                if (tabPageProfile == tabControlTest.SelectedTab)
                {
                    topic = rbPlainTextCommand.Checked ? VCSTopics.TOPIC_VCS_TEST_COMMAND : VCSTopics.TOPIC_VCS_TEST_COMMANDEX;
                }

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
                else if (btn == btnSetReportNotes)
                {
                    if (lvReportNotes.Items.Count > 0)
                    {
                        PublishWithValue(GetReportNotes());
                    }
                }
                else if (btn == btnShutdownPC)
                {
                    PublishWithValue(nudShutdownPCDelay.Value);
                }
                else if (btn == btnSetInputRange)
                {
                    PublishWithValue($"{cbxInputRange.SelectedItem};{nudChannelIndex.Value}");
                }
                else if (btn == btnSetNTP)
                {
                    PublishWithValue($"{tbNTPServer.Text};{nudNTPPort.Value};{nudNTPSynchInterval.Value}");
                }
                else if (btn == btnSetTriggerSettings)
                {
                    PublishWithValue(Utility.JsonSerializer(GetTriggerSetttings()));
                }
                else if (btn == btnSetShakerParameters)
                {
                    PublishWithValue(Utility.JsonSerializer(GetShakerParameters()));
                }
                else if (btn == btnSetMassParameters)
                {
                    PublishWithValue(Utility.JsonSerializer(new MQTTMassParameters()
                    {
                        UUTMass = (double)nudUUTMass.Value,
                        FixtureMass = (double)nudFixtureMass.Value,
                    }));
                }
                else if (btn == btnSetSimpleShockProfile)
                {
                    var profile = GetShockSimpleProfile();
                    if (profile != null)
                    {
                        PublishWithValue(Utility.JsonSerializer(profile.Value));
                    }
                }
                else if (btn == btnSetSimpleSineProfile)
                {
                    var profile = GetSineSimpleProfile();
                    if (profile != null)
                    {
                        PublishWithValue(Utility.JsonSerializer(profile.Value));
                    }
                }
                else if (btn == btnSetSimpleRandomProfile)
                {
                    var profile = GetRandomSimpleProfile();
                    if (profile != null)
                    {
                        PublishWithValue(Utility.JsonSerializer(profile.Value));
                    }
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
                        try
                        {
                            Clipboard.SetText(cmd);
                        }
                        catch { }
                        

                        var options = new PublishOptionsModel()
                        {
                            Topic = $"{Settings.Default.TopicPrefix}/{topic}",
                            Retain = false,
                            Payload = rbPlainTextCommand.Checked ?
                                        Encoding.UTF8.GetBytes(cmd)
                                      : Encoding.UTF8.GetBytes(Utility.JsonSerializer(new MQTTCommand() { Type = cmd }))
                        };
                        await Client.Publish(options);

                        await AppendPublishLog(topic, cmd);
                    }
                    else
                        ShowNotConnectedStatus();
                }


                async void PublishWithValue(object val)
                {
                    ClearNotConnectedStatus();
                    if (Client.IsConnected)
                    {
                        try
                        {
                            Clipboard.SetText($"{cmd};{val}");
                        }
                        catch {}
                        

                        var options = new PublishOptionsModel()
                        {
                            Topic = $"{Settings.Default.TopicPrefix}/{topic}",
                            Retain = false,
                            Payload = rbPlainTextCommand.Checked ?
                                    Encoding.UTF8.GetBytes($"{cmd};{val}")
                                  : Encoding.UTF8.GetBytes(Utility.JsonSerializer(toMQTTCommand()))
                        };
                        await Client.Publish(options);

                        await AppendPublishLog(topic, $"{cmd};{val}");
                    }
                    else
                        ShowNotConnectedStatus();

                    MQTTCommand toMQTTCommand()
                    {
                        var mc = new MQTTCommand()
                        {
                            Type = cmd
                        };
                        var cmds = val.ToString().Split(';');
                        var parameters = new Dictionary<string, string>();
                        for (int i = 0; i < cmds.Length; i++)
                        {
                            parameters[$"{COMMAND_PARAMETER_PREFIX}{i}"] = cmds[i];
                        }
                        mc.Parameters = parameters;
                        return mc;
                    }
                }
            }
        }

        void OnSelectAll(object sender, EventArgs e)
        {
            cbRMS.Checked = cbPeak.Checked = cbPkPk.Checked = cbMin.Checked = cbMax.Checked = cbMean.Checked = true;
        }

        void OnSelectInverse(object sender, EventArgs e)
        {
            cbRMS.Checked = !cbRMS.Checked;
            cbPeak.Checked = !cbPeak.Checked;
            cbPkPk.Checked = !cbPkPk.Checked;
            cbMin.Checked = !cbMin.Checked;
            cbMax.Checked = !cbMax.Checked;
            cbMean.Checked = !cbMean.Checked;
        }

        void OnGetSignalProperty(object sender, EventArgs e)
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
                await AppendPublishLog(AppTopics.TOPIC_APP_TEST_COMMAND, $"{CommandKey.RequestSignalProperty};{cb.Text}{names}");
                await Task.Delay(100);
            }

        }

        async void OnSignalItemCheckChanged(object sender, ItemCheckedEventArgs e)
        {
            if(tabPageSignal == tabControlDemo.SelectedTab)
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

                    await AppendPublishLog(AppTopics.TOPIC_APP_TEST_COMMAND, $"{CommandKey.RequestSignalData}{names}");
                }
                else
                    ShowNotConnectedStatus();
            }
        }

        void OnReportFileMouseDoubleClick(object sender, MouseEventArgs e)
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

        void OnRecordFileMouseDoubleClick(object sender, MouseEventArgs e)
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

        async void OnPublishMessage(object sender, EventArgs e)
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

                    await AppendPublishLog(AppTopics.TOPIC_APP_MESSAGE, tbMessage.Text);
                }
                else
                    ShowNotConnectedStatus();
            }
        }

        void OnClearMessages(object sender, EventArgs e)
        {
            rtbMessages.Clear();
        }
        void OnOutputTypeCheckedChanged(object sender, EventArgs e)
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

        void OnBrowseProfile(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                if (sender == btnBrowseSchedule)
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

        async void OnAdvancedCommand(object sender, EventArgs e)
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
                else if (sender == btnSetSchedule)
                {
                    cmd = CommandKey.SetSchedule;
                    profile = File.ReadAllText(tbSchedulePath.Text);
                }

                if (Client.IsConnected && !string.IsNullOrWhiteSpace(cmd) && !string.IsNullOrWhiteSpace(profile))
                {
                    var topic = rbPlainTextCommand.Checked ? VCSTopics.TOPIC_VCS_TEST_COMMAND : VCSTopics.TOPIC_VCS_TEST_COMMANDEX;

                    var options = new PublishOptionsModel()
                    {
                        Topic = $"{Settings.Default.TopicPrefix}/{topic}",
                        Retain = false,
                        Payload = Encoding.UTF8.GetBytes(getPayload())
                    };
                    await Client.Publish(options);

                    await AppendPublishLog(topic, $"{cmd}");

                    string getPayload()
                    {
                        if (rbPlainTextCommand.Checked)
                            return $"{cmd};{profile}";
                        else
                        {
                            MQTTCommand mc = new MQTTCommand
                            {
                                Type = cmd,
                                Parameters = new Dictionary<string, string>
                                {
                                    [$"{COMMAND_PARAMETER_PREFIX}0"] = profile
                                }
                            };

                            return Utility.JsonSerializer(mc);
                        }
                    }
                }

                if (!Client.IsConnected)
                    ShowNotConnectedStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        async void OnListGlobalParameters(object sender, EventArgs e)
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
                await AppendPublishLog(options.Topic, String.Empty);
            }
            else
                ShowNotConnectedStatus();


        }

        async void OnGetGlobalParameter(object sender, EventArgs e)
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
                await AppendPublishLog(options.Topic, items[0].Text);
            }

            if (!Client.IsConnected)
                ShowNotConnectedStatus();
        }

        void OnGlobalParametersSelectedIndexChanged(object sender, EventArgs e)
        {
            OnGetGlobalParameter(sender, e);
        }

        void OnCopyJsonContent(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbGlobalParameter.Text))
                return;

            Clipboard.SetText(rtbGlobalParameter.Text);
        }

        async void OnPFFVCheckedChanged(object sender, EventArgs e)
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

                if (string.IsNullOrEmpty(tbPeakValueSource.Text))
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

            await AppendPublishLog(VCSTopics.TOPIC_VCS_TEST_COMMAND, cmdFreq);


            options = new PublishOptionsModel()
            {
                Topic = $"{Settings.Default.TopicPrefix}/{VCSTopics.TOPIC_VCS_TEST_COMMAND}",
                Retain = false,
                Payload = Encoding.UTF8.GetBytes(cmdVal)
            };
            await Client.Publish(options);

            await AppendPublishLog(VCSTopics.TOPIC_VCS_TEST_COMMAND, cmdVal);
        }

        void OnTimestampMatchOffsetValueChanged(object sender, EventArgs e)
        {
            PeakValueHandler.TimeMatchOffset = (int)nudTimestampMatchOffset.Value;
        }

        void OnExportFreqVsPeakClick(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV files(*.csv)|*.csv";
                dlg.FileName = "PeakVsFreq";
                if (dlg.ShowDialog(this.TopLevelControl) == DialogResult.OK)
                {
                    Utility.ExportCSV(dlg.FileName, this.dataGridViewFreqVsPeak, out _,
                         invariantCulture: true, excludeCol: ckbExcludedB.Checked ? 1 : -1);
                }
            }
        }

        void OnRefreshFreqVsPeakClick(object sender, EventArgs e)
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

        void OnResetFreqVsPeakClick(object sender, EventArgs e)
        {
            PeakValueHandler.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
        }

        void OnReportNotesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvReportNotes.SelectedItems.Count > 0)
            {
                var item = lvReportNotes.SelectedItems.OfType<ListViewItem>().First();

                if (item != null)
                {
                    tbReportNoteName.Text = item.Text;
                    tbReportNoteContent.Text = item.SubItems[1].Text;
                }
            }

        }

        void OnUpdateReportNote(object sender, EventArgs e)
        {
            try
            {
                lvReportNotes.BeginUpdate();

                foreach (var item in lvReportNotes.Items.OfType<ListViewItem>())
                {
                    if (item.Text == tbReportNoteName.Text)
                    {
                        item.SubItems[1].Text = tbReportNoteContent.Text;
                        return; // Exit the loop once the item is found and updated
                    }
                }
            }
            finally
            {
                lvReportNotes.EndUpdate();
            }
        }

        void OnAddReportNote(object sender, EventArgs e)
        {
            try
            {
                lvReportNotes.BeginUpdate();
                bool asUpdate = false;
                foreach (var item in lvReportNotes.Items.OfType<ListViewItem>())
                {
                    if (item.Text == tbReportNoteName.Text)
                    {
                        item.SubItems[1].Text = tbReportNoteContent.Text;
                        asUpdate = true;
                        return; // Exit the loop once the item is found and updated
                    }
                }

                if (!asUpdate)
                {
                    ListViewItem lvi = new ListViewItem(tbReportNoteName.Text);
                    lvi.SubItems.Add(tbReportNoteContent.Text);
                    lvReportNotes.Items.Add(lvi);
                }
            }
            finally
            {
                lvReportNotes.EndUpdate();
            }
        }

        void OnDeleteReportNote(object sender, EventArgs e)
        {
            try
            {
                lvReportNotes.BeginUpdate();

                foreach (var item in lvReportNotes.Items.OfType<ListViewItem>())
                {
                    if (item.Text == tbReportNoteName.Text)
                    {
                        lvReportNotes.Items.Remove(item);
                        return; // Exit the loop once the item is found and removed
                    }
                }
            }
            finally
            {
                lvReportNotes.EndUpdate();
            }
        }

        void OnBrowseCACertificateFile(object sender, EventArgs e)
        {
            BrowseFile(tbCACertificateFile);
            Settings.Default.CACertificateFile = tbCACertificateFile.Text;
            Settings.Default.Save();
        }

        void OnBrowseClientCertificateFile(object sender, EventArgs e)
        {
            BrowseFile(tbClientCertificateFile);
            Settings.Default.ClientCertificateFile = tbClientCertificateFile.Text;
            Settings.Default.Save();
        }

        void OnBrowseClientPrivateKeyFile(object sender, EventArgs e)
        {
            BrowseFile(tbClientPrivateKeyFile);
            Settings.Default.ClientCertificatePrivateKeyFile = tbClientPrivateKeyFile.Text;
            Settings.Default.Save();
        }

        void OnShakerItemSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvShaker.SelectedItems.Count > 0)
            {
                var item = lvShaker.SelectedItems[0];
                lblShakerParameterName.Text = item.Text;
                tbShakerParameter.Text = item.SubItems[1].Text;
            }
        }

        void OnUpdateShakerParameter(object sender, EventArgs e)
        {
            if (lvShaker.SelectedItems.Count > 0)
            {
                var item = lvShaker.SelectedItems[0];
                item.SubItems[1].Text = tbShakerParameter.Text;
            }
        }


        void OnAddRandomProfileRow(object sender, EventArgs e)
        {
            dgvRandomProfile.Rows.Add(10f * (dgvRandomProfile.Rows.Count + 1) * 2, 0.00273233f, 6f, 3f, -3f, -6f);
        }

        void OnDeleteRandomProfileRow(object sender, EventArgs e)
        {
            var selectedRows = dgvRandomProfile.SelectedRows.OfType<DataGridViewRow>();
            if (selectedRows.Any())
            {
                dgvRandomProfile.Rows.Remove(selectedRows.First());
            }
        }

        void OnAddSineProfileRow(object sender, EventArgs e)
        {
            dgvSineProfile.Rows.Add(50 * (dgvSineProfile.Rows.Count + 1), 1, 9, 6f, 3f, -3f, -6f);
        }

        void OnDeleteSineProfileRow(object sender, EventArgs e)
        {
            var selectedRows = dgvSineProfile.SelectedRows.OfType<DataGridViewRow>();
            if (selectedRows.Any())
            {
                dgvSineProfile.Rows.Remove(selectedRows.First());
            }
        }
        #endregion

    }
}

