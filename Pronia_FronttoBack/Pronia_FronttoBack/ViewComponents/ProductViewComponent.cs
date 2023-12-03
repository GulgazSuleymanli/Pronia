namespace Pronia_FronttoBack.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key="1")
        {
            List<Product> Products;
            
            switch (key)
            {
                case "1":
                    Products = await _context.Products
                                            .Where(i=>i.Images!=null)
                                            .Include(p=>p.Images)
                                            .OrderBy(p=>p.Title)
                                            .Take(8).ToListAsync();
                    break;
                
                case "2":
                    Products = await _context.Products
                                            .Where(i => i.Images != null)
                                            .Include(p => p.Images)
                                            .OrderByDescending(p => p.Price)
                                            .Take(8).ToListAsync();
                    break; 
                
                case "3":
                    Products = await _context.Products
                                            .Where(i => i.Images != null)
                                            .Include(p => p.Images)
                                            .OrderByDescending(p => p.Id)
                                            .Take(8).ToListAsync();
                    break;
                
                default:
                    Products = await _context.Products
                                            .Where(i => i.Images != null)
                                            .Include(p => p.Images)
                                            .Take(8).ToListAsync();
                    break;
            }

            return View(Products);
        }
    }
}
