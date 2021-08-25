using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.Liquidity.InternalWallets.Settings
{
    public class SettingsModel
    {
        [YamlProperty("Liquidity.InternalWallets.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("Liquidity.InternalWallets.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("Liquidity.InternalWallets.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
    }
}
