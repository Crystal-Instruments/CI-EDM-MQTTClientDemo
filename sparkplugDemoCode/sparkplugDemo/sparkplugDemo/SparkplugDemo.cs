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
using MQTTnet;
using SparkplugNet.Core;
using MQTTnet.Internal;

namespace sparkplugDemo
{
    internal class SparkplugDemo
    {
        private const string brokerAddress = "192.168.1.9";
        private const int brokerPort = 1883;
        private const string username = "Admin";
        private const string password = "123456";
        private const string clientId = "SparkplugDemo";
        private const bool useTls = false;
        private const string scadaHostIdentifier = "Scada1";
        private const string groupIdentifier = "EDM";
        private const string edgeNodeIdentifier = "EdgeNode1";
        private const bool isPrimaryApplication = true;

        static void Main(string[] args)
        {
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
                username, password, useTls, scadaHostIdentifier, TimeSpan.FromSeconds(1), isPrimaryApplication,
                null, null, System.Threading.CancellationToken.None);
            
            application.Start(sparkplugApplicationOptions);

            // Waiting for the application to connect to the broker
            while (!application.IsConnected) ;

            // Publish a command to the broker
            Metric createTest = new Metric { Name = MetricNames.METRIC_NCMD_CREATETEST, DataType = DataType.String, StringValue = "dsgdsfdsfdsf;VCS_Random" };
            application.PublishNodeCommand(new List<Metric> { createTest }, "EDM", "Node1");
            while (true) ;
        }
    }
}
