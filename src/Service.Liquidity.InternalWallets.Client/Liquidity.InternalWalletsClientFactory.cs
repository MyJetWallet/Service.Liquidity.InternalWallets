using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.Liquidity.InternalWallets.Grpc;

namespace Service.Liquidity.InternalWallets.Client
{
    [UsedImplicitly]
    public class InternalWalletsClientFactory: MyGrpcClientFactory
    {
        public InternalWalletsClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
