using System;
using Cart;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CartGrpc.CartGrpcClient(channel);

            var reply = client.GetTotal(new TotalRequest
            {
                Id = "1"
            });

            Console.WriteLine($"Total: {reply.Total}");
            Console.ReadKey();
        }
    }
}
