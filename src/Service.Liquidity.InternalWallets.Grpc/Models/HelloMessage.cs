using System.Runtime.Serialization;
using Service.Liquidity.InternalWallets.Domain.Models;

namespace Service.Liquidity.InternalWallets.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}