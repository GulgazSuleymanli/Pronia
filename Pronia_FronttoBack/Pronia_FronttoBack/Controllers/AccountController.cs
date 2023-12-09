
using System.Text.RegularExpressions;

namespace Pronia_FronttoBack.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
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


        static bool CheckEmail(string email)
        {
            string pattern = @"^[a-zA-Z._-]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
