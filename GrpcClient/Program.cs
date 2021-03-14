using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cart;
using Grpc.Net.Client;

namespace GrpcClient
{
    class Program
    {
        private const string CartServer = "http://cart:5001";

        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Cart Server...");
            Thread.Sleep(5000);
            
            using var channel = GrpcChannel.ForAddress(CartServer);
            var client = new CartGrpc.CartGrpcClient(channel);

            var reply = client.GetTotal(new TotalRequest
            {
                Id = "1"
            });

            Console.WriteLine($"Total: {reply.Total}");
        }

        // NOTE: Didn't work, Error: Response ended prematurely
        private static async Task PingCartServer()
        {
            try
            {
                using var client = new HttpClient();

                await client.GetStringAsync(CartServer);
            }
            catch (Exception)
            {
                Console.WriteLine("Waiting for Cart Server...");

                Thread.Sleep(500);

                await PingCartServer();
            }
        }
    }
}
