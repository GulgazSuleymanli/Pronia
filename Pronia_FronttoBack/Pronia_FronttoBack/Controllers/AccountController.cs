
using Microsoft.AspNetCore.Authorization;
using Pronia_FronttoBack.Utilities.Enums;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Pronia_FronttoBack.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _context = context;
        }


        #region Register
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = new AppUser();

            if (CheckEmail(registerVM.Email))
            {
                user.Name = registerVM.Name;
                user.Surname = registerVM.Surname;
                user.UserName = registerVM.Username;
                user.Email = registerVM.Email;
            }
            else
            {
                ModelState.AddModelError("Email", "Wrong email type");
                return View();
            }

            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            await _userManager.AddToRoleAsync(user, UserRole.Member.ToString());

            await _signinManager.SignInAsync(user, false);

            return RedirectToAction(nameof(Index), "Home");
        } 
        #endregion


        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }


        #region Login
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm, string ReturnUrl)
        {
            if (!ModelState.IsValid) return View();

            var existUser = await _userManager.FindByNameAsync(loginVm.UsernameOrEmail);

            if (existUser == null)
            {
                existUser = await _userManager.FindByEmailAsync(loginVm.Password);
                if (existUser == null)
                {
                    ModelState.AddModelError("", "Wrong Username or Password");
                    return View();
                }
            }

            var signCheck = _signinManager.CheckPasswordSignInAsync(existUser, loginVm.Password, false).Result;

            if (!signCheck.Succeeded)
            {
                ModelState.AddModelError("", "Wrong Username or Password");
                return View();
            }

            await _signinManager.SignInAsync(existUser, isPersistent: false);

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction(nameof(Index), "Home");
        }
        #endregion

        [Authorize]
        public async Task<IActionResult> MyAccount()
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            MyAccountVM myAccountVM = new MyAccountVM();
            
            if (user is not null)
            {
                List<Order> userOrders = await _context.Orders.Where(o => o.AppUserId == user.Id).Include(o => o.BasketDbItems).ToListAsync();
                myAccountVM.Orders = userOrders;
            }

            return View(myAccountVM);
        }

        public async Task<IActionResult> Detail(int id)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            


            return View();
        }


        static bool CheckEmail(string email)
        {
            string pattern = @"^[a-zA-Z._-]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }

        public async Task<IActionResult> CreateRole()
        {
            foreach(var item in Enum.GetValues(typeof(UserRole)))
            {
                if(!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString()
                    });
                }
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
