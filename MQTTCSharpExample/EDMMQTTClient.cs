using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Client.Subscribing;
using MQTTnet.Client.Connecting;
using System;
using System.Threading.Tasks;
using System.Security.Authentication;
using MQTTnet.Client.Publishing;
using MQTTnet.Client.Unsubscribing;
using System.Threading;
using MQTTnet.Adapter;
using MQTTnet.Client.Disconnecting;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using System.Text;
using X509Certificate = System.Security.Cryptography.X509Certificates.X509Certificate;

namespace MQTTCSharpExample
{
    public sealed class EDMMQTTClient : IMqttApplicationMessageReceivedHandler, IMqttClientConnectedHandler, IMqttClientDisconnectedHandler
    {      
        private ClientModel ClientModel;

        public IMqttClient Client { get; private set; }

        public bool IsConnected
        {
            get
            {
                if (Client != null) return Client.IsConnected;
                return false;
            }
        }

        public async Task<MqttClientConnectResultCode> StartClient(ClientModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (Client != null)
            {
                await Client.DisconnectAsync();
                Client.Dispose();
            }

            Client = new MqttFactory().CreateMqttClient();

            Client.UseApplicationMessageReceivedHandler(this);
            Client.UseDisconnectedHandler(this);
            Client.UseConnectedHandler(this);

            var clientOptionsBuilder = new MqttClientOptionsBuilder()
                .WithCommunicationTimeout(TimeSpan.FromSeconds(model.CommunicationTimeout))
                .WithProtocolVersion(model.Protocol)
                .WithClientId(model.ClientId)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(model.KeepAliveInterval));

            if (model.Transport == Transport.TCP)
            {
                clientOptionsBuilder.WithTcpServer(model.Host, model.Port);
            }
            else
            {
                clientOptionsBuilder.WithWebSocketServer(model.Host);
            }

            if (model.CleanSession)
            {
                clientOptionsBuilder.WithCleanSession(model.CleanSession);
            }

            var isNeedCredential = true;

            if (model.SslProtocal != SslProtocols.None)
            {
                var certs = new List<X509Certificate>();

                if (!string.IsNullOrWhiteSpace(model.CACertificateFile) && File.Exists(model.CACertificateFile))
                {
                    var certificateAuthorityCertPEMString = File.ReadAllText(model.CACertificateFile);
                    var certBytes = Encoding.UTF8.GetBytes(certificateAuthorityCertPEMString);
                    var signingcert = new X509Certificate2(certBytes);
                    certs.Add(signingcert);
                }

                if (!string.IsNullOrWhiteSpace(model.ClientCertificateFile) && !string.IsNullOrWhiteSpace(model.ClientCertificatePrivateKeyFile)
                    && File.Exists(model.ClientCertificateFile) && File.Exists(model.ClientCertificatePrivateKeyFile))
                {
                    var clientCert = createCertificate(model.ClientCertificateFile, model.ClientCertificatePrivateKeyFile);
                    certs.Add(clientCert);
                }

                if (certs.Count > 0)
                {
                    isNeedCredential = false;
                    clientOptionsBuilder.WithTls(o =>
                    {
                        o.SslProtocol = model.SslProtocal;
                        o.UseTls = true;
                        o.AllowUntrustedCertificates = true;
                        o.Certificates = certs;
                        o.CertificateValidationHandler = auth;
                    });
                }
                else
                {
                    clientOptionsBuilder.WithTls(o =>
                    {
                        o.SslProtocol = model.SslProtocal;
                        o.UseTls = true;
                    });
                }
            }

            if (isNeedCredential)
            {
                clientOptionsBuilder.WithCredentials(model.User, model.Password);
            }


            try
            {
                var result = await Client.ConnectAsync(clientOptionsBuilder.Build());

                return result.ResultCode;
            }
            catch (MqttConnectingFailedException mfe)
            {
                Trace.WriteLine(mfe.ToString());
                return mfe.ResultCode;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return MqttClientConnectResultCode.UnspecifiedError;
            }


            bool auth(MqttClientCertificateValidationCallbackContext cc) => true;

            X509Certificate2 createCertificate(string certificatePath, string keyPath)
            {
                var certParser = new X509CertificateParser();
                var cert = certParser.ReadCertificate(File.ReadAllBytes(certificatePath));

                using (var reader = new StreamReader(keyPath))
                {
                    var pemReader = new PemReader(reader);
                    var keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();

                    var builder = new Pkcs12StoreBuilder();
                    builder.SetUseDerEncoding(true);
                    var store = builder.Build();

                    var certEntry = new X509CertificateEntry(cert);
                    store.SetCertificateEntry(cert.SubjectDN.ToString(), certEntry);
                    store.SetKeyEntry(cert.SubjectDN.ToString(), new AsymmetricKeyEntry(keyPair.Private), new[] { certEntry });

                    using (var stream = new MemoryStream())
                    {
                        store.Save(stream, null, new SecureRandom());
                        return new X509Certificate2(stream.ToArray());
                    }
                }
            }
        }

        public async Task<MqttClientConnectResultCode> Connect(ClientModel model)
        {
            ClientModel = model;
            return await StartClient(model);
        }

        public Task Disconnect()
        {
            if (Client?.IsConnected == false)
                return null;

            return Client.DisconnectAsync();
        }

        public async Task<MqttClientSubscribeResult> Subscribe(SubscriptionOptionsModel configuration)
        {

            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            if (Client?.IsConnected == false)
                return null;

            var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(configuration.Topic)
                .WithQualityOfServiceLevel(configuration.Level)
                .WithNoLocal(configuration.NoLocal)
                .WithRetainHandling(configuration.RetainHandling)
                .WithRetainAsPublished(configuration.RetainAsPublished)
                .Build();

            var subscribeOptions = new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter(topicFilter)
                .Build();

            var subscribeResult = await Client.SubscribeAsync(subscribeOptions).ConfigureAwait(false);

            return subscribeResult;
        }

        public async Task<MqttClientUnsubscribeResult> Unsubscribe(string topic)
        {

            if (topic == null) throw new ArgumentNullException(nameof(topic));

            if (Client?.IsConnected == false)
                return null;

            var unsubscribeResult = await Client.UnsubscribeAsync(topic);

            return unsubscribeResult;
        }


        public async Task<MqttClientPublishResult> Publish(PublishOptionsModel options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (!IsConnected || ClientModel == null)
                return null;


            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(options.Topic)
                .WithQualityOfServiceLevel(options.Level)
                .WithRetainFlag(options.Retain)
                .WithPayload(options.Payload)
                .Build();

            return await Client.PublishAsync(applicationMessage);
        }

        public event EventHandler<MqttClientConnectedEventArgs> ClientConnected;
        public event EventHandler<MqttClientDisconnectedEventArgs> ClientDisconnected;
        public event EventHandler<MqttApplicationMessageReceivedEventArgs> ClientApplicationMessageReceived;

        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            await Task.Run(() => ClientConnected?.Invoke(Client, eventArgs));
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            await Task.Run(() => ClientDisconnected?.Invoke(Client, eventArgs));
        }

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs eventArgs)
        {
            await Task.Run(() => ClientApplicationMessageReceived?.Invoke(Client, eventArgs));
        }
    }
}
