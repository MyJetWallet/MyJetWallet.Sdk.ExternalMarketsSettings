using System.ServiceModel;
using System.Threading.Tasks;
using MyJetWallet.Sdk.ExternalMarketsSettings.Models;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Settings
{
    [ServiceContract]
    public interface IExternalMarketSettingsManager
    {
        [OperationContract]
        Task AddExternalMarketSettings(ExternalMarketSettings settings);

        [OperationContract]
        Task UpdateExternalMarketSettings(ExternalMarketSettings settings);

        [OperationContract]
        Task RemoveExternalMarketSettings(string symbol);
    }
}