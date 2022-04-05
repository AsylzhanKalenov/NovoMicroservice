using OrderAPI.SharedKernel;

namespace OrderAPI.Core.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public int OrderStatus { get; set; }
    }
}
