using OrderAPI.SharedKernel;
using OrderAPI.SharedKernel.Interfaces;
using System;

namespace OrderAPI.Core.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public double TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }

        // BillingAddress
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        // Payment
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }

        // DateOfActives
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
