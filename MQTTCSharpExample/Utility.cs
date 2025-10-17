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
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MQTTCSharpExample
{
    public static class Utility
    {
        public static Dictionary<NetworkInterface, UnicastIPAddressInformation> GetBroadcastNetworkInterfaces()
        {
            var collection = new Dictionary<NetworkInterface, UnicastIPAddressInformation>();

            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {

                    foreach (var ipAddressInfo in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ipAddressInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            collection[ni] = ipAddressInfo;
                            break;
                        }
                    }
                }
            }

            return collection;
        }

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
        private static string GetDGVCellText(DataGridViewCell cell, bool invariantCulture = false, string listSeparator = ",", bool quoteField = false, bool asPeak = false)
        {
            string value = string.Empty;
            if (cell.Value != null)
            {
                if (invariantCulture)
                {
                    value = string.Format(CultureInfo.InvariantCulture, "{0}", cell.Value);
                }
                else
                {
                    value = cell.Value.ToString();
                }
            }

            value = value.Replace("\"", "\"\"");

            return string.Format("{2}{0}{2}{1}", value, listSeparator, quoteField ? "\"" : string.Empty);
        }

        public static bool ExportCSV(string filePath, DataGridView dgv, out Exception ex,
            bool ignoreHiddenColumns = true, bool ignoreRowHeader = true, bool includeUTF8Header = true, bool invariantCulture = false, bool rowHeaderIsCell0 = false, bool quoteField = false, int excludeCol = -1)
        {
            ex = null;
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Create))
                {
                    if (includeUTF8Header)
                    {
                        byte[] utf8Header = Encoding.UTF8.GetPreamble();
                        stream.Write(utf8Header, 0, utf8Header.Length);
                    }

                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        StringBuilder colHeader = new StringBuilder();
                        System.Globalization.CultureInfo cuf = System.Threading.Thread.CurrentThread.CurrentCulture;
                        var listSeparator = cuf.TextInfo.ListSeparator;
                        var quote = quoteField ? "\"" : string.Empty;
                        if (!ignoreRowHeader)
                        {
                            if (rowHeaderIsCell0)
                            {
                                colHeader.AppendFormat("{0}Time{0}{1}", quote, listSeparator);
                            }
                            else
                                colHeader.Append(GetDGVCellText(dgv.TopLeftHeaderCell, invariantCulture, listSeparator, quoteField));
                        }

                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (!col.Visible && ignoreHiddenColumns)
                                continue;
                            if (col.Index == excludeCol)
                                continue;
                            colHeader.AppendFormat("{2}{0}{2}{1}", col.HeaderText.Replace("\r\n", ""), listSeparator, quote);
                        }
                        writer.WriteLine(colHeader);

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            StringBuilder sb = new StringBuilder();
                            if (!ignoreRowHeader)
                            {
                                if (rowHeaderIsCell0)
                                {
                                    sb.Append(GetDGVCellText(row.Cells[0], invariantCulture, listSeparator, quoteField));
                                }
                                else
                                    sb.Append(GetDGVCellText(row.HeaderCell, invariantCulture, listSeparator, quoteField));
                            }

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (!cell.OwningColumn.Visible && ignoreHiddenColumns)
                                {
                                    continue;
                                }
                                if (cell.ColumnIndex == excludeCol)
                                    continue;
                                sb.Append(GetDGVCellText(cell, invariantCulture, listSeparator, quoteField));
                            }
                            writer.WriteLine(sb);
                        }
                    }
                }

                return true;
            }
            catch
            {              
                return false;
            }
        }

        public static byte[] ToByteArray(this double[] doubleArray)
        {
            int length = doubleArray.Length;
            byte[] byteArray = new byte[length * sizeof(double)];
            Buffer.BlockCopy(doubleArray, 0, byteArray, 0, byteArray.Length);

            return byteArray;
        }

        public static byte[] CompressByteArray(this byte[] inputBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(inputBytes, 0, inputBytes.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] DecompressByteArray(this byte[] inputBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(inputBytes))
            {
                using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    using (MemoryStream resultStream = new MemoryStream())
                    {
                        gzipStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }

        public static double[] ToDoubleArray(this byte[] byteArray)
        {
            int length = byteArray.Length / sizeof(double);
            double[] doubleArray = new double[length];
            Buffer.BlockCopy(byteArray, 0, doubleArray, 0, byteArray.Length);
            return doubleArray;
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

    public static class PeakValueHandler
    {

        static ConcurrentDictionary<DateTime, MQTTAdvancedStatus> PeakFrequencies = new ConcurrentDictionary<DateTime, MQTTAdvancedStatus>();
        static ConcurrentDictionary<DateTime, MQTTAdvancedStatus> PeakValues = new ConcurrentDictionary<DateTime, MQTTAdvancedStatus>();
        static ConcurrentBag<KeyValuePair<float, float>> FreqVSPeak = new ConcurrentBag<KeyValuePair<float, float>>();

        public const string PeakFrequency = nameof(PeakFrequency);
        public const string PeakValue = nameof(PeakValue);

        static DataTable Datas;
        static long loopCount = 1;
        static PeakValueHandler()
        {
            Datas = new DataTable();

            DataColumn column = new DataColumn("Frequency (Hz)", typeof(string));
            Datas.Columns.Add(column);

            column = new DataColumn("Peak (dB V)",typeof(string));
            Datas.Columns.Add(column);

            column = new DataColumn("Peak (V)", typeof(string));
            Datas.Columns.Add(column);
        }

        public static void Add(MQTTAdvancedStatus status)
        {
            if(status.Name == PeakFrequency)
            {
                PeakFrequencies[DateTime.Parse(status.Timestamp)] = status;
            }
            else if(status.Name == PeakValue)
            {
                PeakValues[DateTime.Parse(status.Timestamp)] = status;
                unitY = status.Unit.Trim();
                if(unitY == "dB V")
                {
                    unitY = "dB (V)";
                }
                else if(unitY == "dB mV")
                {
                    unitY = "dB (mV)";
                }
            }

            DataProcessing();


            if (status.Name == PeakValue && !Datas.Columns[1].ColumnName.Contains("("))
            {
                Datas.Columns[1].ColumnName = $"Peak ({UnitY})";
            }
        }

        public static void Clear()
        {
            loopCount = 1;
            Datas.Rows.Clear();
            PeakFrequencies.Clear();
            PeakValues.Clear();
            FreqVSPeak = new ConcurrentBag<KeyValuePair<float, float>>();
        }
        private static void DataProcessing()
        {
            if(PeakValues.Count > 0 && PeakFrequencies.Count > 0)
            {
                var dataA = PeakFrequencies.ToList();
                var dataB = PeakValues.ToList();
                dataA.Sort((a, b) => a.Key.CompareTo(b.Key));
                dataB.Sort((a, b) => a.Key.CompareTo(b.Key));

                var closestPairs = from d1 in dataA
                                   from d2 in dataB
                                   let diff = Math.Abs((d1.Key-d2.Key).TotalMilliseconds)
                                   where diff <=TimeMatchOffset
                                   select new {d1,d2};

                var clearFlag = false;

                foreach(var pair in closestPairs)
                {
                    FreqVSPeak.Add(new KeyValuePair<float, float>(float.Parse(pair.d1.Value.Value), float.Parse(pair.d2.Value.Value)));
                    if(!clearFlag)
                    {
                        PeakFrequencies.TryRemove(pair.d1.Key, out var a);
                        PeakValues.TryRemove(pair.d2.Key, out var b);

                        DateTime da, db;
                        da = DateTime.Parse(a.Timestamp);
                        db = DateTime.Parse(b.Timestamp);
                        PeakFrequencies.Where(p => p.Key < da).ToList().ForEach(a1 => PeakFrequencies.TryRemove(a1.Key, out _));
                        PeakValues.Where(p => p.Key < db).ToList().ForEach(b1 => PeakValues.TryRemove(b1.Key, out _));

                        clearFlag = true;
                    }
                    
                }


#if DEBUG
                //Trace.WriteLine($"--------------The {loopCount}th loop----------------");
                //Trace.WriteLine($"Frequencies Not Matched,{DateTime.Now.ToString("HH:mm:ss.fff")}");
                //foreach (var d in dataA)
                //{
                //    Trace.WriteLine($"{d.Key.ToString("HH:mm:ss.fff")},{d.Value.Value}");
                //}
                //Trace.WriteLine($"Peaks Not Matched,{DateTime.Now.ToString("HH:mm:ss.fff")}");
                //foreach (var d in dataB)
                //{
                //    Trace.WriteLine($"{d.Key.ToString("HH:mm:ss.fff")},{d.Value.Value}");
                //}
                //Trace.WriteLine("");
                loopCount++;
#endif


                //int aIndex = 0, bIndex = 0;
                //var removeListA = new List<DateTime>();
                //var removeListB = new List<DateTime>();

                //                while (aIndex < dataA.Count && bIndex < dataB.Count)
                //                {
                //                    var a = dataA[aIndex];
                //                    var b = dataB[bIndex];

                //                    // if timestamps match, add to result and move both pointers
                //                    if (Math.Abs((a.Key - b.Key).TotalMilliseconds)<=TimeMatchOffset)
                //                    {
                //#if DEBUG
                //                        //Trace.WriteLine($"Find match: ({a.Key.ToString("HH:mm:ss.fff")},{a.Value.Value}) vs ({b.Key.ToString("HH:mm:ss.fff")},{b.Value.Value})");
                //#endif
                //                        FreqVSPeak.Add(new KeyValuePair<float, float>(float.Parse(a.Value.Value), float.Parse(b.Value.Value)));
                //                        removeListA.Add(a.Key);
                //                        removeListB.Add(b.Key);

                //                        aIndex++;
                //                        bIndex++;
                //                    }

                //                    // otherwise, move the pointer for the earlier timestamp
                //                    else if (a.Key < b.Key)
                //                    {
                //                        aIndex++;
                //                    }
                //                    else
                //                    {
                //                        bIndex++;
                //                    }
                //                }

                //                removeListA.ForEach(a => PeakFrequencies.TryRemove(a, out _));
                //                removeListB.ForEach(b => PeakValues.TryRemove(b, out _));

                //MQTTAdvancedStatus? ff = null, pp = null;
                //DateTime? freqTimestamp = null;
                //foreach(var freq in PeakFrequencies)
                //{
                //    TimeSpan ts = TimeSpan.MaxValue;
                //    TimeSpan offset = TimeSpan.MaxValue;                 
                //    DateTime? timestampMatch = null;
                //    foreach (var pk in PeakValues)
                //    {   
                //        if(freq.Key > pk.Key)
                //        {
                //            offset = freq.Key - pk.Key;
                //        }
                //        else
                //        {
                //            offset = pk.Key - freq.Key;
                //        }

                //        if(offset < ts)
                //        {
                //            timestampMatch = pk.Key;
                //        }
                //    }

                //    if(offset.Milliseconds <= TimeMatchOffset)
                //    {
                //        freqTimestamp = freq.Key;
                //        PeakValues.TryRemove(timestampMatch.Value, out var p); pp = p;
                //        break;
                //    }
                //}

                //if(freqTimestamp != null)
                //{
                //    PeakFrequencies.TryRemove(freqTimestamp.Value, out var f); ff = f;
                //}


                //if(ff != null && pp != null)
                //{
                //    FreqVSPeak.Add(new KeyValuePair<float, float>(float.Parse(ff.Value.Value), float.Parse(pp.Value.Value)));
                //}
            }
        }

        public static double[][] GetData(bool updateTable)
        {
            double[][] data = new double[2][];
            var tmp = FreqVSPeak.OrderBy(kp=>kp.Key).ToArray();
            data[0] = tmp.Select(kp=>(double)kp.Key).ToArray() ;
            data[1] = tmp.Select(kp=>(double)kp.Value).ToArray();

            if(updateTable)
            {
                for (int i = 0; i < data[0].Length; i++)
                {
                    var dB = data[1][i];

                    if (i < Datas.Rows.Count)
                    {
                        DataRow dr = Datas.Rows[i];
                        dr.ItemArray = new object[] { data[0][i].ToString("f3"), dB.ToString("f5"), Math.Pow(10,dB/20.0).ToString("f5") };
                    }
                    else
                    {
                        DataRow dr = Datas.NewRow();
                        dr.ItemArray = new object[] { data[0][i].ToString("f3"), dB.ToString("f5"), Math.Pow(10, dB / 20.0).ToString("f5") };
                        Datas.Rows.Add(dr);
                    }
                }
            }
           
            return data;
        }

        public static DataTable GetTable() => Datas;

        public static bool HasData => FreqVSPeak.Count > 0;

        public static int TimeMatchOffset { get; set; } = 500;

        public static string UnitX => "Frequency (Hz)";

        static string unitY;
        public static string UnitY => unitY;


    }

}
