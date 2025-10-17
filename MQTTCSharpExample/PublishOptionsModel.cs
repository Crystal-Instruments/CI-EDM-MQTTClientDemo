using MQTTnet.Protocol;
using System;

namespace MQTTCSharpExample
{
    public class PublishOptionsModel
    {
        public string Name { get; set; }

        public string Topic { get; set; }

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

        public bool Retain { get; set; }

        public byte[] Payload { get; set; }

    }
}
