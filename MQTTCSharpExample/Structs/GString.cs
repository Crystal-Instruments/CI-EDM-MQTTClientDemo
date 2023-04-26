using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{

    public class LocalizedString
    {
        public LanguageString Value { get; set; }

        public override string ToString()
        {
            if(Value?.Languages?.Count > 0)
            {
                return Value.Languages[0].Value;
            }
            return base.ToString();
        }
    }

    public class LanguageString
    {
        public List<KeyValuePair<string,string>> Languages { get; set; }
    }

}
