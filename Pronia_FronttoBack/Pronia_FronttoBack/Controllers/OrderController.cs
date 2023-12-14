using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pronia_FronttoBack.Services;
using System.Security.Claims;

namespace Pronia_FronttoBack.Controllers
{
    public class OrderController : Controller
    {
        readonly AppDbContext _context;
        readonly UserManager<AppUser> _userManager;
        readonly EmailService _emailService;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager, EmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }



        #region Checkout
        public async Task<IActionResult> Checkout()
        {
            OrderVM orderVM = new OrderVM();

            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.Users.Include(u => u.BasketDbItems).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

                orderVM.Name = user.Name;
                orderVM.Email = user.Email;
                orderVM.Surname = user.Surname;

                foreach (var item in user.BasketDbItems)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                    if (product != null)
                    {
                        orderVM.CheckoutItemVMs.Add(new CheckoutItemVM()
                        {
                            ProductId = product.Id,
                            Name = product.Title,
                            Count = item.Count,
                            Price = product.Price
                        });
                    }
                }
            }
            else
            {
                string json = Request.Cookies["Basket"];

                if (json is not null)
                {
                    List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);
                    foreach (var item in basket)
                    {
                        Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.Id);

                        if (product != null)
                        {
                            orderVM.CheckoutItemVMs.Add(new CheckoutItemVM
                            {
                                ProductId = product.Id,
                                Name = product.Title,
                                Count = item.Count,
                                Price = product.Price
                            });
                        }
                    }
                }
            }

            return View(orderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderVM orderVM)
        {
            AppUser user = null;

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.Users
                                .Include(u => u.BasketDbItems)
                               .FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            if (!ModelState.IsValid)
            {
                if (user == null)
                {
                    string json = Request.Cookies["Basket"];

                    if (json is not null)
                    {
                        List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);
                        foreach (var item in basket)
                        {
                            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.Id);

                            if (product != null)
                            {
                                orderVM.CheckoutItemVMs.Add(new CheckoutItemVM
                                {
                                    ProductId = product.Id,
                                    Name = product.Title,
                                    Count = item.Count,
                                    Price = product.Price
                                });
                            }
                        }
                    }
                }
                else
                {
                    orderVM.Name = user.Name;
                    orderVM.Email = user.Email;
                    orderVM.Surname = user.Surname;

                    foreach (var item in user.BasketDbItems)
                    {
                        Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);

                        if (product != null)
                        {
                            orderVM.CheckoutItemVMs.Add(new CheckoutItemVM
                            {
                                ProductId = product.Id,
                                Name = product.Title,
                                Count = item.Count,
                                Price = product.Price
                            });
                        }
                    }
                }
                return View(orderVM);
            }

            Order order = new Order()
            {
                CreateDate = DateTime.Now,
                TotalPrice = 0,
                Name = orderVM.Name,
                Surname = orderVM.Surname,
                Email = orderVM.Email,
                Address = orderVM.Address,
                Status = Utilities.Enums.OrderStatus.Pending,
                OrderItems = new List<OrderItem>()
            };

            double total = 0;

            if (user == null)
            {
                string json = Request.Cookies["Books"];

                if (json is not null)
                {
                    List<BasketCookieVM> basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(json);
                    foreach (var item in basket)
                    {
                        Product product = await _context.Products
                            .Include(x => x.Images.Where(y => y.IsPrimary == true))
                            .FirstOrDefaultAsync(x => x.Id == item.Id);

                        total += item.Count * product.Price;

                        if (product != null)
                        {
                            order.OrderItems.Add(new OrderItem
                            {
                                ProductId = product.Id,
                                ProductName = product.Title,
                                Count = item.Count,
                                Price = product.Price,
                                ImageUrl = product.Images[0].ImageUrl
                            });
                        }
                    }

                    Response.Cookies.Delete("Books");

                }
            }
            else
            {
                order.AppUserId = user.Id;

                foreach (var item in user.BasketDbItems)
                {
                    Product product = await _context.Products
                        .Include(x => x.Images.Where(y => y.IsPrimary == true))
                        .FirstOrDefaultAsync(x => x.Id == item.ProductId);

                    total += item.Count * product.Price;

                    if (product != null)
                    {
                        order.OrderItems.Add(new OrderItem
                        {
                            ProductId = product.Id,
                            ProductName = product.Title,
                            Count = item.Count,
                            Price = product.Price,
                            ImageUrl = product.Images[0].ImageUrl

                        });
                    }
                }

                user.BasketDbItems = new List<BasketDbItem>();
            }

            order.TotalPrice = total;

            _emailService.SendMail("nefde2020@gmail.com", "Order", "Order confirmed");

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        } 
        #endregion




    }
}
