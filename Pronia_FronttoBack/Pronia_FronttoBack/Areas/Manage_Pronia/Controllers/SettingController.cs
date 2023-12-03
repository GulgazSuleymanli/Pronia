
namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Setting> settings = await _context.Settings.ToListAsync();

            if (settings != null)
            {
                return View(settings);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Settings.FirstOrDefaultAsync(x => x.Key == setting.Key) != null)
            {
                ModelState.AddModelError("Key", "Key can not be same");
                return View(setting);
            }

            _context.Settings.Add(setting);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            return View(setting);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Setting setting)
        {
            Setting existSetting = await _context.Settings.FirstOrDefaultAsync(c => c.Id == setting.Id);
            if (!ModelState.IsValid)
            {
                return View(existSetting);
            }

            if (await _context.Settings.FirstOrDefaultAsync(x => x.Key == setting.Key && x.Id != setting.Id) != null)
            {
                ModelState.AddModelError("Key", "Key can not be same");
                return View(setting);
            }

            if (setting.Value != null)
            {
                existSetting.Value = setting.Value;
            }

            existSetting.Key = setting.Key;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(c => c.Id == id);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion
    }
}
