using Pronia_FronttoBack.Utilities.Enums;

namespace Pronia_FronttoBack.Models
{
    public class Order:BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public double TotalPrice { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<BasketDbItem> BasketDbItems { get; set; }

    }
}
