namespace Pronia_FronttoBack.Models
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set;}
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ProductColor> PrdColors { get; set; }
        public List<ProductTag> PrdTags { get; set; }
        public List<ProductSize> PrdSizes { get; set; }
        public List<Image> Images { get; set; }
        public List<BasketDbItem> BasketDbItems { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
