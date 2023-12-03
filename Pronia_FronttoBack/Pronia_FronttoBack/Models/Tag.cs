namespace Pronia_FronttoBack.Models
{
    public class Tag:BaseEntity
    {
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; }
    }
}
