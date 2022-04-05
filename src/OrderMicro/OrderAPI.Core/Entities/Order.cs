using OrderAPI.SharedKernel;
using OrderAPI.SharedKernel.Interfaces;
using System;

namespace OrderAPI.Core.Entities
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public double Summ { get; set; }
        public Guid CustomerId { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
