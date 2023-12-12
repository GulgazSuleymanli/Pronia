using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NuGet.ContentModel;
using Pronia_FronttoBack.DAL;
using Pronia_FronttoBack.Models;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Pronia_FronttoBack.Controllers
{
    //[Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {


            List<BasketItemVM> basketItems = new List<BasketItemVM>();
            List<BasketCookieVM> basketCookies = new List<BasketCookieVM>();
            if (Request.Cookies["Basket"] != null)
            {
                basketCookies = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["Basket"]);
                foreach (var item in basketCookies)
                {
                    Product product = await _context.Products.Include(p => p.Images.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == item.Id);

                    if (product == null)
                    {

                        continue;
                    }

                    basketItems.Add(new BasketItemVM()
                    {
                        Id = item.Id,
                        Name = product.Title,
                        Price = product.Price,
                        ImageUrl = product.Images.FirstOrDefault().ImageUrl,
                        Count = item.Count
                    });
                }
            }

            Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basketCookies));


            return View(basketItems);


        }

        public async Task<IActionResult> AddBasket(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            List<BasketItemVM> basketItemVMs = new List<BasketItemVM>();

            if(User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.Users
                               .Include(x => x.BasketDbItems)
                               .FirstOrDefaultAsync(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

                BasketDbItem exist = user.BasketDbItems.FirstOrDefault(bi=>bi.ProductId == product.Id);

                if (exist == null)
                {
                    BasketDbItem basketDbItem = new BasketDbItem()
                    {
                        Count = 1,
                        ProductId = product.Id,
                        AppUserId = user.Id,
                    };

                    _context.BasketDbItems.Add(basketDbItem);
                }
                else
                {
                    exist.Count++;
                }

                await _context.SaveChangesAsync();

                foreach (var item in user.BasketDbItems)
                {
                    Product newProduct = await _context.Products
                        .Include(x => x.Images.Where(x => x.IsPrimary == true))
                        .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                    if (newProduct is not null)
                    {
                        basketItemVMs.Add(new BasketItemVM
                        {
                            Id = item.ProductId,
                            Name = newProduct.Title,
                            Price = newProduct.Price,
                            ImageUrl = newProduct.Images[0].ImageUrl,
                            Count = item.Count
                        });
                    }
                }
            }
            else
            {
                List<BasketCookieVM> basket = new List<BasketCookieVM>();
                if (Request.Cookies["Basket"] == null)
                {
                    BasketCookieVM basketCookieVm = new BasketCookieVM()
                    {
                        Id = id,
                        Count = 1
                    };

                    basket.Add(basketCookieVm);
                }
                else
                {
                    basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["Basket"]);
                    BasketCookieVM existBasket = basket.FirstOrDefault(p => p.Id == id);

                    if (existBasket != null)
                    {
                        existBasket.Count += 1;
                    }
                    else
                    {
                        BasketCookieVM basketCookieVm = new BasketCookieVM()
                        {
                            Id = id,
                            Count = 1
                        };
                        basket.Add(basketCookieVm);
                    }
                }
                var json = JsonConvert.SerializeObject(basket);
                Response.Cookies.Append("Basket", json);


                foreach (var item in basket)
                {
                    Product newProduct = await _context.Products
                        .Include(x => x.Images.Where(x => x.IsPrimary == true))
                        .FirstOrDefaultAsync(x => x.Id == item.Id);

                    if (newProduct is not null)
                    {
                        basketItemVMs.Add(new BasketItemVM
                        {
                            Id = item.Id,
                            Name = newProduct.Title,
                            Price = newProduct.Price,
                            ImageUrl = newProduct.Images[0].ImageUrl,
                            Count = item.Count
                        });
                    }
                }
            }

            return PartialView("_BasketPartialView", basketItemVMs);
        }


        #region Remove
        public async Task<IActionResult> RemoveBasket(int id)
        {
            string json = Request.Cookies["Basket"];

            if (json is not null)
            {
                List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);

                BasketCookieVM product = basket.FirstOrDefault(p => p.Id == id);

                if (product is not null)
                {
                    basket.Remove(product);
                }

                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket));
            }

            return RedirectToAction(nameof(Index),"Home");
        }
        #endregion

        public async Task<IActionResult> RemoveCartItem(int id)
        {
            string json = Request.Cookies["Basket"];

            if (json is not null)
            {
                List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);

                BasketCookieVM product = basket.FirstOrDefault(p => p.Id == id);

                if (product is not null)
                {
                    basket.Remove(product);
                }

                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PlusBasket(int id)
        {
            string json = Request.Cookies["Basket"];

            if (json is not null)
            {
                List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);

                BasketCookieVM product = basket.FirstOrDefault(p => p.Id == id);

                if (product is not null)
                {
                    product.Count += 1;
                    basket.Add(product);
                }

                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket));
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
