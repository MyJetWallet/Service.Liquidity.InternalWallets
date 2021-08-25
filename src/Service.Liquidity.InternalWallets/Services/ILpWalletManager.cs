using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Balances.Domain.Models;
using Service.Liquidity.InternalWallets.Domain.Models;

namespace Service.Liquidity.InternalWallets.Services
{
    public interface ILpWalletManager
    {
        List<WalletBalance> GetBalances(string walletName);

        LpWallet GetWallet(string walletName);

        LpWallet GetWalletById(string walletId);

        Task AddWalletAsync(LpWallet wallet);

        Task RemoveWalletAsync(string name);

        List<LpWallet> GetAll();
    }
}