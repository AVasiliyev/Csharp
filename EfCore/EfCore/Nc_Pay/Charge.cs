using System;
using System.Collections.Generic;

namespace EfCore.Nc_Pay
{
    public class Charge
    {
        public Charge()
        {
            ChargeLogs = new HashSet<ChargeLogs>();
            ChargeMetadata = new HashSet<ChargeMetadata>();
            Refunds = new HashSet<Refunds>();
        }

        public Guid Id { get; set; }
        public long AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Currency { get; set; }
        public long CustomerId { get; set; }
        public decimal InitialAmount { get; set; }
        public string PaymentMethod { get; set; }
        public int Status { get; set; }
        public byte[] Timestamp { get; set; }
        public long? TransactionId { get; set; }
        public int Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ExternalOrderId { get; set; }

        public Transactions Transaction { get; set; }
        public ICollection<ChargeLogs> ChargeLogs { get; set; }
        public ICollection<ChargeMetadata> ChargeMetadata { get; set; }
        public ICollection<Refunds> Refunds { get; set; }
    }
}
