

namespace Pronia_FronttoBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {
                Shippers = await _context.Shippers.ToListAsync(),
                Sliders = await _context.Sliders.OrderByDescending(x => x.Id).Take(2).ToListAsync(),
                Products = await _context.Products.Include(p=>p.Images).OrderByDescending(x=>x.Id).Take(4).ToListAsync()
            };

            return View(vm);
        }
    }
}
