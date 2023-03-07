using AppMVC.Domain.Services;
using AppMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppMVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var storageUser = userService
            .RetrieveUserByUserNameAndPassword(model.Username, model.Password);

        if (storageUser == null)
        {
            ModelState.AddModelError(string.Empty, "User does not exist");
            return View(model);
        }

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, storageUser.UserName),
            new Claim(ClaimTypes.Role, storageUser.UserRole.ToString()),
            new Claim(ClaimTypes.UserData, storageUser.Id.ToString())
        }, CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction("Index", "Home");
    }
    
    public async Task<IActionResult> LogoutAsync()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login");
    }
}
