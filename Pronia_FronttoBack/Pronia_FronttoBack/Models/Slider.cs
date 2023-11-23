using System.ComponentModel.DataAnnotations.Schema;

namespace Pronia_FronttoBack.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public int Offer { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
        public string Description { get; set; }

        [StringLength(maximumLength:100)]
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
