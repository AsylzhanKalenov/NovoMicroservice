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
        public double TotalPrice { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Expiration { get; set; }
        [Required]
        public string CVV { get; set; }
        [Required]
        public int PaymentMethod { get; set; }
        //[Required]
        public CreateOrderProductRequest[] OrderProducts { get; set; }
    }

    public class UpdateOrderRequest : CreateOrderRequest
    { 
    
    }

    public class OrderResponse
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public Guid CustomerId { get; set; }
        public int StatusId { get; set; }
        public string EmailAddress { get; set; }
    }

    public class SingleOrderResponse : OrderResponse
    {
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
        OrderProductResponse[] OrderProducts { get; set; }
    }
}
