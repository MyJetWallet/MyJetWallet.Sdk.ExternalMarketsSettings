using System.Collections.Generic;
using System.ServiceModel;
using MyJetWallet.Sdk.ExternalMarketsSettings.Models;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Settings
{
    [ServiceContract]
    public interface IExternalMarketSettingsAccessor
    {
        [OperationContract]
        ExternalMarketSettings GetExternalMarketSettings(string market);

        [OperationContract]
        List<ExternalMarketSettings> GetExternalMarketSettingsList();
    }
}