namespace Market.Api.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}