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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SparkplugForm());
        }
    }
}
