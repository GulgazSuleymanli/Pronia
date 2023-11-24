
namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class SliderController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            if (sliders != null)
            {
                return View(sliders);
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
        public async Task<IActionResult> Create(Slider slider)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "File can not be null");
                return View();
            }


            if (!slider.ImageFile.CheckType("image/"))
            {
                ModelState.AddModelError("ImageFile", "File must be image type");
                return View();
            }

            if (slider.ImageFile.CheckLength(300))
            {
                ModelState.AddModelError("ImageFile", "File can not be than" + 300 + "kb");
                return View();
            }



            slider.ImageUrl = slider.ImageFile.CreateFile(_env.WebRootPath, "Uploads/SliderImages");

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(Slider slider)
        {
            Slider oldSlider = await _context.Sliders.FirstOrDefaultAsync(s =>s.Id == slider.Id);

            if (slider == null)
            {
                return BadRequest();
            }

            if (slider.ImageFile != null)
            {
                oldSlider.ImageUrl.DeleteFile(_env.WebRootPath, @"Uploads\SliderImages");
                oldSlider.ImageUrl = slider.ImageFile.CreateFile(_env.WebRootPath, @"Uploads\SliderImages");
            }
            
            oldSlider.Title = slider.Title;
            oldSlider.Offer = slider.Offer;
            oldSlider.Description = slider.Description;
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);

            if (slider == null)
            {
                return NotFound();
            }

            slider.ImageUrl.DeleteFile(_env.WebRootPath, @"Uploads\SliderImages");

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
