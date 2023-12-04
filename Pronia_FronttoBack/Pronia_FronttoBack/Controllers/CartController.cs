using Newtonsoft.Json;

namespace Pronia_FronttoBack.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {


            List<BasketItemVM> basketItems = new List<BasketItemVM>();
            List<BasketCookieVM> basketCookies = new List<BasketCookieVM>();
            if (Request.Cookies["Basket"] != null)
            {
                basketCookies = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["Basket"]);
                foreach (var item in basketCookies)
                {
                    Product product = _context.Products.Include(p => p.Images.Where(pi => pi.IsPrimary == true)).FirstOrDefault(p => p.Id == item.Id);

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

        public IActionResult AddBasket(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            List<BasketCookieVM> basket;
            if (Request.Cookies["Basket"] == null)
            {
                BasketCookieVM basketCookieVm = new BasketCookieVM()
                {
                    Id = id,
                    Count = 1
                };
                basket = new List<BasketCookieVM>();
                basket.Add(basketCookieVm);
            }
            else
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["Basket"]);
                var existBasket = basket.FirstOrDefault(p => p.Id == id);
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

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult GetBasket()
        {
            var cookie = Request.Cookies["Basket"];

            return Content(cookie);
        }
    }
}
