namespace Pronia_FronttoBack.ViewModels
{
    public class OrderVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<CheckoutItemVM> CheckoutItemVMs = new List<CheckoutItemVM>();
    }
}
