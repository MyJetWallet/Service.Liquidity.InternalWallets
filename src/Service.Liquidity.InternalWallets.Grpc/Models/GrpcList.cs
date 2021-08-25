using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Service.Liquidity.InternalWallets.Grpc.Models
{
    [DataContract]
    public class GrpcList<T>
    {
        [DataMember(Order = 1)] public List<T> List { get; set; }

        public static GrpcList<T> Create(List<T> data)
        {
            return new()
            {
                List = data
            };
        }
    }
}