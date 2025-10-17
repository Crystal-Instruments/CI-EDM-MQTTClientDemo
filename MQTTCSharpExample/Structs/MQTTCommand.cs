using System.Collections.Generic;

namespace MQTTCSharpExample
{
    public struct MQTTCommand
    {
        public string Type;
        public Dictionary<string, string> Parameters;
    }
}
