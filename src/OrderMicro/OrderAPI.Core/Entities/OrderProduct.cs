using OrderAPI.SharedKernel;

namespace OrderAPI.Core.Entities
{
    public class OrderProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
    }
}
