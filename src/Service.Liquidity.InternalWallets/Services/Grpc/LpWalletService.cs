using System.Threading.Tasks;
using Service.Balances.Domain.Models;
using Service.Liquidity.InternalWallets.Domain.Models;
using Service.Liquidity.InternalWallets.Grpc;
using Service.Liquidity.InternalWallets.Grpc.Models;

namespace Service.Liquidity.InternalWallets.Services.Grpc
{
    public class LpWalletService : ILpWalletService
    {
        private readonly ILpWalletManager _manager;

        public LpWalletService(ILpWalletManager manager)
        {
            _manager = manager;
        }

        public Task<GrpcResponseWithData<GrpcList<WalletBalance>>> GetBalancesAsync(WalletNameRequest request)
        {
            var balances = _manager.GetBalances(request.WalletName);

            return GrpcResponseWithData<GrpcList<WalletBalance>>.CreateTask(GrpcList<WalletBalance>.Create(balances));
        }

        public Task AddWalletAsync(LpWallet wallet)
        {
            return _manager.AddWalletAsync(wallet);
        }

        public Task RemoveWalletAsync(WalletNameRequest request)
        {
            return _manager.RemoveWalletAsync(request.WalletName);
        }

        public Task<GrpcResponseWithData<GrpcList<LpWallet>>> GetAllAsync()
        {
            var data = _manager.GetAll();

            return GrpcResponseWithData<GrpcList<LpWallet>>.CreateTask(GrpcList<LpWallet>.Create(data));
        }
    }
}