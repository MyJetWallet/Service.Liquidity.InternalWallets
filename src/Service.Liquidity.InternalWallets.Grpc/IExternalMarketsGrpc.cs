using System.ServiceModel;
using System.Threading.Tasks;
using MyJetWallet.Domain.ExternalMarketApi.Models;
using Service.Liquidity.InternalWallets.Grpc.Models;

namespace Service.Liquidity.InternalWallets.Grpc
{
    [ServiceContract]
    public interface IExternalMarketsGrpc
    {
        [OperationContract]
        Task<GrpcResponseWithData<GrpcList<string>>> GetExternalMarketListAsync();

        [OperationContract]
        Task<GrpcResponseWithData<GrpcList<AssetBalanceDto>>> GetBalancesAsync(SourceDto request);

        [OperationContract]
        Task<GrpcResponseWithData<GrpcList<ExchangeMarketInfo>>> GetInstrumentsAsync(SourceDto request);
    }
}