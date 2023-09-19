using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.UI.Identity;
using Shopping.UI.Models;

namespace Shopping.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var code=await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callback = Url.Action("ConfirmEmail", "Account", new
                {

                    userId = user.Id,
                    token = code

                });

                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Beklenmedik bir hata oluştur");

            return View(model);
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {

                ReturnUrl = ReturnUrl
            });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanıcı adı bulunamadı");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen Hesabınızı Email ile onaylayınız");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "~/");
            }


            ModelState.AddModelError("LoginError", "Kullanıcı adı veya şifre hatalı");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz Token";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if(result.Succeeded)
                {
                    TempData["message"] = "Hesap Onaylandı";

                    return View();
                }
            }
            TempData["message"] = "Hesap Onaylanmadı";
            return View();
        }
    }
}
