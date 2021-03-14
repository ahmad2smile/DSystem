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
            var channel = GrpcChannel.ForAddress("http://cart:5001");
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

        public async Task<AddItemReply> AddItem(AddItemRequest request)
        {
            var reply = await _client.AddItemAsync(request);

            return reply;
        }

        public async Task<RemoveItemReply> RemoveItem(RemoveItemRequest request)
        {
            var reply = await _client.RemoveItemAsync(request);

            return reply;
        }
    }
}
