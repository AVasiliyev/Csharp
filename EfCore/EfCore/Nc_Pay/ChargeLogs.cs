using System;

namespace EfCore.Nc_Pay
{
    public class ChargeLogs
    {
        public long Id { get; set; }
        public Guid ChargeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Entity { get; set; }
        public string EntityId { get; set; }
        public string EntityStatus { get; set; }
        public string Description { get; set; }
        public string ChargeStatus { get; set; }
        public string InitiatedBy { get; set; }

        public Charge Charge { get; set; }
    }
}
