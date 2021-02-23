using System;
using System.Collections.Generic;

namespace Market.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}