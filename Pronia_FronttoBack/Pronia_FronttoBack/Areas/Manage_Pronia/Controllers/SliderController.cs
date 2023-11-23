

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
        public IActionResult Create(Slider slider)
        {
            if (slider == null)
            {
                return BadRequest();
            }
            
            if(slider.ImageFile.ContentType != "image/")
            {
                ModelState.AddModelError("ImageFile", "Wrong file type");
                return View();
            }

            if(slider.ImageFile.Length > 200*1024)
            {
                ModelState.AddModelError("ImageFile", "Bigger file");
                return View();
            }

            string filename = slider.ImageFile.FileName;

            if (filename.Length > 64)
            {

                filename = filename.Substring(filename.Length - 64, 64);
            }

            filename = Guid.NewGuid().ToString() + filename;

            string path = _env.WebRootPath + @"\Upload\SliderImage\" + filename;


            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                slider.ImageFile.CopyTo(stream);
            }

            slider.ImageUrl = filename;

            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            if (slider == null)
            {
                return BadRequest();
            }

            








            _context.Sliders.Find(slider.Id).Title = slider.Title;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
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
