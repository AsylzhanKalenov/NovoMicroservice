using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Core.DTOs
{
    public class OrderProduct
    {
        public class CreateOrderProductRequest
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Amount { get; set; }
        }
        public class OrderProductResponse
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Amount { get; set; }
        }
    }
}
