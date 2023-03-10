using AppMVC.Domain.Entities;
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

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (model.Password != model.PasswordVerify)
        {
            ModelState.AddModelError(string.Empty, "Passwords are not the same");
            return View();
        }
        if (userService.RetrieveUsers()
            .FirstOrDefault(user => user.UserName == model.UserName) is not null)
        {
            ModelState.AddModelError(string.Empty, "There is a user with this username");
            return View();
        }

        var user = new User()
        {
            UserName = model.UserName,
            PasswordHash = model.Password,
            UserRole = Domain.Enums.Role.User,
            Salt = Guid.NewGuid().ToString()
        }; 

        var storageUser = await userService.CreateUserAsync(user);
        
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
