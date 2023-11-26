namespace Pronia_FronttoBack.Areas.Manage_Pronia.ViewModels
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
    }
}
