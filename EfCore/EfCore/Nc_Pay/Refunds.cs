using System;

namespace EfCore.Nc_Pay
{
    public class Refunds
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public Guid ChargeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Destination { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
        public byte[] Timestamp { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string PaymentMetadata { get; set; }

        public Charge Charge { get; set; }
    }
}
