using Microsoft.AspNetCore.Authorization;
using Pronia_FronttoBack.Areas.Manage_Pronia.ViewModels;
using Pronia_FronttoBack.Migrations;
using Pronia_FronttoBack.Models;
using System.Drawing;
using Color = Pronia_FronttoBack.Models.Color;
using Image = Pronia_FronttoBack.Models.Image;
using Size = Pronia_FronttoBack.Models.Size;

namespace Pronia_FronttoBack.Areas.Manage_Pronia.Controllers
{
    [Area("Manage_Pronia")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<Product> Products = await _context.Products
                                    .Include(c => c.Category)
                                    .Include(t => t.PrdTags).ThenInclude(p => p.Tag)
                                    .Include(c => c.PrdColors).ThenInclude(p => p.Color)
                                    .Include(s => s.PrdSizes).ThenInclude(p => p.Size)
                                    .Include(i => i.Images)
                                    .ToListAsync();

            return View(Products);
        }
        #endregion

        #region Create Get
        public async Task<IActionResult> Create()
        {
            CreateProductVM productVM = new CreateProductVM();

            productVM.Categories = await _context.Categories.ToListAsync();
            productVM.Colors = await _context.Colors.ToListAsync();
            productVM.Sizes = await _context.Sizes.ToListAsync();
            productVM.Tags = await _context.Tags.ToListAsync();

            return View(productVM);
        } 
        #endregion

        #region Create Post
        
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
                PrdTags = new List<ProductTag>(),
                Images = new List<Image>()
            };

            if (productVM.ColorIds != null)
            {
                foreach (var colorid in productVM.ColorIds)
                {
                    Color color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == colorid);

                    if (color == null)
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

            if(!productVM.MainPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Wrong file type");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            if (!productVM.MainPhoto.CheckLength(2000))
            {
                ModelState.AddModelError("MainPhoto", "Wrong file length");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            if (!productVM.HoverPhoto.CheckType("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Wrong file type");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            if (!productVM.HoverPhoto.CheckLength(2000))
            {
                ModelState.AddModelError("HoverPhoto", "Wrong file length");
                productVM.Categories = await _context.Categories.ToListAsync();
                productVM.Colors = await _context.Colors.ToListAsync();
                productVM.Sizes = await _context.Sizes.ToListAsync();
                productVM.Tags = await _context.Tags.ToListAsync();

                return View(productVM);
            }

            Image mainImage = new Image()
            {
                IsPrimary = true,
                ProductId = product.Id,
                ImageUrl = productVM.MainPhoto.CreateFile(_env.WebRootPath, "Uploads/ProductImages")
            };

            Image hoverImage = new Image()
            {
                IsPrimary = false,
                ProductId = product.Id,
                ImageUrl = productVM.HoverPhoto.CreateFile(_env.WebRootPath, "Uploads/ProductImages")
            };

            foreach (var addPhoto in productVM.Photos)
            {
                if (!addPhoto.CheckType("image/"))
                {
                    continue;
                }

                if (!addPhoto.CheckLength(2000))
                {
                    continue;
                }

                Image image = new Image()
                {
                    IsPrimary = null,
                    ProductId = product.Id,
                    ImageUrl = addPhoto.CreateFile(_env.WebRootPath, "Uploads/ProductImages")
                };

                product.Images.Add(image);
            }

            product.Images.Add(mainImage); 
            product.Images.Add(hoverImage);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update Get
        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products
                            .Include(c => c.PrdColors).ThenInclude(p => p.Color)
                            .Include(t => t.PrdTags).ThenInclude(p => p.Tag)
                            .Include(s => s.PrdSizes).ThenInclude(p => p.Size)
                            .Include(i=>i.Images)
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            UpdateProductVM productVM = new UpdateProductVM()
            {
                Title = product.Title,
                Description = product.Description,
                ProductCode = product.ProductCode,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ColorIds = product.PrdColors.Select(c => c.ColorId).ToList(),
                TagIds = product.PrdTags.Select(c => c.TagId).ToList(),
                SizeIds = product.PrdSizes.Select(c => c.SizeId).ToList(),
                ImagesVM = new List<ImageVM>()
            };

            foreach (var item in product.Images)
            {
                ImageVM imageVM = new ImageVM()
                {
                    Id = item.Id,
                    IsPrimary = item.IsPrimary,
                    ImageUrl = item.ImageUrl
                };

                productVM.ImagesVM.Add(imageVM);
            }

            productVM.Categories = await _context.Categories.ToListAsync();
            productVM.Colors = await _context.Colors.ToListAsync();
            productVM.Sizes = await _context.Sizes.ToListAsync();
            productVM.Tags = await _context.Tags.ToListAsync();

            return View(productVM);
        } 
        #endregion

        #region Update Post

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM productVM)
        {
            Product existProduct = await _context.Products
                                .Include(c => c.PrdColors).ThenInclude(p => p.Color)
                                .Include(t => t.PrdTags).ThenInclude(p => p.Tag)
                                .Include(s => s.PrdSizes).ThenInclude(p => p.Size)
                                .Include(i=>i.Images)
                                .FirstOrDefaultAsync(p => p.Id == productVM.Id);

            if (existProduct == null) return NotFound();


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

            if (productVM.ColorIds != null)
            {
                foreach (var colorid in productVM.ColorIds)
                {
                    Color color = await _context.Colors.FirstOrDefaultAsync(x => x.Id == colorid);

                    if (color == null)
                    {
                        ModelState.AddModelError("ColorIds", "No such color exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }
                }

                List<int> newIds = productVM.ColorIds.Where(id => !existProduct.PrdColors.Exists(p => p.ColorId == id)).ToList();



                foreach (var colorId in newIds)
                {
                    ProductColor productColor = new ProductColor()
                    {
                        ColorId = colorId,
                        ProductId = productVM.Id
                    };

                    await _context.ProductColors.AddAsync(productColor);
                }

                List<ProductColor> removedPrdColors = existProduct.PrdColors.Where(pc => !productVM.ColorIds.Contains(pc.ColorId)).ToList();

                _context.ProductColors.RemoveRange(removedPrdColors);
            }

            if (productVM.TagIds != null)
            {
                foreach (var tagid in productVM.TagIds)
                {
                    Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tagid);

                    if (tag == null)
                    {
                        ModelState.AddModelError("TagIds", "No such color exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }
                }

                List<int> newIds = productVM.TagIds.Where(id => !existProduct.PrdTags.Exists(p => p.TagId == id)).ToList();

                foreach (var tagId in newIds)
                {
                    ProductTag productTag = new ProductTag()
                    {
                        TagId = tagId,
                        ProductId = productVM.Id
                    };

                    await _context.ProductTag.AddAsync(productTag);
                }

                List<ProductTag> removedPrdTags = existProduct.PrdTags.Where(pc => !productVM.TagIds.Contains(pc.TagId)).ToList();

                _context.ProductTag.RemoveRange(removedPrdTags);
            }

            if (productVM.SizeIds != null)
            {
                foreach (var sizeid in productVM.SizeIds)
                {
                    Size size = await _context.Sizes.FirstOrDefaultAsync(x => x.Id == sizeid);

                    if (size == null)
                    {
                        ModelState.AddModelError("SizeIds", "No such color exists");
                        productVM.Categories = await _context.Categories.ToListAsync();
                        productVM.Colors = await _context.Colors.ToListAsync();
                        productVM.Sizes = await _context.Sizes.ToListAsync();
                        productVM.Tags = await _context.Tags.ToListAsync();

                        return View(productVM);
                    }
                }

                List<int> newIds = productVM.SizeIds.Where(id => !existProduct.PrdSizes.Exists(p => p.SizeId == id)).ToList();

                foreach (var sizeId in newIds)
                {
                    ProductSize productSize = new ProductSize()
                    {
                        SizeId = sizeId,
                        ProductId = productVM.Id
                    };

                    await _context.ProductSize.AddAsync(productSize);
                }

                List<ProductSize> removedPrdSizes = existProduct.PrdSizes.Where(pc => !productVM.SizeIds.Contains(pc.SizeId)).ToList();

                _context.ProductSize.RemoveRange(removedPrdSizes);
            }

            if(productVM.MainPhoto != null)
            {
                if (!productVM.MainPhoto.CheckType("image/"))
                {
                    ModelState.AddModelError("MainPhoto", "Wrong file type");
                    productVM.Categories = await _context.Categories.ToListAsync();
                    productVM.Colors = await _context.Colors.ToListAsync();
                    productVM.Sizes = await _context.Sizes.ToListAsync();
                    productVM.Tags = await _context.Tags.ToListAsync();

                    return View(productVM);
                }

                if (!productVM.MainPhoto.CheckLength(2000))
                {
                    ModelState.AddModelError("MainPhoto", "Wrong file length");
                    productVM.Categories = await _context.Categories.ToListAsync();
                    productVM.Colors = await _context.Colors.ToListAsync();
                    productVM.Sizes = await _context.Sizes.ToListAsync();
                    productVM.Tags = await _context.Tags.ToListAsync();

                    return View(productVM);
                }

                Image existImage = existProduct.Images.FirstOrDefault(i => i.IsPrimary == true);
                existImage.ImageUrl.DeleteFile(_env.WebRootPath, "Uploads/ProductImages");
                existProduct.Images.Remove(existImage);

                Image image = new Image()
                {
                    IsPrimary = true,
                    ImageUrl = productVM.MainPhoto.CreateFile(_env.WebRootPath, "Uploads/ProductImages"),
                    ProductId = existProduct.Id
                };

                existProduct.Images.Add(image);
            }

            if (productVM.HoverPhoto != null)
            {
                if (!productVM.HoverPhoto.CheckType("image/"))
                {
                    ModelState.AddModelError("HoverPhoto", "Wrong file type");
                    productVM.Categories = await _context.Categories.ToListAsync();
                    productVM.Colors = await _context.Colors.ToListAsync();
                    productVM.Sizes = await _context.Sizes.ToListAsync();
                    productVM.Tags = await _context.Tags.ToListAsync();

                    return View(productVM);
                }

                if (!productVM.HoverPhoto.CheckLength(2000))
                {
                    ModelState.AddModelError("HoverPhoto", "Wrong file length");
                    productVM.Categories = await _context.Categories.ToListAsync();
                    productVM.Colors = await _context.Colors.ToListAsync();
                    productVM.Sizes = await _context.Sizes.ToListAsync();
                    productVM.Tags = await _context.Tags.ToListAsync();

                    return View(productVM);
                }

                Image existImage = existProduct.Images.FirstOrDefault(i => i.IsPrimary == false);
                existImage.ImageUrl.DeleteFile(_env.WebRootPath, "Uploads/ProductImages");
                existProduct.Images.Remove(existImage);

                Image image = new Image()
                {
                    IsPrimary = false,
                    ImageUrl = productVM.HoverPhoto.CreateFile(_env.WebRootPath, "Uploads/ProductImages"),
                    ProductId = existProduct.Id
                };

                existProduct.Images.Add(image);
            }

            List<Image> removeImages = existProduct.Images.Where(pt=>!productVM.ImageIds.Contains(pt.Id) && pt.IsPrimary==null).ToList();
            if(removeImages!=null)
            {
                foreach (var item in removeImages)
                {
                    existProduct.Images.Remove(item);
                    item.ImageUrl.DeleteFile(_env.WebRootPath, "Uploads/ProductImages");
                }
            }

            if(productVM.Photos != null)
            {
                foreach (var photo in productVM.Photos) 
                {
                    if (!photo.CheckType("image/"))
                    {
                        continue;
                    }

                    if (!photo.CheckLength(2000))
                    {
                        continue;
                    }

                    Image image = new Image()
                    {
                        IsPrimary = null,
                        ProductId = existProduct.Id,
                        ImageUrl = photo.CreateFile(_env.WebRootPath, "Uploads/ProductImages")
                    };

                    existProduct.Images.Add(image);
                }
            }


            existProduct.Title = productVM.Title;
            existProduct.Description = productVM.Description;
            existProduct.Price = productVM.Price;
            existProduct.ProductCode = productVM.ProductCode;
            existProduct.CategoryId = productVM.CategoryId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.Include(i=>i.Images).FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) NotFound();

            foreach (var item in product.Images)
            {
                item.ImageUrl.DeleteFile(_env.WebRootPath, "Uploads/ProductImages");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        } 
        #endregion
    }
}
