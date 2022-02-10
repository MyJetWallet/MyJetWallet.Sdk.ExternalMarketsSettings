using System.ServiceModel;
using System.Threading.Tasks;
using MyJetWallet.Sdk.ExternalMarketsSettings.Grpc.Models;
using MyJetWallet.Sdk.ExternalMarketsSettings.Models;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Grpc
{
    [ServiceContract]
    public interface IExternalMarketSettingAccessorGrpc
    {
        [OperationContract]
        Task GetExternalMarketSettings(GetMarketRequest request);

        [OperationContract]
        Task<GrpcList<ExternalMarketSettings>> GetExternalMarketSettingsList();
    }
}