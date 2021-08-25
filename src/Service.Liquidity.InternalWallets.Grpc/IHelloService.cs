using System.ServiceModel;
using System.Threading.Tasks;
using Service.Liquidity.InternalWallets.Grpc.Models;

namespace Service.Liquidity.InternalWallets.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}