using Autofac;
using Service.Liquidity.InternalWallets.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.Liquidity.InternalWallets.Client
{
    public static class AutofacHelper
    {
        public static void InternalWalletsClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new InternalWalletsClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetLpWalletService()).As<ILpWalletService>().SingleInstance();
            builder.RegisterInstance(factory.GetExternalMarketsGrpc()).As<IExternalMarketsGrpc>().SingleInstance();
        }
    }
}
