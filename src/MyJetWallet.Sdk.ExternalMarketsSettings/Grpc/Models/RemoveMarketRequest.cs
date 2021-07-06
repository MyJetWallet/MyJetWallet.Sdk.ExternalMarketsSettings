using System.Runtime.Serialization;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Grpc.Models
{
    [DataContract]
    public class RemoveMarketRequest
    {
        [DataMember(Order = 1)] public string Symbol { get; set; }
    }
}