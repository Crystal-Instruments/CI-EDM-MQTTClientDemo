using System;
using System.Windows.Forms;

namespace MQTTSparkplugDemo
{
    internal class MQTTSparkplugExample
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MQTTSparkplugForm());
        }
    }
}
