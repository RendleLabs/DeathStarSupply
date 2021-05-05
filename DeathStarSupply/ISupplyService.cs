using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DeathStarSupply
{
    [ServiceContract]
    public interface ISupplyService
    {

        [OperationContract]
        IEnumerable<SupplyItem> GetSupplies();

        [OperationContract]
        DateTimeOffset OrderItem(string code, int quantity, DateTimeOffset requiredDate);
    }
}
