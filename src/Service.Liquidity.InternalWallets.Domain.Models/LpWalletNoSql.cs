using MyNoSqlServer.Abstractions;

namespace Service.Liquidity.InternalWallets.Domain.Models
{
    public class LpWalletNoSql: MyNoSqlDbEntity
    {
        public const string TableName = "myjetwallet-liquitityprovider-wallets";
        public static string GeneratePartitionKey() => "wallets";
        public static string GenerateRowKey(string walletName) => walletName;
        public LpWallet Wallet { get; set; }
        public static LpWalletNoSql Create(LpWallet wallet)
        {
            return new LpWalletNoSql()
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(wallet.Name),
                Wallet = wallet
            };
        }
    }
}