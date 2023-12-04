namespace Pronia_FronttoBack.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var setting = await _context.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return View(setting);
        }
    }
}
