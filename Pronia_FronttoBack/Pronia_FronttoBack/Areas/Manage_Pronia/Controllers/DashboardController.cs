
namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Manage_Pronia")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
