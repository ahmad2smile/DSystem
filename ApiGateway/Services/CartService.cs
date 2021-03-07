using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart;
using Grpc.Net.Client;

namespace ApiGateway.Services
{
    public class CartService: ICartService
    {
        private readonly CartGrpc.CartGrpcClient _client;

        public CartService()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new CartGrpc.CartGrpcClient(channel);
        }

        public async Task<int> GetTotal(string cartId)
        {
            var reply = await _client.GetTotalAsync(new TotalRequest
            {
                Id = cartId
            });

            return reply.Total;
        }
    }
}
