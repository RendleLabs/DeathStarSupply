using System.Runtime.Serialization;

namespace DeathStarSupply
{
    [DataContract]
    public class SupplyItem
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Available { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}