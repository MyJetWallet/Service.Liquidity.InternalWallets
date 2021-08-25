using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.Liquidity.InternalWallets.Settings
{
    public class SettingsModel
    {
        [YamlProperty("InternalWallets.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("InternalWallets.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("InternalWallets.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("InternalWallets.MyNoSqlWriterUrl")]
        public string MyNoSqlWriterUrl { get; set; }
    }
}
