using System;
using System.Threading.Tasks;
using DeathStarClientConsole.DeathStarSupply;

namespace DeathStarClientConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new SupplyServiceClient("BasicHttpBinding_ISupplyService");
            var items = await client.GetSuppliesAsync();

            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];
                Console.WriteLine($"[{i+1}] {item.Code}:\t{item.Description}");
            }

            Console.WriteLine("[Q] Quit");

            Console.Write("Order: ");
            var input = Console.ReadLine();
            while (!"q".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(input, out int index) && index > 0 && index <= items.Length)
                {
                    var item = items[index - 1];
                    Console.Write("Quantity: ");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out var quantity))
                    {
                        var requiredDate = DateTimeOffset.UtcNow.AddDays(1);
                        try
                        {
                            var expectedDate = await client.OrderItemAsync(item.Code, quantity, requiredDate);
                            Console.WriteLine($"{quantity} items expected {expectedDate:R}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Order failed: {ex.Message}");
                        }
                    }
                }
                Console.Write("Choose: ");
                input = Console.ReadLine();
            }

        }
    }
}
