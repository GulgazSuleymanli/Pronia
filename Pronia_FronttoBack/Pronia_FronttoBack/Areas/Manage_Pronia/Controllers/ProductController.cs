using Pronia_FronttoBack.Areas.Manage_Pronia.ViewModels;
using Pronia_FronttoBack.Migrations;

namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> Products = await _context.Products
                                    .Include(c=>c.Category)
                                    .Include(t=>t.PrdTags).ThenInclude(p=>p.Tag)
                                    .Include(c=>c.PrdColors).ThenInclude(p=>p.Color)
                                    .Include(s=>s.PrdSizes).ThenInclude(p=>p.Size)
                                    .Include(i=>i.Images)
                                    .ToListAsync();

            return View(Products);
        }

        public async Task<IActionResult> Create()
        {
            CreateProductVM productVM = new CreateProductVM();

            productVM.Categories = await _context.Categories.ToListAsync();
            productVM.Colors = await _context.Colors.ToListAsync();
            productVM.Sizes = await _context.Sizes.ToListAsync();
            productVM.Tags = await _context.Tags.ToListAsync();

            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            if (productVM == null) return NotFound();


            if (!ModelState.IsValid)
            {
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            if (productVM.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "At least one Category must be selected");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            if (!await _context.Categories.AnyAsync(x => x.Id == productVM.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "No such category exists");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            Product product = new Product()
            {
                Title = productVM.Title,
                Description = productVM.Description,
                ProductCode = productVM.ProductCode,
                Price = productVM.Price,
                CategoryId = productVM.CategoryId,
                PrdColors = new List<ProductColor>(),
                PrdSizes = new List<ProductSize>(),
                PrdTags = new List<ProductTag>()
            };

            if(productVM.ColorIds != null)
            {
                foreach (var colorid in productVM.ColorIds)
                {
                    Color color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == colorid);

                    if(color == null)
                    {
                        ModelState.AddModelError("ColorIds", "No such color exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }

                    ProductColor productColor = new ProductColor()
                    {
                        ColorId = colorid,
                        Product = product
                    };

                    product.PrdColors.Add(productColor);
                }
            }

            if (productVM.SizeIds != null)
            {
                foreach (var sizeid in productVM.SizeIds)
                {
                    Size size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == sizeid);

                    if (sizeid == null)
                    {
                        ModelState.AddModelError("SizeIds", "No such size exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }

                    ProductSize productSize = new ProductSize()
                    {
                        SizeId = sizeid,
                        Product = product
                    };

                    product.PrdSizes.Add(productSize);
                }
            }

            if (productVM.TagIds != null)
            {
                foreach (var tagid in productVM.TagIds)
                {
                    Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagid);

                    if (tag == null)
                    {
                        ModelState.AddModelError("TagIds", "No such tag exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }

                    ProductTag productTag = new ProductTag()
                    {
                        TagId = tagid,
                        Product = product
                    };

                    product.PrdTags.Add(productTag);
                }
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update()
        {
            UpdateProductVM productVM = new UpdateProductVM();

            productVM.Categories = await _context.Categories.ToListAsync();

            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM productVM)
        {
            Product existProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == productVM.Id);

            if (existProduct == null) return NotFound();


            if (!ModelState.IsValid)
            {
                productVM.Categories = await _context.Categories.ToListAsync();

                return View(productVM);
            }

            if (productVM.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "At least one Category must be selected");
                productVM.Categories = await _context.Categories.ToListAsync();

                return View(productVM);
            }

            if (!await _context.Categories.AnyAsync(x => x.Id == productVM.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "No such category exists");
                productVM.Categories = await _context.Categories.ToListAsync();

                return View(productVM);
            }

            existProduct.Title = productVM.Title;
            existProduct.Description = productVM.Description;
            existProduct.Price = productVM.Price;
            existProduct.ProductCode = productVM.ProductCode;
            existProduct.CategoryId = productVM.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);

            if (product == null) NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
