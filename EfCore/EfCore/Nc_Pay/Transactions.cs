using System;
using System.Collections.Generic;

namespace EfCore.Nc_Pay
{
    public class Transactions
    {
        public Transactions()
        {
            Charges = new HashSet<Charge>();
        }

        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ExternalId { get; set; }
        public int Status { get; set; }
        public byte[] Timestamp { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string PaymentMetadata { get; set; }
        public DateTime? AcceptedAt { get; set; }

        public ICollection<Charge> Charges { get; set; }
    }
}
