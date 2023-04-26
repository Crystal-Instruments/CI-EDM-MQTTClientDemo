using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Authentication;
using MQTTnet.Formatter;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

namespace MQTTCSharpExample
{
    public static class Utility
    {
        
        public static void EnableDoubleBuffer(this Control panel)
        {
            if (panel == null) return;
            panel.GetType().GetProperty("DoubleBuffered",
                  System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(panel,
                  true, null);
        }

        public static void OpenFile(string filePath)
        {
            if (null == filePath)
                return;
            var file = filePath;
            try
            {
                System.Diagnostics.Process.Start(file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //If no default App, just open the directory
                System.Diagnostics.Process.Start("Explorer.exe", "/select," + file);
            }
        }


        public static bool NeedCutoffFreqData(bool isAPS)
        {
            //will add more check conditions later
            if (isAPS)
                return true;
            return false;
        }

        public static double GetCutOffFactor(bool isShock)
        {
            if (isShock)
            {
                return 0.78125;
            }
            else
            {
                return 900f / 1024;
            }
        }

        public static double[][] CutoffFreqData(double[][] origDrawData, bool isShock)
        {
            var cutOffRate = GetCutOffFactor(isShock);
            var lengthX = (int)Math.Ceiling(origDrawData[0].Length * cutOffRate);
            var lengthY = (int)Math.Ceiling(origDrawData[1].Length * cutOffRate);

            //Complex data related
            if (origDrawData[1].Length == origDrawData[0].Length * 2
                && lengthY != lengthX * 2)
            {
                lengthY = lengthX * 2;
            }

            var drawData = new double[origDrawData.Length][];
            drawData[0] = new double[lengthX];
            drawData[1] = new double[lengthY];
            if (origDrawData.Length > 2)
            {
                drawData[2] = new double[origDrawData[2].Count()];
                drawData[2][0] = origDrawData[2][0];
                for (int i = 1; i < origDrawData[2].Count(); i++)
                {
                    drawData[2][i] = origDrawData[2][i];
                }
            }
            Array.Copy(origDrawData[0], 0, drawData[0], 0, lengthX);
            Array.Copy(origDrawData[1], 0, drawData[1], 0, lengthY);

            return drawData;
        }

        static JsonSerializerSettings jss = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        /// <summary>
        /// JSON serialize
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            try
            {         
                return JsonConvert.SerializeObject(t, jss);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return string.Empty;
            }

        }

        /// <summary>
        /// JSON deserialize
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            T obj = default;

            if (string.IsNullOrEmpty(jsonString))
            {
                return obj;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, jss);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return obj;
            }

        }

        
        public static T JsonDeserialize<T>(byte[] payloadBuffer)
        {
            if (payloadBuffer != null)
            {
                return JsonDeserialize<T>(Encoding.UTF8.GetString(payloadBuffer));
            }
            return default;
        }

        public static object JsonDeserialize(byte[] payloadBuffer)
        {
            if (payloadBuffer != null)
            {
                return JsonDeserialize(Encoding.UTF8.GetString(payloadBuffer));
            }
            return default;
        }


        public static object JsonDeserialize(string jsonString)
        {
            object obj = default;

            if (string.IsNullOrEmpty(jsonString))
            {
                return obj;
            }

            try
            {
                return JsonConvert.DeserializeObject(jsonString, jss);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return obj;
            }

        }


        public static string[] VCSTestTypes { get; } = new string[] {

            "VCS_Random",
            "VCS_Shock",  // Classic Shock
            "VCS_Sine",
            "VCS_TTH",    // Transient Time History 
            "VCS_SRS",    // Shock Response Spectrum
            "VCS_SineOscillator",
            "VCS_TDR",
            "VCS_AcousticControl",
            "VCS_RORSOR",
            "VCS_RSTD",
            "VCS_SineReduction",
            "VCS_MultiSine",
            "VCS_ShockOnRandom",
            "VCS_SineBeatSeismic",
            "VCS_BFT",
            "VCS_EDR",
            "MIMO_Random",
            "MIMO_Sine",
            "MIMO_Shock",
            "MIMO_TWR",
            "MIMO_SRS",
            "MIMO_TTH",
            "MIMO_SOR",
            "MDOF_Random",
            "MDOF_Sine",
            "MDOF_TWR",
        };

        public static Color[] COLORS { get; } = new Color[]
            {
                Color.Green,
                Color.Blue,
                Color.Red,
                Color.Purple,
                Color.DarkGoldenrod,
                Color.DeepPink,
                Color.SaddleBrown,
                Color.DarkViolet,
                Color.Brown,
                Color.SlateBlue,
                Color.DarkOrange,
                Color.Thistle,
                Color.Orchid,
                Color.Olive,
                Color.DarkOliveGreen,
                Color.DeepSkyBlue,
                Color.RoyalBlue,
                Color.SeaGreen,
                Color.SteelBlue,
                Color.Teal
            };
    }

    public static class TLSOptions
    {
        public static string[] Options { get; } = new string[] { "No TLS", "TLS 1.0", "TLS 1.1", "TLS 1.2", "TLS 1.3" };

        public static SslProtocols ToProtocol(string desc)
        {
            var index = Array.IndexOf(Options, desc);

            if (index == 0) return SslProtocols.None;
            else if (index == 1) return SslProtocols.Tls;
            else if (index == 2) return SslProtocols.Tls11;
            else if (index == 3) return SslProtocols.Tls12;
            else if (index == 4) return SslProtocols.Tls13;

            return SslProtocols.None;
        }

        public static string ToDescription(SslProtocols ssl)
        {
            switch (ssl)
            {
                case SslProtocols.None:
                    return Options[0];
                case SslProtocols.Tls:
                    return Options[1];
                case SslProtocols.Tls11:
                    return Options[2];
                case SslProtocols.Tls12:
                    return Options[3];
                case SslProtocols.Tls13:
                    return Options[4];
            }
            return Options[0];
        }
    }

    public static class ProtocolOptions
    {
        public static string[] Options { get; } = new string[] { "3.1.0", "3.1.1", "5.0.0" };

        public static MqttProtocolVersion ToProtocol(string desc)
        {
            var index = Array.IndexOf(Options, desc);

            if (index == 0) return MqttProtocolVersion.V310;
            else if (index == 1) return MqttProtocolVersion.V311;
            else if (index == 2) return MqttProtocolVersion.V500;

            return MqttProtocolVersion.V311;
        }

        public static string ToDescription(MqttProtocolVersion ssl)
        {
            switch (ssl)
            {
                case MqttProtocolVersion.V310:
                    return Options[0];
                case MqttProtocolVersion.V311:
                    return Options[1];
                case MqttProtocolVersion.V500:
                    return Options[2];
            }
            return Options[0];
        }
    }

}
