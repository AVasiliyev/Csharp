using System;

namespace EfCore.Nc_Pay
{
    public class Customers
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DefaultPaymentMethod { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
