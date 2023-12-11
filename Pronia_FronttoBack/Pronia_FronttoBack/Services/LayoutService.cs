using Newtonsoft.Json;
using Pronia_FronttoBack.ViewModels;
using System.Security.Claims;

namespace Pronia_FronttoBack.Services
{
    public class LayoutService
    {
        AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext appDbContext, IHttpContextAccessor http, UserManager<AppUser> userManager)
        {
            _appDbContext = appDbContext;
            _http = http;
            _userManager = userManager;
        }

        public async Task<Dictionary<string, string>> GetSetting()
        {
            var setting = await _appDbContext.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return setting;
        }

        public async Task<List<BasketItemVM>> GetBasket()
        {
            List<BasketItemVM> basket = new List<BasketItemVM>();
            
            if(_http.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.Users
                   .Include(x => x.BasketDbItems)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(y => y.Images.Where(x => x.IsPrimary == true))
                   .FirstOrDefaultAsync(x => x.Id == _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


                foreach (var item in user.BasketDbItems)
                {
                    Product product = await _appDbContext.Products
                                    .Include(p => p.Images.Where(pi => pi.IsPrimary == true))
                                    .FirstOrDefaultAsync(p => p.Id == item.ProductId);

                    if (product != null)
                    {
                        basket.Add(new BasketItemVM()
                        {
                            Id = item.ProductId,
                            Name = product.Title,
                            Price = product.Price,
                            ImageUrl = product.Images.FirstOrDefault().ImageUrl,
                            Count = item.Count
                        });
                    }
                }
            }
            else
            {
                var jsonBasket = _http.HttpContext.Request.Cookies["Basket"];

                if (jsonBasket != null)
                {
                    List<BasketCookieVM> basketCookie = JsonConvert.DeserializeObject<List<BasketCookieVM>>(jsonBasket);

                    foreach (var item in basketCookie)
                    {
                        Product product = await _appDbContext.Products.Include(p => p.Images.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == item.Id);

                        if (product != null)
                        {
                            basket.Add(new BasketItemVM()
                            {
                                Id = item.Id,
                                Name = product.Title,
                                Price = product.Price,
                                ImageUrl = product.Images.FirstOrDefault().ImageUrl,
                                Count = item.Count
                            });
                        }
                    }
                }
            }

            return basket;
        }
    }
}
