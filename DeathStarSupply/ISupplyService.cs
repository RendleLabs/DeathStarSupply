using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
