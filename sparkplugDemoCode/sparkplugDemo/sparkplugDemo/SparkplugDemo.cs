using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkplugNet;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using SparkplugNet.Core.Application;
using SparkplugNet.Core.Node;
using SparkplugNet.Core.Enumerations;
using SparkplugNet.Core;
using MQTTnet.Client.Disconnecting;
using System.Windows.Forms;
using System.CodeDom;
using System.Threading;
using System.Diagnostics;
using MQTTnet.Client.Connecting;
using Serilog.Formatting.Display;
using MQTTnet;
using Serilog;

namespace sparkplugDemo
{
    internal class SparkplugDemo
    {
        private const string brokerAddress = "192.168.1.19";
        private const int brokerPort = 1883;
        private const string username = "Admin";
        private const string password = "123456";
        private const string clientId = "SparkplugDemo";
        private const bool useTls = false;
        private const string scadaHostIdentifier = "Scada2";
        private const string groupIdentifier = "EDM";
        private const string edgeNodeIdentifier = "EdgeNode1";
        private const bool isPrimaryApplication = true;

        [STAThread]
        static void Main()
        {
#if GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SparkplugForm());
#else
            List<Metric> metrics = new List<Metric>();

            // Adding the metrics that the application should know about.
            foreach (Metric m in MetricNames.CommonMetrics)
                metrics.Add(m);
            foreach (Metric m in MetricNames.VCSMetrics)
                metrics.Add(m);
            foreach (Metric m in MetricNames.DSAMetrics)
                metrics.Add(m);
            foreach (Metric m in MetricNames.THVMetrics)
                metrics.Add(m);


            // Creating the application with the metrics that it needs
            var application = new SparkplugApplication(metrics);

            // Specifying the address, port, and other options for the application
            var sparkplugApplicationOptions = new SparkplugApplicationOptions(brokerAddress, brokerPort, clientId,
                username, password, useTls, scadaHostIdentifier, TimeSpan.MaxValue, isPrimaryApplication,
                null, null, System.Threading.CancellationToken.None);

            application.OnDisconnected += ApplicationDisconnected;
            application.Start(sparkplugApplicationOptions);

            //Wait for the application to connect
            while (!application.IsConnected) ;

            List<Metric> disconnect = new List<Metric>();
            disconnect.Add(new Metric() { Name = MetricNames.METRIC_NCMD_DISCONNECT, DataType = (uint)DataType.Boolean, BooleanValue = false });
            application.PublishNodeCommand(disconnect, groupIdentifier, edgeNodeIdentifier);

            //List<Tuple<string, Stopwatch>> metricsNamesToCheck = new List<Tuple<string, Stopwatch>>
            //{
            //    Tuple.Create<string, Stopwatch>("Signals/Ch1/Data", new Stopwatch()),
            //};

            //List<Metric> metricsToCheck = new List<Metric>();
            //for (int i = 0; i < metricsNamesToCheck.Count; i++)
            //{
            //    metricsToCheck.Add(null);
            //}

            //bool CheckMetricChanged(int index, string metricName)
            //{
            //    Metric prev = metricsToCheck[index];
            //    MetricState<Metric> gottenMetricState = null;
            //    bool gotMetricState = application.NodeStates.TryGetValue(edgeNodeIdentifier, out gottenMetricState);
            //    if (!gotMetricState || gottenMetricState == null)
            //    {
            //        return false;
            //    }
            //    Metric gottenMetric = null;
            //    bool gotMetric = gottenMetricState.Metrics.TryGetValue(metricName, out gottenMetric);
            //    if (!gotMetric || gottenMetric == null)
            //    {
            //        return false;
            //    }

            //    if (gottenMetric.Equals(prev))
            //    {
            //        return false;
            //    }

            //    metricsToCheck[index] = gottenMetric;
            //    return true;
            //}

            //Stopwatch secondTimer = new Stopwatch();
            //int dataReceivedInSecond = 0;
            //for (int i = 0; i < metricsToCheck.Count; i++)
            //{
            //    metricsNamesToCheck[i].Item2.Start();
            //}
            //secondTimer.Start();
            //while (true)
            //{
            //    for (int i = 0; i < metricsToCheck.Count; i++)
            //    {
            //        Tuple<string, Stopwatch> tup = metricsNamesToCheck[i];
            //        if (CheckMetricChanged(i, tup.Item1))
            //        {
            //            tup.Item2.Stop();
            //            dataReceivedInSecond++;
            //            if (secondTimer.ElapsedMilliseconds >= 1000)
            //            {
            //                Console.Write(string.Format("Data In Second : {0}\n", dataReceivedInSecond));
            //                dataReceivedInSecond = 0;
            //                secondTimer.Restart();
            //            }
            //            Console.Write(string.Format("Elapsed Milliseconds: {0}, ", tup.Item2.ElapsedMilliseconds));
            //            if (metricsToCheck[i].DataSetValue.Rows.Count > 0 && metricsToCheck[i].DataSetValue.Rows[0].Elements.Count > 1)
            //            {
            //                Console.Write(string.Format("First Data Point: {0} of {1}\n", metricsToCheck[i].DataSetValue.Rows[0].Elements[1].DoubleValue, tup.Item1));
            //            }
            //            else
            //            {
            //                Console.Write("No Data\n");
            //            }
            //            tup.Item2.Restart();
            //        }
            //    }
            //}
#endif
        }

        private static void ApplicationDisconnected(MqttClientDisconnectedEventArgs args)
        {
            Console.WriteLine("Disconnected");
        }
    }
}
