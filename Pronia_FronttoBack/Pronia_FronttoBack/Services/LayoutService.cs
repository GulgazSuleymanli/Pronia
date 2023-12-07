using Newtonsoft.Json;

namespace Pronia_FronttoBack.Services
{
    public class LayoutService
    {
        AppDbContext _appDbContext;
        private readonly IHttpContextAccessor _http;

        public LayoutService(AppDbContext appDbContext, IHttpContextAccessor http)
        {
            _appDbContext = appDbContext;
            _http = http;
        }

        public async Task<Dictionary<string, string>> GetSetting()
        {
            var setting = await _appDbContext.Settings.ToDictionaryAsync(s => s.Key, s => s.Value);
            return setting;
        }

        public async Task<List<BasketItemVM>> GetBasket()
        {
            List<BasketItemVM> basket = new List<BasketItemVM>();
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

            return basket;
        }
    }
}
