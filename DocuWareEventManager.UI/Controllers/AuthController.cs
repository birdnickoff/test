using DocuWareEventManager.BLL.Services;
using DocuWareEventManager.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DocuWareEventManager.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("~/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("~/login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.GetUserId(model.Email, model.Password);
                if (!userId.HasValue)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
                else
                {
                    await SignInUser(userId.Value, model.Email);
                    if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/"))
                    {
                        returnUrl = "/";
                    }

                    return Redirect(returnUrl);
                }
            }

            return View();
        }

        [HttpGet]
        [Route("~/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("~/register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registerResult = await _userService.RegisterUser(model.Email, model.Password);

                switch (registerResult.Result)
                {
                    case BLL.Enums.RegisterUserResult.Added:
                        await SignInUser(registerResult.UserId.Value, model.Email);
                        return Redirect("/");
                    case BLL.Enums.RegisterUserResult.AlreadyExists:
                        ModelState.AddModelError(string.Empty, "Choose another email");
                        break;
                    case BLL.Enums.RegisterUserResult.Failed:
                        ModelState.AddModelError(string.Empty, "Internal error");
                        break;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(int userId, string email)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Name, email),
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}
