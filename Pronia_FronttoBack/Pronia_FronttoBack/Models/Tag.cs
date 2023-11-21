namespace Pronia_FronttoBack.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
