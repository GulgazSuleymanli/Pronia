using Microsoft.AspNetCore.Mvc;

namespace Pronia_FronttoBack.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await _context.Products.Include(i => i.Images)
                .Include(c => c.Category)
                .Include(p => p.PrdTags).ThenInclude(t => t.Tag)
                .Include(p => p.PrdColors).ThenInclude(c=>c.Color)
                .Include(p=>p.PrdSizes).ThenInclude(s=>s.Size)
                .FirstOrDefaultAsync(p => p.Id == id);

            ShopVM shopVM = new ShopVM()
            {
                Shippers =await _context.Shippers.ToListAsync(),
                Product = product,
                ReleatedProducts = await _context.Products.Include(i=>i.Images).Include(p=>p.Category).Where(c=>c.Category.Name==product.Category.Name).Take(4).ToListAsync()
            };

            return View(shopVM);
        }
    }
}
