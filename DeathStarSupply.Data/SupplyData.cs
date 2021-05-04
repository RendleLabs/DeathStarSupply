using System.Collections.Generic;
using System.Linq;

namespace DeathStarSupply.Data
{
    public class SupplyData
    {
        public IEnumerable<Item> GetItems() => Items.AsEnumerable();

        public bool TryDepleteStock(string code, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Code == code);
            if (item is null) return false;
            if (item.Available < quantity) return false;
            item.Available -= quantity;
            return true;
        }

        private static readonly List<Item> Items = new List<Item>()
        {
            new Item
            {
                Code = "BLAST",
                Description = "Blaster",
                Available = 150,
                Price = 199.99m
            },
            new Item
            {
                Code = "HTLASER",
                Description = "Huge Turbo Laser",
                Available = 6,
                Price = 899.99m
            },
            new Item
            {
                Code = "EXPCOV",
                Description = "Exhaust Port Security Cover",
                Available = 0,
                Price = 99.99m
            },
            new Item
            {
                Code = "LPLDG",
                Description = "Lemon Pledge",
                Available = 0,
                Price = 1.49m
            },
        };
    }
}