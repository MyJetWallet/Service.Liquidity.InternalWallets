using System.Linq;
using System.Threading.Tasks;
using MyJetWallet.Domain.ExternalMarketApi;
using MyJetWallet.Domain.ExternalMarketApi.Dto;
using MyJetWallet.Domain.ExternalMarketApi.Models;
using Service.Liquidity.InternalWallets.Grpc;
using Service.Liquidity.InternalWallets.Grpc.Models;

namespace Service.Liquidity.InternalWallets.Services.Grpc
{
    public class ExternalMarketsGrpc : IExternalMarketsGrpc
    {
        private readonly IExternalMarket _externalMarket;
        private readonly IExternalExchangeManager _externalExchangeManager;
        
        public ExternalMarketsGrpc(IExternalMarket externalMarket,
            IExternalExchangeManager externalExchangeManager)
        {
            _externalMarket = externalMarket;
            _externalExchangeManager = externalExchangeManager;
        }

        public async Task<GrpcResponseWithData<GrpcList<string>>> GetExternalMarketListAsync()
        {
            var data = await _externalExchangeManager.GetExternalExchangeCollectionAsync();

            var response = new GrpcResponseWithData<GrpcList<string>>
            {
                Data = GrpcList<string>.Create(data.ExchangeNames)
            };
            return response;
        }

        public async Task<GrpcResponseWithData<GrpcList<AssetBalanceDto>>> GetBalancesAsync(SourceDto request)
        {
            var data = await _externalMarket.GetBalancesAsync(new GetBalancesRequest()
            {
                ExchangeName = request.Source
            });

            var result = data.Balances.Select(e => new AssetBalanceDto(e.Symbol, (double)e.Balance, (double)e.Free)).ToList();

            return GrpcResponseWithData<GrpcList<AssetBalanceDto>>.Create(GrpcList<AssetBalanceDto>.Create(result));
        }

        public async Task<GrpcResponseWithData<GrpcList<ExchangeMarketInfo>>> GetInstrumentsAsync(SourceDto request)
        {
            var data = await _externalMarket.GetMarketInfoListAsync(new GetMarketInfoListRequest()
            {
                ExchangeName = request.Source
            });

            var response = new GrpcResponseWithData<GrpcList<ExchangeMarketInfo>>
            {
                Data = GrpcList<ExchangeMarketInfo>.Create(data.Infos)
            };
            return response;
        }
    }
}