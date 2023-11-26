using Microsoft.AspNetCore.Mvc;
using Pronia_FronttoBack.Models;

namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class ShippingController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShippingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Shipping> shippingList = await _context.Shippers.ToListAsync();
            if (shippingList != null)
            {
                return View(shippingList);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Shipping shipping)
        {
            if (shipping.IconFile == null)
            {
                ModelState.AddModelError("IconFile", "File can not be null");
                return View();
            }


            if (!shipping.IconFile.CheckType("image/"))
            {
                ModelState.AddModelError("IconFile", "File must be image type");
                return View();
            }

            if (shipping.IconFile.CheckLength(300))
            {
                ModelState.AddModelError("IconFile", "File can not be than" + 300 + "kb");
                return View();
            }



            shipping.IconUrl = shipping.IconFile.CreateFile(_env.WebRootPath, "Uploads/ShippingIcons");

            await _context.Shippers.AddAsync(shipping);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Shipping shipping)
        {
            Shipping oldShipper = await _context.Shippers.FirstOrDefaultAsync(s => s.Id == shipping.Id);

            if (shipping == null)
            {
                return BadRequest();
            }

            if (shipping.IconFile != null)
            {
                oldShipper.IconUrl.DeleteFile(_env.WebRootPath, @"Uploads\ShippingIcons");
                oldShipper.IconUrl = shipping.IconFile.CreateFile(_env.WebRootPath, @"Uploads\ShippingIcons");
            }

            oldShipper.Title = shipping.Title;
            oldShipper.Description = shipping.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Shipping Shipper = await _context.Shippers.FirstOrDefaultAsync(x => x.Id == id);

            if (Shipper == null)
            {
                return NotFound();
            }

            Shipper.IconUrl.DeleteFile(_env.WebRootPath, @"Uploads\ShippingIcons");

            _context.Shippers.Remove(Shipper);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
