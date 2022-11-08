using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTCSharpExample
{
    public class SubscriptionOptionsModel
    {
        public string Topic { get; set; } = string.Empty;

        public bool IsLevel0 { get; set; } = true;

        public bool IsLevel1 { get; set; }

        public bool IsLevel2 { get; set; }

        public MqttQualityOfServiceLevel Level
        {
            get
            {
                if (IsLevel0)
                {
                    return MqttQualityOfServiceLevel.AtMostOnce;
                }

                if (IsLevel1)
                {
                    return MqttQualityOfServiceLevel.AtLeastOnce;
                }

                if (IsLevel2)
                {
                    return MqttQualityOfServiceLevel.ExactlyOnce;
                }

                throw new NotSupportedException();
            }

            set
            {
                IsLevel0 = false;
                IsLevel1 = false;
                IsLevel2 = false;

                if (value == MqttQualityOfServiceLevel.AtMostOnce)
                {
                    IsLevel0 = true;
                }

                if (value == MqttQualityOfServiceLevel.AtLeastOnce)
                {
                    IsLevel1 = true;
                }

                if (value == MqttQualityOfServiceLevel.ExactlyOnce)
                {
                    IsLevel2 = true;
                }
            }
        }

        public bool NoLocal { get; set; }

        public bool RetainAsPublished { get; set; }

        public bool IsRetainHandling0 { get; set; } = true;

        public bool IsRetainHandling1 { get; set; }

        public bool IsRetainHandling2 { get; set; }

        public MqttRetainHandling RetainHandling
        {
            // TODO: This should be refactored as soon as Avalonia supports Binding.DoNothing!
            get
            {
                if (IsRetainHandling0)
                {
                    return MqttRetainHandling.SendAtSubscribe;
                }

                if (IsRetainHandling1)
                {
                    return MqttRetainHandling.SendAtSubscribeIfNewSubscriptionOnly;
                }

                return MqttRetainHandling.SendAtSubscribe;
            }


            set
            {
                IsRetainHandling0 = false;
                IsRetainHandling1 = false;
                IsRetainHandling2 = false;

                if (value == MqttRetainHandling.SendAtSubscribe)
                {
                    IsRetainHandling0 = true;
                }

                if (value == MqttRetainHandling.SendAtSubscribeIfNewSubscriptionOnly)
                {
                    IsRetainHandling1 = true;
                }

                if (value == MqttRetainHandling.DoNotSendOnSubscribe)
                {
                    IsRetainHandling2 = true;
                }
            }
        }
       
    }
}
