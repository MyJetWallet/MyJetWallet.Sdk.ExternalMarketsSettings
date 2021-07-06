using System;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using JetBrains.Annotations;
using MyJetWallet.Sdk.ExternalMarketsSettings.Grpc;
using MyJetWallet.Sdk.Grpc;
using MyJetWallet.Sdk.GrpcMetrics;
using ProtoBuf.Grpc.Client;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Autofac
{
    [UsedImplicitly]
    public class ExternalMarketSettingsClientFactory : MyGrpcClientFactory
    {
        private readonly CallInvoker _channel;

        public ExternalMarketSettingsClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(grpcServiceUrl);
            _channel = channel.Intercept(new PrometheusMetricsInterceptor());
        }

        public IExternalMarketSettingsManagerGrpc GetMarketMakerSettingsManagerGrpc() =>
            _channel.CreateGrpcService<IExternalMarketSettingsManagerGrpc>();
    }
}