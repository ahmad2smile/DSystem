using System.Threading.Tasks;
using Grpc.Core;

namespace Cart.Services
{
    public class CartService: CartGrpc.CartGrpcBase
    {
        public override Task<TotalReply> GetTotal(TotalRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TotalReply
            {
                Total = 99
            });
        }
    }
}
