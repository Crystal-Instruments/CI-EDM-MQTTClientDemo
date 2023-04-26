using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public class GTable
    {
        public string Type { get; set; }
        public LocalizedString Name { get; set; }
        public List<LocalizedString> Headers { get; set; }
        public List<Row> Rows { get; set; }
    }

    public class Row
    {       
        public List<string> Value { get; set; }
    }
}
