using System.Linq;
using System.Runtime.Serialization;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Models
{
    [DataContract]
    public class ExternalMarketSettings
    {
        [DataMember(Order = 1)] public string Market { get; set; }
        [DataMember(Order = 2)] public int PriceAccuracy { get; set; }
        [DataMember(Order = 3)] public double MinVolume { get; set; }
        [DataMember(Order = 4)] public string BaseAsset { get; set; }
        [DataMember(Order = 5)] public string QuoteAsset { get; set; }
        [DataMember(Order = 6)] public int VolumeAccuracy { get; set; }
        [DataMember(Order = 7)] public string Levels { get; set; }
        [DataMember(Order = 8)] public bool Active { get; set; }
        [DataMember(Order = 9)] public string AssociateInstrument { get; set; }
        [DataMember(Order = 10)] public string AssociateBaseAsset { get; set; }
        [DataMember(Order = 11)] public string AssociateQuoteAsset { get; set; }

        public double[] GetDoubleLevels()
        {
            return Levels.Split(";").Select(double.Parse).ToArray();
        }
    }
}