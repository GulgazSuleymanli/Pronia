namespace Pronia_FronttoBack.Models
{
    public class OrderItem:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string ImageUrl { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
