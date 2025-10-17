using MQTTnet.Formatter;
using System.Security.Authentication;

namespace MQTTCSharpExample
{
    public sealed class ClientModel
    {
        public MqttProtocolVersion Protocol { get; set; } = MqttProtocolVersion.V311;
        public string Host { get; set; }
        public int Port { get; set; }
        public int CommunicationTimeout { get; set; }
        public Transport Transport { get; set; } = Transport.TCP;
        public SslProtocols SslProtocal { get; set; } = SslProtocols.None;
        public string ClientId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int KeepAliveInterval { get; set; }
        public bool CleanSession { get; set; }  
        public string SoftwareMode { get; set; }

        //Cert related        
        public string ClientCertificatePrivateKeyFile { get; set; }
        public string ClientCertificateFile { get; set; }
        public string CACertificateFile { get; set; }
    }
}
