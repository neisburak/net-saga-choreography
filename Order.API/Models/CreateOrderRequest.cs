using System.Collections.Generic;

namespace Order.API.Models
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}