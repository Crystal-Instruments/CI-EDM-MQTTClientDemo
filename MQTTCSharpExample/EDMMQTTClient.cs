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
                .WithCredentials(model.User, model.Password)
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(model.KeepAliveInterval));

            if (model.Transport == Transport.TCP)
            {
                clientOptionsBuilder.WithTcpServer(model.Host, model.Port);
            }
            else
            {
                clientOptionsBuilder.WithWebSocketServer(model.Host);
            }

            if (model.SslProtocal != SslProtocols.None)
            {
                clientOptionsBuilder.WithTls(o =>
                {
                    o.SslProtocol = model.SslProtocal;
                });
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
