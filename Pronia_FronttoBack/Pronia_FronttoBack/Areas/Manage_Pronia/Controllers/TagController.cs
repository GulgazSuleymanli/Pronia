using Microsoft.AspNetCore.Mvc;
using Pronia_FronttoBack.Models;

namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class TagController : Controller
    {
        AppDbContext _context;

        public TagController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Tag> tags = await _context.Tags.ToListAsync();
            if (tags != null)
            {
                return View(tags);
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
        public async Task<IActionResult> Create(Tag tag)
        {
            if (tag.Name == null)
            {
                ModelState.AddModelError("Name", "Name can not be null");
                return View();
            }

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Tag tag)
        {
            if (tag.Name == null)
            {
                ModelState.AddModelError("Name", "Name can not be null");
                return View();
            }

            _context.Tags.Find(tag.Id).Name = tag.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Tag tag = _context.Tags.Find(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
