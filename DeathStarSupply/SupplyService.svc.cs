using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using DeathStarSupply.Data;

namespace DeathStarSupply
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class SupplyService : ISupplyService
    {
        public IEnumerable<SupplyItem> GetSupplies()
        {
            var data = new SupplyData();

            return data.GetItems().Select(i => new SupplyItem
            {
                Code = i.Code,
                Description = i.Description,
                Available = i.Available,
                Price = i.Price
            });
        }

        public DateTimeOffset OrderItem(string code, int quantity, DateTimeOffset requiredDate)
        {
            var data = new SupplyData();

            if (!data.TryDepleteStock(code, quantity))
            {
                throw new Exception("Item unavailable");
            }

            return requiredDate;
        }
    }
}
