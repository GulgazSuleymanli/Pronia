using Microsoft.AspNetCore.Mvc;
using Pronia_FronttoBack.Models;

namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class ShippingController : Controller
    {
        AppDbContext _context;

        public ShippingController(AppDbContext context)
        {
            _context = context;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shipping shipping)
        {
            if (shipping != null)
            {
                _context.Shippers.Add(shipping);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Shipping shipping)
        {
            if (shipping != null)
            {
                _context.Shippers.Find(shipping.Id).Title = shipping.Title;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            Shipping shipping = _context.Shippers.Find(id);
            if (shipping != null)
            {
                _context.Shippers.Remove(shipping);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
