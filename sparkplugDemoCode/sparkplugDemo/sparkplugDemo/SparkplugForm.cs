using System;
using System.Collections.Generic;
using SparkplugNet;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using SparkplugNet.Core.Application;
using SparkplugNet.Core.Node;
using SparkplugNet.Core.Enumerations;
using SparkplugNet.Core;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;
using System.Diagnostics;
using DevComponents.DotNetBar;

namespace sparkplugDemo
{
    public partial class SparkplugForm : Form
    {
        private SparkplugApplication application;

        private string BrokerAddress {
            get { return ipAddressInput1.Value; }
        }
        private int BrokerPort
        {
            get { return iiPort.Value; }
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
            get { return tbScadaId.Text; }
        }

        private string CommandNodeId
        { 
            get { return "EdgeNode1"; }
        }

        private List<Metric> applicationMetrics;
        private List<Metric> ApplicationMetrics
        {
            get { return applicationMetrics; }
        }

        public SparkplugForm()
        {
            applicationMetrics = new List<Metric>();
            InitializeComponent();
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
            ButtonX btnSender = sender as ButtonX;
            if (btnSender == null || btnSender.Tag == null || !application.IsConnected)
            {
                return;
            }

            OnButtonClicked(sender, e);
            ;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            ButtonX btnSender = sender as ButtonX;
            if (btnSender == null || btnSender.Tag == null || !application.IsConnected)
            {
                return;
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
            btnConnectClient.Enabled = false;
            btnDisconnectClient.Enabled = true;
        }

        private void SetDisconnectedState()
        {
            btnConnectClient.Enabled = true;
            btnDisconnectClient.Enabled = false;
        }

        private void btnConnectClient_Click(object sender, EventArgs e)
        {
            try
            {
                SetConnectedState();
                application = new SparkplugApplication(ApplicationMetrics);

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
