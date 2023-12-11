namespace Pronia_FronttoBack.Models
{
    public class BasketDbItem:BaseEntity
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
