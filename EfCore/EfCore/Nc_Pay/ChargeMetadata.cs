using System;

namespace EfCore.Nc_Pay
{
    public class ChargeMetadata
    {
        public int Id { get; set; }
        public Guid ChargeId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Charge Charge { get; set; }
    }
}
