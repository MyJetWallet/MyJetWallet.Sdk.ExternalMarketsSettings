using Autofac;
using MyJetWallet.Sdk.ExternalMarketsSettings.Grpc;

// ReSharper disable UnusedMember.Global

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Autofac
{
    public static class AutofacHelper
    {
        public static void RegisterExternalB2C2Client(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new ExternalMarketSettingsClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetMarketMakerSettingsManagerGrpc())
                .As<IExternalMarketSettingsManagerGrpc>().SingleInstance();

            builder.RegisterInstance(factory.GetMarketSettingAccessorGrpc())
                .As<IExternalMarketSettingAccessorGrpc>().SingleInstance();
        }
    }
}