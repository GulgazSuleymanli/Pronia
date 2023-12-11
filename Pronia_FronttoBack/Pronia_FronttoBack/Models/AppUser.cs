
namespace Pronia_FronttoBack.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRemained { get; set; }
        public List<BasketDbItem> BasketDbItems { get; set; }
    }
}
