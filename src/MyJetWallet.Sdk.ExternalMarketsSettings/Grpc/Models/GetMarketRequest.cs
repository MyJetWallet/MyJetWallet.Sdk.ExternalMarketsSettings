using System.Runtime.Serialization;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Grpc.Models
{
    [DataContract]
    public class GetMarketRequest
    {
        [DataMember(Order = 1)] public string Symbol { get; set; }
    }
}