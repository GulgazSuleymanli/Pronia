
namespace Pronia_FronttoBack.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(maximumLength:100)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }

    }
}
