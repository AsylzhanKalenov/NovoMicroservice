using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAPI.Core.DTOs.OrderProduct;

namespace OrderAPI.Core.DTOs
{
    public class CreateOrderRequest
    { 
        [Required]
        public double Summ { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public CreateOrderProductRequest[] OrderProducts { get; set; }
    }

    public class UpdateOrderRequest : CreateOrderRequest
    { 
    
    }

    public class OrderResponse
    {
        public int Id { get; set; }
        public double Summ { get; set; }
        public Guid CustomerId { get; set; }
        public int StatusId { get; set; }
    }

    public class SingleOrderResponse : OrderResponse
    {
        OrderProductResponse[] OrderProducts { get; set; }
    }
}
