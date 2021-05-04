using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeathStarSupply.Data;
using DeathStarSupplyGrpc.Protos;

namespace DeathStarSupplyGrpc
{
    public class SupplyServiceImpl : SupplyService.SupplyServiceBase
    {
        private readonly SupplyData _data;

        public SupplyServiceImpl(SupplyData data)
        {
            _data = data;
        }

        public override Task<GetSuppliesResponse> GetSupplies(GetSuppliesRequest request, ServerCallContext context)
        {
            var response = new GetSuppliesResponse
            {
                Items =
                {
                    _data.GetItems().Select(i => new SupplyItem
                    {
                        Code = i.Code,
                        Description = i.Description,
                        Available = i.Available,
                        Price = Convert.ToDouble(i.Price)
                    })
                }
            };
            return Task.FromResult(response);
        }
    }
}
