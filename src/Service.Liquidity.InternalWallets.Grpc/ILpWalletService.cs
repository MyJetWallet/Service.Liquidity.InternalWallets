using System.ServiceModel;
using System.Threading.Tasks;
using Service.Balances.Domain.Models;
using Service.Liquidity.InternalWallets.Domain.Models;
using Service.Liquidity.InternalWallets.Grpc.Models;

namespace Service.Liquidity.InternalWallets.Grpc
{
    [ServiceContract]
    public interface ILpWalletService
    {
        [OperationContract]
        Task<GrpcResponseWithData<GrpcList<WalletBalance>>> GetBalancesAsync(WalletNameRequest request);

        [OperationContract]
        Task AddWalletAsync(LpWallet wallet);

        [OperationContract]
        Task RemoveWalletAsync(WalletNameRequest request);

        [OperationContract]
        Task<GrpcResponseWithData<GrpcList<LpWallet>>> GetAllAsync();
    }
}