using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public class MQTTRunFolder
    {
        public string RunName;
        public string RunPath;
        public List<string> RunFiles;
    }

    public class MQTTRecordFile
    {
        public string FileName;
        public byte[] AtfxFileContent;
        public List<string> DataFiles;
        public List<byte[]> DataFileContents;
    }
}
