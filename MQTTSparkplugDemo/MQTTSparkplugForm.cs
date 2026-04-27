using System;
using System.Collections.Generic;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using SparkplugNet.Core.Application;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using MQTTSparkplugCSharpExample.Properties;

using MqttClientConnectedEventArgs = MQTTnet.Client.MqttClientConnectedEventArgs;
using MqttClientDisconnectedEventArgs = MQTTnet.Client.MqttClientDisconnectedEventArgs;

namespace MQTTSparkplugDemo
{
    public partial class MQTTSparkplugForm : Form
    {
        private SparkplugApplication application;
        private const string setCommandNodeInstructions = "Set Command Node Id Using TextBox Below";

        private string BrokerAddress {
            get { return ipAddressInput1.Text; }
        }
        private int BrokerPort
        {
            get { return Convert.ToInt32(iiPort.Text); }
        }

        private string ClientId
        {
            get { return tbClientId.Text; }
        }

        private string Username
        {
            get { return tbUser.Text; }
        }

        private string Password
        {
            get { return tbPassword.Text; }
        }

        private bool UseTLS
        {
            get { return false; }
        }

        private bool IsPrimaryApplication
        {
            get { return true; }
        }

        private string ScadaId
        {
            get { return tbScadaId.Text; }
        }

        private string GroupId
        {
            get { return tbGroupId.Text; }
        }

        private string EdgeNodeId
        {
            get { return tbEdgeNodeId.Text; }
        }

        private string CommandNodeId
        {
            get;
            set;
        }

        private List<Metric> applicationMetrics;
        private List<Metric> ApplicationMetrics
        {
            get { return applicationMetrics; }
        }

        public MQTTSparkplugForm()
        {
            applicationMetrics = new List<Metric>();
            InitializeComponent();
            InitializeControls();
            InitializeTags();
            SetDisconnectedState();
            HookEvents(true);

            // Adding the metrics that the application should know about.
            foreach (Metric m in MetricNames.CommonMetrics)
                ApplicationMetrics.Add(m);
            foreach (Metric m in MetricNames.VCSMetrics)
                ApplicationMetrics.Add(m);
            foreach (Metric m in MetricNames.DSAMetrics)
                ApplicationMetrics.Add(m);
            foreach (Metric m in MetricNames.THVMetrics)
                ApplicationMetrics.Add(m);
        }

        private void OnConnected(MqttClientConnectedEventArgs args)
        {
            Console.WriteLine("Connected");
            SetConnectedState();
        }

        private void OnDisconnected(MqttClientDisconnectedEventArgs args)
        {
            Console.WriteLine("Disconnected");
            SetDisconnectedState();
        }

        private void HookEvents(bool hook)
        {
            if (hook)
            {
                HookEvents(false);
                btnConnect.Click += OnButtonClicked;
                btnDisconnect.Click += OnButtonClicked;
                btnRun.Click += OnButtonClicked;
                btnPause.Click += OnButtonClicked;
                btnContinue.Click += OnButtonClicked;
                btnStop.Click += OnButtonClicked; 
                btnStartRecord.Click += OnButtonClicked;
                btnStopRecord.Click += OnButtonClicked;
                btnSaveSignals.Click += OnButtonClicked;
                btnStartTestSequence.Click += OnButtonClicked;
                btnNextTestSequence.Click += OnButtonClicked;
                btnPauseTestSequence.Click += OnButtonClicked;
                btnResumeTestSequence.Click += OnButtonClicked;
                btnStopTestSequence.Click += OnButtonClicked;
                btnChangeEdgeNode.Click += OnChangeEdgeNodeClicked;
                this.FormClosed += MQTTSparkplugForm_FormClosed;
            }
            else
            {
                btnConnect.Click -= OnButtonClicked;
                btnDisconnect.Click -= OnButtonClicked;
                btnRun.Click -= OnButtonClicked;
                btnPause.Click -= OnButtonClicked;
                btnContinue.Click -= OnButtonClicked;
                btnStop.Click -= OnButtonClicked;
                btnStartRecord.Click -= OnButtonClicked;
                btnStopRecord.Click -= OnButtonClicked;
                btnSaveSignals.Click -= OnButtonClicked;
                btnStartTestSequence.Click += OnButtonClicked;
                btnNextTestSequence.Click -= OnButtonClicked;
                btnPauseTestSequence.Click -= OnButtonClicked;
                btnResumeTestSequence.Click -= OnButtonClicked;
                btnStopTestSequence.Click -= OnButtonClicked;
                btnChangeEdgeNode.Click -= OnChangeEdgeNodeClicked;
                this.FormClosed -= MQTTSparkplugForm_FormClosed;
            }
        }

        private void InitializeControls()
        {
            ipAddressInput1.Text = Settings.Default.ClientIP;
            iiPort.Text = Settings.Default.ClientPort.ToString();
            tbUser.Text = Settings.Default.UserName;
            tbPassword.Text = Settings.Default.Password;
            tbClientId.Text = Settings.Default.ClientID;
            tbScadaId.Text = Settings.Default.ScadaHostIdentifier;
            tbGroupId.Text = Settings.Default.GroupIdentifier;
            tbEdgeNodeId.Text = Settings.Default.EdgeNodeIdentifier;
        }

        private void MQTTSparkplugForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool IsControlTextEmpty(Control control)
            { 
                return string.IsNullOrEmpty(control.Text);
            }

            if (ipAddressInput1 != null && !IsControlTextEmpty(ipAddressInput1))
            { 
                Settings.Default.ClientIP = ipAddressInput1.Text;
            }

            if (iiPort != null && !IsControlTextEmpty(iiPort))
            {
                Settings.Default.ClientPort = Convert.ToInt32(iiPort.Text);
            }

            if (tbUser != null && !IsControlTextEmpty(tbUser))
            {
                Settings.Default.UserName = tbUser.Text;
            }

            if (tbPassword != null && !IsControlTextEmpty(tbPassword))
            {
                Settings.Default.Password = tbPassword.Text;
            }

            if (tbClientId != null && !IsControlTextEmpty(tbClientId))
            {
                Settings.Default.ClientID = tbClientId.Text;
            }

            if (tbScadaId != null && !IsControlTextEmpty(tbScadaId))
            {
                Settings.Default.ScadaHostIdentifier = tbScadaId.Text;
            }

            if (tbGroupId != null && !IsControlTextEmpty(tbGroupId))
            {
                Settings.Default.GroupIdentifier = tbGroupId.Text;
            }

            if (tbEdgeNodeId != null && !IsControlTextEmpty(tbEdgeNodeId))
            {
                Settings.Default.EdgeNodeIdentifier = tbEdgeNodeId.Text;
            }

            Settings.Default.Save();
        }

        private void OnChangeEdgeNodeClicked(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender == null)
            {
                return;
            }
            using (ChangeCommandEdgeNodeForm frm = new ChangeCommandEdgeNodeForm(CommandNodeId, setCommandNodeInstructions))
            {
                frm.ShowDialog(this);
                if (frm.DialogResult == DialogResult.OK)
                {
                    CommandNodeId = frm.NewCommandEdgeNode;
                }
            }
        }

        private void InitializeTags()
        {
            btnConnect.Tag = MetricNames.METRIC_NCMD_CONNECT;
            btnDisconnect.Tag = MetricNames.METRIC_NCMD_DISCONNECT;
            btnRun.Tag = MetricNames.METRIC_NCMD_RUN;
            btnPause.Tag = MetricNames.METRIC_NCMD_PAUSE;
            btnContinue.Tag = MetricNames.METRIC_NCMD_CONTINUE;
            btnStop.Tag = MetricNames.METRIC_NCMD_STOP;
            btnStartRecord.Tag = MetricNames.METRIC_NCMD_STARTRECORD;
            btnStopRecord.Tag = MetricNames.METRIC_NCMD_STOP;
            btnSaveSignals.Tag = MetricNames.METRIC_NCMD_SAVESIGNALS;
            btnStartTestSequence.Tag = MetricNames.METRIC_NCMD_STARTTESTSEQUENCE;
            btnNextTestSequence.Tag = MetricNames.METRIC_NCMD_NEXTTESTSEQUENCE;
            btnPauseTestSequence.Tag = MetricNames.METRIC_NCMD_PAUSETESTSEQUENCE;
            btnResumeTestSequence.Tag = MetricNames.METRIC_NCMD_RESUMETESTSEQUENCE;
            btnStopTestSequence.Tag = MetricNames.METRIC_NCMD_STOPTESTSEQUENCE;
        }

        private void OnListGlobalParameters(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender == null || btnSender.Tag == null || !application.IsConnected)
            {
                return;
            }

            OnButtonClicked(sender, e);
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender == null || btnSender.Tag == null || application == null || !application.IsConnected)
            {
                return;
            }

            if (string.IsNullOrEmpty(CommandNodeId))
            {
                using (ChangeCommandEdgeNodeForm frm = new ChangeCommandEdgeNodeForm("", setCommandNodeInstructions))
                {
                    frm.ShowDialog(this);
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        CommandNodeId = frm.NewCommandEdgeNode;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            try
            {
                PublishNodeCommand(btnSender.Tag as string);
            }
            catch (ArgumentException excep)
            {
                Console.WriteLine(excep.Message);
            }
        }


        private List<Metric> CreateSingleMetricList(string metricName)
        {
            List<Metric> metrics = new List<Metric>();

            Metric first = MetricNames.CommonMetrics.FirstOrDefault(metric => string.Equals(metricName, metric.Name));
            if (first != null)
            {
                metrics.Add(first);
                return metrics;
            }
            first = MetricNames.VCSMetrics.FirstOrDefault(metric => string.Equals(metricName, metric.Name));
            if (first != null)
            {
                metrics.Add(first);
                return metrics;
            }
            first = MetricNames.DSAMetrics.FirstOrDefault(metric => string.Equals(metricName, metric.Name));
            if (first != null)
            {
                metrics.Add(first);
                return metrics;
            }
            first = MetricNames.THVMetrics.FirstOrDefault(metric => string.Equals(metricName, metric.Name));
            if (first != null)
            {
                metrics.Add(first);
                return metrics;
            }

            throw new ArgumentException("Metric not Found");
        }

        private void PublishNodeCommand(string metricName)
        {
            if (String.IsNullOrEmpty(GroupId) || String.IsNullOrEmpty(CommandNodeId))
            {
                return;
            }
            application.PublishNodeCommand(CreateSingleMetricList(metricName), GroupId, CommandNodeId);
        }

        private void SetConnectedState() 
        {
            if (btnConnectClient.InvokeRequired)
            {
                btnConnectClient.Invoke(new Action(() => btnConnectClient.Enabled = false));
            }
            else
            {
                btnConnectClient.Enabled = false;
            }
            if (btnDisconnectClient.InvokeRequired)
            {
                btnDisconnectClient.Invoke(new Action(() => btnDisconnectClient.Enabled = true));
            }
            else
            {
                btnDisconnectClient.Enabled = true;
            }
        }

        private void SetDisconnectedState()
        {
            if (btnConnectClient.InvokeRequired)
            {
                btnConnectClient.Invoke(new Action(() => btnConnectClient.Enabled = true));
            }
            else
            {
                btnConnectClient.Enabled = true;
            }
            if (btnDisconnectClient.InvokeRequired)
            {
                btnDisconnectClient.Invoke(new Action(() => btnDisconnectClient.Enabled = false));
            }
            else
            {
                btnDisconnectClient.Enabled = false;
            }
        }

        private void btnConnectClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (application != null && application.IsConnected)
                {
                    return;
                }
                application = new SparkplugApplication(ApplicationMetrics);
                application.OnDisconnected += OnDisconnected;
                application.OnConnected += OnConnected;

                CancellationTokenSource tokenSrc = new CancellationTokenSource();
                CancellationToken ct = tokenSrc.Token;

                var sparkplugApplicationOptions = new SparkplugApplicationOptions(BrokerAddress, BrokerPort, ClientId,
                    Username, Password, UseTLS, ScadaId, TimeSpan.MaxValue, IsPrimaryApplication,
                    null, null, ct);

                application.Start(sparkplugApplicationOptions);

                Stopwatch stop = new Stopwatch();
                stop.Start();
                while (!application.IsConnected)
                {
                    if (stop.ElapsedMilliseconds >= 5000)
                    {
                        tokenSrc.Cancel();
                        break;
                    }
                }

                if (ct.IsCancellationRequested)
                {
                    application.Stop();
                    throw new TimeoutException();
                }
            }
            catch (Exception ex)
            {
                SetDisconnectedState();
                Console.WriteLine(ex.Message);
            }
        }

        private void btnDisonnectClient_Click(object sender, EventArgs e)
        {
            if (application.IsConnected)
                application.Stop();

            SetDisconnectedState();
        }
    }
}
