using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.ExternalMarketsSettings.Models;
using MyJetWallet.Sdk.ExternalMarketsSettings.NoSql;
using MyJetWallet.Sdk.ExternalMarketsSettings.Settings;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.Sdk.ExternalMarketsSettings.Services
{
    public class ExternalMarketSettingAccessor : IExternalMarketSettingsAccessor
    {
        private readonly IMyNoSqlServerDataReader<ExternalMarketSettingsNoSql> _reader;
        
        private Dictionary<string, ExternalMarketSettings> _externalMarketSettings = new();
        private readonly string _name;

        private readonly object _sync = new();

        public ExternalMarketSettingAccessor( 
            IMyNoSqlServerDataReader<ExternalMarketSettingsNoSql> reader,
            string name)
        {
            _reader = reader;
            _name = name;
            
            ReloadSettings().GetAwaiter().GetResult();
            
        }

        public ExternalMarketSettings GetExternalMarketSettings(string market)
        {
            lock (_sync)
                return _externalMarketSettings[market];
        }

        public List<ExternalMarketSettings> GetExternalMarketSettingsList()
        {

            lock (_sync)
            {
                return _externalMarketSettings.Values.ToList();
            }
        }
        
        private async Task ReloadSettings()
        {
            var markets = (_reader.Get(ExternalMarketSettingsNoSql.GeneratePartitionKey(_name)))
                .ToList().Select(e => new ExternalMarketSettings()
                {
                    Market = e.Settings.Market,
                    BaseAsset = e.Settings.BaseAsset,
                    QuoteAsset = e.Settings.QuoteAsset,
                    MinVolume = e.Settings.MinVolume,
                    PriceAccuracy = e.Settings.PriceAccuracy,
                    VolumeAccuracy = e.Settings.VolumeAccuracy,
                    Active = e.Settings.Active,
                    Levels = e.Settings.Levels,
                    AssociateInstrument = e.Settings.AssociateInstrument,
                    AssociateBaseAsset = e.Settings.AssociateBaseAsset,
                    AssociateQuoteAsset = e.Settings.AssociateQuoteAsset
                }).ToDictionary(e => e.Market, e => e);

            lock (_sync)
            {
                _externalMarketSettings = markets;
            }
        }
    }
}