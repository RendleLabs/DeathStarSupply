using System;
using System.Threading.Tasks;
using DeathStarSupplyGrpc.Protos;
using Grpc.Net.Client;

namespace DeathStarSupplyGrpcConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new SupplyService.SupplyServiceClient(GrpcChannel.ForAddress("https://localhost:5001"));

            var response = await client.GetSuppliesAsync(new GetSuppliesRequest());

            foreach (var responseItem in response.Items)
            {
                Console.WriteLine($"{responseItem.Code}: {responseItem.Description}");
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }
}
