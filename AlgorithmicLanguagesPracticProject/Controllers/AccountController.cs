using System.Security.Claims;
using AlgorithmicLanguagesPracticProject.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlgorithmicLanguagesPracticProject.Services.Interfaces;

namespace AlgorithmicLanguagesPracticProject.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View(new UserLoginViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = _userService.Login(model);

        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Невірний email або пароль.");
            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Media");
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View(new UserRegisterViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(UserRegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = _userService.Register(model);
        if (!result.Success)
        {
            ModelState.AddModelError(string.Empty, result.Error ?? "Помилка реєстрації");
            return View(model);
        }

        return RedirectToAction(nameof(Login));
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _userService.LogoutAsync(HttpContext);
        return RedirectToAction(nameof(Login));
    }

    [Authorize]
    public IActionResult Profile()
    {
        var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(userIdValue, out var userId))
        {
            return RedirectToAction(nameof(Login));
        }

        var profile = _userService.GetProfile(userId);
        if (profile is null)
        {
            return RedirectToAction(nameof(Login));
        }

        return View(profile);
    }
}
