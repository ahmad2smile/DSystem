using System;
using System.Threading.Tasks;
using Grpc.Core;
using MassTransit;

namespace Cart.Services
{
    public class CartService: CartGrpc.CartGrpcBase
    {
        private readonly IBus _bus;

        public CartService(IBus bus)
        {
            _bus = bus;
        }

        public override Task<TotalReply> GetTotal(TotalRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TotalReply
            {
                Total = 99
            });
        }

        public override async Task<AddItemReply> AddItem(AddItemRequest request, ServerCallContext context)
        {
            var reply = new AddItemReply
            {
                ItemId = request.ItemId,
                UserId = request.UserId
            };

            if (request.ItemId != null && request.UserId != null)
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/cartQueue"));

                await endpoint.Send(reply);
            }

            return reply;
        }

        public override async Task<RemoveItemReply> RemoveItem(RemoveItemRequest request, ServerCallContext context)
        {
            var reply = new RemoveItemReply
            {
                ItemId = request.ItemId,
                UserId = request.UserId
            };

            if (request.ItemId != null && request.UserId != null)
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://rabbitmq/cartQueue"));

                await endpoint.Send(reply);
            }

            return reply;
        }
    }
}
