using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public class GParameter
    {
        public string Type { get; set; }
        public LocalizedString Name { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}
