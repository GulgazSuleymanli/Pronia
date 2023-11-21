namespace Pronia_FronttoBack.Models
{
    public class Shipping
    {
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
